using System;

string printedAge = Console.ReadLine();

if(int.TryParse(printedAge, out int age) && age >= 18)
{
    Console.WriteLine(age);
}
else
{
    Console.WriteLine("oops, not a number or its less than 18");
}

Console.ReadLine();

int ParseInt(string s)
{
    int result = 0;

    foreach (char ch in s)
    {
        int charNumber = (int)ch;

        int currentNumber = 0;
        if (charNumber >= 48 && charNumber < 48 + 10)
        {
            currentNumber = charNumber - 48;

            result *= 10;
            result += currentNumber;
        }
        else throw new Exception("cannot parse int");
    }

    return result;
}

bool TryParseInt(string s, out int value)
{
    try
    {
        value = ParseInt(s);

        return true;
    }
    catch (Exception)
    {
        value = default;
        return false;
    }
}