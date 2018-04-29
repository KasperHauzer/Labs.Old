using System;
using System.Collections.Generic;

namespace Hierarchy
{
    public class Employee : Person
    {
        protected int _wage;

        /// <summary>
        /// Gets or sets the wage.
        /// </summary>
        /// <value>The wage.</value>
        public int Wage
        {
            get => _wage;

            set {
                if (value < 0)
                    throw new ArgumentException("The wage can't be less than 0.");

                _wage = value;
            }
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Hierarchy.Employee"/> class.
        /// </summary>
        public Employee()
        {
            Name = "Name";
            Age = 21;
            Wage = 60_000;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hierarchy.Employee"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age.</param>
        /// <param name="wage">Wage.</param>
        public Employee(string name, int age, int wage)
        {
            Name = name;
            Age = age;
            Wage = wage;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Employee"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Employee"/>.</returns>
        public override string ToString()
        {
            return base.ToString() + " W:" + Wage.ToString("C2");
        }
    
        /// <summary>
        /// Generate this random instance.
        /// </summary>
        /// <returns>A random instance.</returns>
        public static Employee Generate()
        {
            return new Employee(Names[R.Next(Names.Length)], R.Next(18, 24), R.Next(0, 999_999));
        }
    }

    public class SortByWage : IComparer<Employee>
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public int Compare(Employee x, Employee y)
        {
            return x.Wage.CompareTo(y.Wage);
        }
    }
}
