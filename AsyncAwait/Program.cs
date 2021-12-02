//while (true)
//{
//    Task task = new Task(PrintTheadId);
//    task.Start();
//}

for (int i = 0; i < 100; i++)
{
    Task startRequest = new Task(() =>
    {
        Console.WriteLine($"Parsing JSON... request#{i}");
        Thread.Sleep(500);
    });
    startRequest.Start();

    startRequest
    .ContinueWith((_) =>
    {
        Console.WriteLine($"Creating search creteria... request#{i}");
        Thread.Sleep(500);
    })
    .ContinueWith((_) =>
    {
        Console.WriteLine($"Requesting SQL server... request#{i}");
        Thread.Sleep(500);
    });
}


ThreadPool.SetMinThreads(1, 10);
ThreadPool.SetMaxThreads(2, 10);

ThreadPool.GetMaxThreads(out int maxThreads, out _);
ThreadPool.GetMinThreads(out int minThreads, out _);
Console.WriteLine("Thread pool settings:");
Console.WriteLine($"min: {minThreads} threads max: {maxThreads} threads");

while (true)
{
    ThreadPool.QueueUserWorkItem<string?>(PrintMessage, null, false);
}






int threadCount = 15;

for (int i = 0; i < threadCount; i++)
{
    Thread thread = new Thread(PrintHi);
    thread.Start();
}

while (true)
{
    Console.WriteLine("im in a main thread");
}

void PrintTheadId()
{
    int threadId = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"thread: {threadId}");

    Thread.Sleep(500);
}

void PrintMessage(string? message)
{
    //message = message == null
    //       ? ""
    //       : message;
    message = message ?? "";

    int threadId = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"thread: {threadId}" + message);

    Thread.Sleep(500);
}

void PrintHi()
{
    while (true)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"#{threadId}");
    }
}