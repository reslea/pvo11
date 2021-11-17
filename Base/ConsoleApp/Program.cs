using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleApp.Logic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckIndexOf(new List<int>() { 1, 2, 3 }, 3, 3);

            IList<int> vector = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine(vector[3]);
            vector[3] = 1000;
            Console.WriteLine(vector[3]);
            Console.WriteLine(vector.IndexOf(1000));
            vector.RemoveAt(3);
            vector.Insert(3, 999);
            Console.WriteLine(vector[3]);

            var isContains = vector.Contains(1);

            Person alex = new Person(46, "Alex", null, null);
            Person maria1 = new Person(46, "Maria", null, null);
            Person maria2 = new Person(46, "Maria", null, null);
            Person serey = new Person(26, "Sergey", maria1, alex);

            Employee empl = new Employee(46, "Alex", null, null);
            Person emplAsPerson = empl;
            //empl.GrowUp();
            emplAsPerson.GrowUp();

            object obj = maria1;            

            Console.WriteLine(88.GetHashCode());

            //IPersonService personService = new PersonService();
            //Console.WriteLine(personService.SumAges(serey, maria1));
        }

        static void CheckIndexOf(List<int> items, int itemToSearch, int expectedResult)
        {
            var actualResult = items.IndexOf(itemToSearch);
            if (actualResult != expectedResult)
            {
                throw new Exception("Check was not passed");
            }
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
