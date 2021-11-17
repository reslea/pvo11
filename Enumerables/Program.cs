using System.Collections;

IEnumerable<int> numbers = GetNumbers(10);

Action<int> action = x => Console.WriteLine(x);
action(5);

Func<int, double> func = (x) => x / 318.0;
Console.WriteLine(func(500));

//var evenNumbers = GetEven(numbers);
//var oddNumbers = GetOdd(numbers);


IEnumerable<int> evenNumbers = FilterNumbers(numbers, (x) => x % 2 == 0);
IEnumerable<int> oddNumbers = FilterNumbers(numbers, (x) => x % 2 != 0);

Console.ReadLine();

IEnumerable<int> FilterNumbers(IEnumerable<int> numbers, Func<int, bool> filter)
{
    foreach (var number in numbers)
    {
        if (filter(number))
        {
            yield return number;
        }
    }
}

//IEnumerable<int> GetEven(IEnumerable<int> numbers)
//{
//    foreach (var number in numbers)
//    {
//        if (number % 2 == 0)
//        {
//            yield return number;
//        }
//    }
//}

//IEnumerable<int> GetOdd(IEnumerable<int> numbers)
//{
//    foreach (var number in numbers)
//    {
//        if (number % 2 != 0)
//        {
//            yield return number;
//        }
//    }
//}

//var numbersEnumerator = numbers.GetEnumerator();
//while (numbersEnumerator.MoveNext())
//{
//    Console.WriteLine(numbersEnumerator.Current);
//}

int GetX(int x)
{
    return x + 10;
}

foreach (var number in numbers)
{
    Console.WriteLine(number);

    if (number == 100)
        break;
}

IEnumerable<int> GetNumbers(int maxNumber)
{
    return new NumbersGenerator();
}

class NumbersGenerator : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new NumbersEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new NumbersEnumerator();
    }
}

class NumbersEnumerator : IEnumerator<int>
{
    public int Start { get; set; } = 1;

    public int MaxNumber { get; set; } = 10;
    public int Current { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (Current < MaxNumber)
        {
            Current = Start;
            Start++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}