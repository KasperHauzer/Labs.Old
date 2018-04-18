using System;

namespace Hierarchy
{
    public abstract class Person
    {
        protected string _name;
        protected int _age;

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
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Person"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Person"/>.</returns>
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
