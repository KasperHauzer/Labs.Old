using System;
using System.Collections.Generic;

namespace Hierarchy
{
    public class Person
    {
        protected static Random _r = new Random();  // closed field for random generating of instance
        protected string _name;                     // closed field of person name
        protected int _age;                         // closed field of person age
        protected static string[] _names =          // closed field of names for random generating of instance
        { "Victor", "Max", "Jon", "Stive", "Brad", "Tass", "Tony", "Adam", "Mark", "Phill", };

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public int Age
        {
            get => _age;

            set {
                if (value < 0)
                    throw new ArgumentException("The age can't be less than 0.");

                _age = value;
            }
        }

        /// <summary>
        /// Gets or sets the names array.
        /// </summary>
        /// <value>The names array.</value>
        public static string[] Names
        {
            get => _names;

            set {
                if (value == null)
                    throw new ArgumentException("The names array can't be equals null.");
            }
        }

        /// <summary>
        /// Gets the random value.
        /// </summary>
        /// <value>The random value.</value>
        internal static Random R => _r;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hierarchy.Person"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age.</param>
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Hierarchy.Person"/> class.
        /// </summary>
        public Person()
        {
            Name = "Adam";
            Age = 17;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Person"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Person"/>.</returns>
        public override string ToString()
        {
            return Name + " " + Age;
        }
    
        /// <summary>
        /// Generates new instance of this.
        /// </summary>
        /// <returns>The Person.</returns>
        public static Person Generate()
        {
            return new Person(Names[R.Next(Names.Length)], R.Next(1, 30));
        }
    }

    public class SortByAge : IComparer<Person>
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
