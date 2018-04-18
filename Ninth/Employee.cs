using System;

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
    }
}
