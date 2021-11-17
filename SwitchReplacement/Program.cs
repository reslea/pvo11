int? age;

Console.WriteLine("Please enter your age:");

var ageInput = Console.ReadLine()!;

age = int.TryParse(ageInput, out int ageInfo) 
    ? ageInfo 
    : null;

if(age.HasValue)
{
    Console.WriteLine($"your age is {age.Value}");
}
else
{
    Console.WriteLine("Age wasnt specified");
}