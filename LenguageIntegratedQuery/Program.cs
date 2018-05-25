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
            a.ScientistCount();
            b.ScientistCount();


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
            a.MinSalary();
            b.MinSalary();


            // #6 объединение двух последовательностей
            //a.ToList().Concat(b.ToList());
            //Console.WriteLine(a.Description());


            // #7 возвращение общих элементов из двух списков
            //List<Person> c = new List<Person>();
            //Person person1 = Student.Generate();
            //Person person2 = Teacher.Generate();
            //Person person3 = Employee.Generate();
            //a.Add(person1);
            //a.Add(person2);
            //a.Add(person3);
            //b.Add(person1);
            //b.Add(person2);
            //b.Add(person3);
            //c = a.ToArray().Intersect(b.ToArray()).ToList();
        }
    }

    static class SequenceExtansion
    {
        static readonly Random R = new Random();

        /// <summary>
        /// Filling the specified sequence and length.
        /// </summary>
        /// <returns>The filling.</returns>
        /// <param name="sequence">Sequence.</param>
        /// <param name="length">Length.</param>
        public static void Filling(this Sequence<Person> sequence, int length)
        {
            for (int i = 0; i < length; i++)
                switch (R.Next() % 3) {
                case 0: sequence.Add(Student.Generate()); break;
                case 1: sequence.Add(Employee.Generate()); break;
                case 2: sequence.Add(Employee.Generate()); break;
                }
        }

        /// <summary>
        /// Describe the specified sequence.
        /// </summary>
        /// <returns>The description.</returns>
        /// <param name="sequence">Sequence.</param>
        public static string Description(this Sequence<Person> sequence)
        {
            string description = string.Empty;

            foreach (Person i in sequence)
                description += i + "\n";

            return description;
        }

        /// <summary>
        /// Students the filter.
        /// </summary>
        /// <returns>The filter.</returns>
        /// <param name="sequence">Sequence.</param>
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
    
        /// <summary>
        /// Nameses the sort.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="sequence">Sequence.</param>
        /// <param name="count">Count.</param>
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
    
        /// <summary>
        /// Scientists the count.
        /// </summary>
        /// <returns>The count.</returns>
        /// <param name="sequence">Sequence.</param>
        public static int ScientistCount(this Sequence<Person> sequence)
        {
            return (from x in sequence.ToArray()
                    where x is Teacher
                    where (x as Teacher).Title == Teacher.Rank.Scientist
                    select x).Count();
        }
    
        /// <summary>
        /// Firsts the names which contains a.
        /// </summary>
        /// <returns>The names which contains a.</returns>
        /// <param name="sequence">Sequence.</param>
        /// <param name="count">Count.</param>
        public static string[] FirstNamesWhichContainsA(this Sequence<Person> sequence, int count)
        {
            return sequence.ToArray()
                           .Where(x => x.Name.Contains('a') || x.Name.Contains('A'))
                           .Select(x => x.Name)
                           .Take(count)
                           .OrderBy(x => x.Length)
                           .ToArray();
        }
    
        /// <summary>
        /// Minimums the salary.
        /// </summary>
        /// <returns>The salary.</returns>
        /// <param name="sequence">Sequence.</param>
        public static float MinSalary(this Sequence<Person> sequence)
        {
            return sequence.ToArray().Where(x => x is Employee).Min(x => (x as Employee).Wage);
        }
    }
}
