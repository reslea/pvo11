using FileReader;
Console.WriteLine("Please enter a file name:");
string fileName = Console.ReadLine()!;
FileReader.FileReader? fileReader = ReaderFactory.GetFileReader(fileName);

if(fileReader != null)
{
    JsonReader jsonReader = new JsonReader(fileReader);
    IEnumerable<Hero> heroes = jsonReader.GetHeroes();

    foreach (var hero in heroes)
    {
        Console.WriteLine(hero);
    }
}

//IReadyToWorkReader readyToWorkReader = GetReadyToWorkFileFromUser();

//IEnumerable<Hero> heroes = readyToWorkReader.GetHeroes();

//foreach (Hero hero in heroes)
//{
//    Console.WriteLine(hero);
//}

//IReadyToWorkReader GetReadyToWorkFileFromUser()
//{
//    IReadyToWorkReader? file;
//    do
//    {
//        Console.WriteLine("Please enter a file name:");
//        string fileName = Console.ReadLine()!;
//        file = ReaderFactory.GetReadyToWorkReader(fileName);

//        if (file == null)
//        {
//            Console.WriteLine("Oops, cannot work with this file");
//        }
//    } while (file == null);

//    return file;
//}