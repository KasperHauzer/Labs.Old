using System;
using System.Linq;
using Hierarchy;
using Collection;

namespace LenguageIntegratedQuery
{
    class Program
    {
        static readonly Random R = new Random();      //closed field of random number

        static void Main(string[] args)
        {
            Sequence<Person> seq = new Sequence<Person>();

            for (int i = 0; i < 1000; i++)
                switch (R.Next() % 3) {
                case 0: seq.Add(Student.Generate()); break;
                case 1: seq.Add(Employee.Generate()); break;
                case 2: seq.Add(Employee.Generate()); break;
                }

            Person a = Teacher.Generate();
        }
    }
}
