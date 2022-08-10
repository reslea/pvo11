using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using EventStoreAccount;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text;

IEventStoreConnection esConnection = await CreateEsConnection();

var credentials = new UserCredentials("admin", "changeit");

//string streamName = await GenerateNewAccount(esConnection);

const string category = "Account";

var context = new BankingDbContext();

var categoryCheckpoint = await context.CategoryCheckpoints
    .FirstOrDefaultAsync(c => c.CategoryName == category);

if (categoryCheckpoint == null)
{
    categoryCheckpoint = new CategoryCheckpoint { CategoryName = category };
    context.CategoryCheckpoints.Add(categoryCheckpoint);
}
var startEventNumber = categoryCheckpoint.LastProcessedEventNumber + 1;
var eventSlice = await esConnection.ReadStreamEventsForwardAsync($"$ce-{category}", startEventNumber, 100, true, credentials);

await SaveExisitingAccounts(context, eventSlice);

categoryCheckpoint.LastProcessedEventNumber = eventSlice.LastEventNumber;
await context.SaveChangesAsync();

Console.WriteLine("existing account are saved to DB");

await esConnection.SubscribeToStreamAsync($"$ce-{category}", true, (_, @event) =>
{
    var eventData = ParseEvent(@event.Event);

    var accountId = new Guid(@event.Event.EventStreamId.Replace($"{category}-", ""));

    var dbAccount = context.AccountStates.FirstOrDefault(a => a.AccountId == accountId);

    if (dbAccount != null)
    { 
        UpdateAccountState(dbAccount, eventData);
    }
    else
    {
        dbAccount = new AccountState(accountId);
        context.AccountStates.Add(dbAccount);
    }
    dbAccount.Version = @event.Event.EventNumber;
    categoryCheckpoint.LastProcessedEventNumber = @event.OriginalEventNumber;
    context.SaveChanges();
});

Console.ReadLine();

void UpdateAccountState(AccountState accountState, IEvent data)
{
    switch (data)
    {
        case InitialEvent initialEvent:
            accountState.State = "Open";
            accountState.Balance = initialEvent.Amount;
            accountState.OwnerName = initialEvent.Username;
            break;
        case SalaryEvent salaryEvent:
            accountState.Balance += salaryEvent.Amount;
            break;
        case SpendingEvent spendingEvent:
            accountState.Balance -= spendingEvent.Amount;
            break;
        case ClosedEvent closedEvent:
            accountState.State = "Closed";
            break;
        default: break;
    }
    Console.WriteLine(accountState);
};

EventData CreateEvent<T>(T obj)
    where T : IEvent
{
    var json = JsonConvert.SerializeObject(obj);
    var jsonBytes = Encoding.UTF8.GetBytes(json);

    return new EventData(
            Guid.NewGuid(),
            obj.Type,
            true,
            jsonBytes,
            null);
};

List<EventData> generateAccountEvents(string username, Guid accountId)
{
    return new List<EventData>
    {
        CreateEvent(new InitialEvent(500, username, accountId)),
        CreateEvent(new SalaryEvent(1000)),
        CreateEvent(new SalaryEvent(1000)),
        CreateEvent(new SpendingEvent(700)),
        CreateEvent(new SalaryEvent(1000)),
        CreateEvent(new SpendingEvent(300)),
        CreateEvent(new SpendingEvent(300)),
        CreateEvent(new ClosedEvent()),
    };
}

static async Task<IEventStoreConnection> CreateEsConnection()
{
    var esConnection = EventStoreConnection.Create(
        new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));

    await esConnection.ConnectAsync();
    return esConnection;
}

async Task<string> GenerateNewAccount(IEventStoreConnection esConnection)
{
    var accountId = Guid.NewGuid();
    var streamName = $"Account-{accountId}";
    var username = "John";
    List<EventData> events = generateAccountEvents(username, accountId);

    await esConnection.AppendToStreamAsync(streamName, ExpectedVersion.Any, events);
    return streamName;
}

async Task SaveExisitingAccounts(BankingDbContext context, StreamEventsSlice eventSlice)
{
    foreach (var @event in eventSlice.Events.Select(e => e.Event))
    {
        if (@event == null || @event.EventType.StartsWith("$"))
            continue;
        IEvent data = ParseEvent(@event);

        var isNewAccount = @event.EventType == nameof(AccountEventTypes.Initial);

        var account = new Guid(@event.EventStreamId.Replace("Account-", ""));

        AccountState accountState = isNewAccount
            ? new AccountState(account)
            : context.AccountStates.First(a => a.AccountId == account);

        UpdateAccountState(accountState, data);

        if (isNewAccount)
        {
            context.AccountStates.Add(accountState);
        }

        accountState.Version = @event.EventNumber;

        await context.SaveChangesAsync();
    }
}

static IEvent ParseEvent(RecordedEvent @event)
{
    var json = Encoding.UTF8.GetString(@event.Data);


    IEvent data = @event.EventType switch
    {
        nameof(AccountEventTypes.Initial) => JsonConvert.DeserializeObject<InitialEvent>(json),
        nameof(AccountEventTypes.Salary) => JsonConvert.DeserializeObject<SalaryEvent>(json),
        nameof(AccountEventTypes.Spending) => JsonConvert.DeserializeObject<SpendingEvent>(json),
        nameof(AccountEventTypes.Closed) => JsonConvert.DeserializeObject<ClosedEvent>(json),
        _ => throw new ArgumentException("unknown event type")
    };
    return data;
}