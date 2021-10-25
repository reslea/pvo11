using System;
using ConsoleApp.Logic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person alex = new Person(46, "Alex", null, null);
            Person maria1 = new Person(46, "Maria", null, null);
            Person maria2 = new Person(46, "Maria", null, null);
            Person serey = new Person(26, "Sergey", maria1, alex);

            object obj = maria1;            

            Console.WriteLine(88.GetHashCode());

            //IPersonService personService = new PersonService();
            //Console.WriteLine(personService.SumAges(serey, maria1));
        }
    }


    public interface IOutputable
    {
        void Output(string str);
    }

    public class ConsoleUI : IOutputable
    {
        public void Output(string str)
        {
            Console.WriteLine(str);
        }

        public string Input()
        {
            return Console.ReadLine();
        }
    }
}
