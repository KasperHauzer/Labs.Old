using System;
using System.Linq;
using Hierarchy;
using Collection;

namespace LenguageIntegratedQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence<Person> a = new Sequence<Person>();
            Sequence<Person> b = new Sequence<Person>();
            a.

        }


    }

    static class SequenceExtansion
    {
        static readonly Random R = new Random();

        static void Filling(this Sequence<Person> sequence, int length)
        {
            for (int i = 0; i < length; i++)
                switch (R.Next() % 3) {
                case 0: sequence.Add(Student.Generate()); break;
                case 1: sequence.Add(Employee.Generate()); break;
                case 2: sequence.Add(Employee.Generate()); break;
                }
        }
    }
}
