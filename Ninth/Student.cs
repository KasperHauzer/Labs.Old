using System;

namespace Hierarchy
{
    public class Student : Person
    {
        protected int _course;  // closed field of student course

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public int Course
        {
            get => _course;

            set {
                if (value <= 0)
                    throw new ArgumentException("The course must be greater than 0");
            }
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Hierarchy.Student"/> class.
        /// </summary>
        public Student()
        {
            Name = "Name";
            Age = 17;
            Course = 1;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hierarchy.Student"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age.</param>
        /// <param name="course">Course.</param>
        public Student(string name, int age, int course)
        {
            Name = name;
            Age = age;
            Course = course;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Student"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Student"/>.</returns>
        public override string ToString()
        {
            return base.ToString() + " " + Course;
        }
    
        /// <summary>
        /// Generates this randomed instance.
        /// </summary>
        /// <returns>The generate.</returns>
        public static Student Generate()
        {
            return new Student(Names[R.Next(Names.Length)], R.Next(18, 24), R.Next(1, 7));
        }
    }
}
