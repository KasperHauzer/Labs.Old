using System;
using System.Linq;
using Hierarchy;
using Collection;
using System.Collections.Generic;

namespace LenguageIntegratedQuery
{
    class Program
    {
        static void Main()
        {
            Sequence<Person> a = new Sequence<Person>();
            Sequence<Person> b = new Sequence<Person>();
            a.Filling(200);
            b.Filling(200);


            // #1 query: имена всех первокурсников не старше 18
            IEnumerable<string> enum1 = a.ToArray()
                                         .Where(x => x is Student)
                                         .Where(x => (x as Student).Course == 1 && (x as Student).Age <= 18)
                                         .Select(x => x.Name);
            a.StudentFilter();
            b.StudentFilter();


            // #2 query: число ученных
            int ScientistCount = (from x in b.ToArray()
                                  where x is Teacher
                                  where (x as Teacher).Title == Teacher.Rank.Scientist
                                  select x).Count();


            // #3 query: средний возраст работников
            int averageAge = (int)a.ToArray().Where(x => x is Employee).Average(x => x.Age);


            // #4 query: 4 первых имени содержащих "А"
            string[] names = b.ToArray()
                              .Where(x => x.Name.Contains('a') || x.Name.Contains('A'))
                              .Select(x => x.Name)
                              .Take(5)
                              .OrderBy(x => x.Length)
                              .ToArray();


            // #5 query: самая маленькая зарплата
            float minWage = a.ToArray().Where(x => x is Employee).Min(x => (x as Employee).Wage);
        }
    }

    static class SequenceExtansion
    {
        static readonly Random R = new Random();

        public static void Filling(this Sequence<Person> sequence, int length)
        {
            for (int i = 0; i < length; i++)
                switch (R.Next() % 3) {
                case 0: sequence.Add(Student.Generate()); break;
                case 1: sequence.Add(Employee.Generate()); break;
                case 2: sequence.Add(Employee.Generate()); break;
                }
        }

        public static Sequence<string> StudentFilter(this Sequence<Person> sequence)
        {
            string[] students = sequence.ToArray()
                                        .Where(x => x is Student)
                                        .Where(x => (x as Student).Course == 1 && (x as Student).Age <= 18)
                                        .Select(x => x.Name).ToArray();

            Sequence<string> names = new Sequence<string>();

            for (int i = 0; i < students.Length; i++)
                names.Add(students[i]);

            return names;
        }
    
        public static Sequence<string> NamesSort(this Sequence<Person> sequence, int count)
        {
            string[] names = sequence.ToArray()
                              .Where(x => x.Name.Contains('a') || x.Name.Contains('A'))
                              .Select(x => x.Name)
                              .Take(count)
                              .OrderBy(x => x.Length)
                              .ToArray();

            Sequence<string> names1 = new Sequence<string>();

            for (int i = 0; i < names.Length; i++)
                names1.Add(names[i]);

            return names1;
        }
    
        public static Sequence<Person> Collobaration(this Sequence<Person> sequence, Sequence<Person> b)
        {
            
        }
    }
}
