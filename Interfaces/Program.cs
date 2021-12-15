// Дано номер билета (6 чисел)
// если сумма первой половины билета равна сумме второй
// то билет счастливый

string ticketNumber = Console.ReadLine()!;
IHappyTicketChecker checker = null;

bool isHappy = checker.IsHappy(ticketNumber);

if (isHappy)
{
    Console.WriteLine("The ticket is happy");
}
else
{
    Console.WriteLine("Sorry, better luck next time");
}

public interface IHappyTicketChecker
{
    bool IsHappy(string ticketNumber);
}

public class HappyTicketChecker : IHappyTicketChecker
{
    public bool IsHappy(string ticketNumber)
    {
        throw new NotImplementedException();
    }
}
