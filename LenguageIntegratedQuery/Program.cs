using System;
using System.Linq;
using Hierarchy;
using System.Collections.Generic;

namespace LenguageIntegratedQuery
{
    class Program
    {
        public static Random random = new Random();
        public const Int32 size = 10;
        public const Int32 otherSize = 3;

        static void Main()
        {
            List<Person> people = new List<Person>();
            people.ToFill(size, random);
            Print(people);

            List<Student> students = people.GetAllStudents();
            Print(students);

            int goodWage = people.GetGoodWage();
            Console.WriteLine(goodWage);

            double averageSalary = people.GetAverageSalary();
            Console.WriteLine(averageSalary.ToString("C2") + "\n");

            //-----------------------------------------------

            List<Person> people1 = new List<Person>();
            List<Person> people2 = new List<Person>();
            people1.ToFill(otherSize, random);
            people2.ToFill(otherSize, random);
            Person a = new Person("IntersectOne", 100);
            Person b = new Person("IntersectTwo", 100);

            people1.Add(a);
            people1.Add(b);
            people2.Add(a);
            people2.Add(b);

            Print(people1.Объединение(people2));
            Print(people1.Пересечение(people2));
            Print(people1.Разность(people2));
        }

        /// <summary>
        /// Print the specified list.
        /// </summary>
        /// <returns>The print.</returns>
        /// <param name="list">List.</param>
        public static void Print(List<Student> list)
        {
            if (list.Count == 0) Console.WriteLine("List is empty \n");

            else {
                int n = 0;
                foreach (Student i in list)
                    Console.WriteLine(++n + ") " + i);

                Console.WriteLine();
            }
        }
    
        /// <summary>
        /// Print the specified list.
        /// </summary>
        /// <returns>The print.</returns>
        /// <param name="list">List.</param>
        public static void Print(List<Person> list)
        {
            if (list.Count == 0) Console.WriteLine("List is empty \n");

            else {
                int n = 0;
                foreach (Person i in list)
                    Console.WriteLine(++n + ") " + i);

                Console.WriteLine();
            }
        }
    }

    static class ListExtension 
    {
        /// <summary>
        /// Creates the list.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="count">Count.</param>
        /// <param name="random">Random value.</param>
        public static List<Person> ToFill(this List<Person> people, int count, Random random)
        {
            for (int i = 0; i < count; i++)
                switch (random.Next() % 4) {
                case 0: people.Add(Person.Generate()); break;
                case 1: people.Add(Student.Generate()); break;
                case 2: people.Add(Employee.Generate()); break;
                case 3: people.Add(Teacher.Generate()); break;
                }

            return people;
        }
    
        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>The all students.</returns>
        /// <param name="people">People.</param>
        public static List<Student> GetAllStudents(this List<Person> people)
        {
            //return people.OfType<Student>().ToList();

            return (from student in people where student is Student select student as Student).ToList(); 
        }
    
        /// <summary>
        /// Gets the employees with wage bigger than ten TH ousand.
        /// </summary>
        /// <returns>The employees with wage bigger than ten TH ousand.</returns>
        /// <param name="people">People.</param>
        public static int GetGoodWage(this List<Person> people)
        {
            //return people.OfType<Employee>().Count(x => x.Wage >= 10_000);

            return (from e in people where e is Employee && (e as Employee).Wage >= 50_000 select e).Count();
        }
    
        /// <summary>
        /// Gets the average salary.
        /// </summary>
        /// <returns>The average salary.</returns>
        /// <param name="people">People.</param>
        public static int GetAverageSalary(this List<Person> people)
        {
            //return people.Where(x => x is Employee).Average(x => (x as Employee).Wage);

            return (int)(from e in people where e is Employee select e).Average(x => (x as Employee).Wage);
        }
    
        /// <summary>
        /// Объединение the specified people and other.
        /// </summary>
        /// <returns>The объединение.</returns>
        /// <param name="people">People.</param>
        /// <param name="other">Other.</param>
        public static List<Person> Объединение(this List<Person> people, List<Person> other)
        {
            return people.Concat(other).ToList();
        }
    
        /// <summary>
        /// Пересечение the specified people and other.
        /// </summary>
        /// <returns>The пересечение.</returns>
        /// <param name="people">People.</param>
        /// <param name="other">Other.</param>
        public static List<Person> Пересечение(this List<Person> people, List<Person> other)
        {
            return people.Intersect(other).ToList();
        }
    
        /// <summary>
        /// Разность the specified people and other.
        /// </summary>
        /// <returns>The разность.</returns>
        /// <param name="people">People.</param>
        /// <param name="other">Other.</param>
        public static List<Person> Разность(this List<Person> people, List<Person> other)
        {
            return people.Except(other).ToList();
        }
    }
}
