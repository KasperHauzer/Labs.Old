namespace Hierarchy
{
    public class Teacher : Employee
    {
        /// <summary>
        /// Ranks of teachers.
        /// </summary>
        public enum Rank {
            
            /// <summary>
            /// The assistent.
            /// </summary>
            Assistent = 1,

            /// <summary>
            /// The doctor.
            /// </summary>
            Doctor = 2,

            /// <summary>
            /// The scientist.
            /// </summary>
            Scientist = 3
        }

        protected Rank _title;  //closed field of techer title/rank

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public Rank Title
        {
            get => _title;
            set => _title = value;
        }

        /// <summary>
        /// Gets the title mask.
        /// </summary>
        /// <value>The title mask.</value>
        public string TitleMask
        {
            get {
                switch (Title) {
                    case Rank.Doctor: return "Doctor"; 
                    case Rank.Assistent: return "Assistent";
                    case Rank.Scientist: return "Scientist";
                    default: return "not implemented title";
                }
            }
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Hierarchy.Teacher"/> class.
        /// </summary>
        public Teacher()
        {
            Title = Rank.Assistent;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hierarchy.Teacher"/> class based on <see cref="T:Hierarchy.Employee"/>.
        /// </summary>
        /// <param name="employee">Employee.</param>
        /// <param name="title">Title.</param>
        public Teacher(Employee employee, Rank title) : base(employee.Name, employee.Age, employee.Wage)
        {
            Title = title;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hierarchy.Teacher"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age.</param>
        /// <param name="wage">Wage.</param>
        /// <param name="title">Title.</param>
        public Teacher(string name, int age, int wage, Rank title) : base(name, age, wage)
        {
            Title = title;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Teacher"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Hierarchy.Teacher"/>.</returns>
        public override string ToString()
        {
            return base.ToString() + " " + TitleMask;
        }
    
        /// <summary>
        /// Generates the random title.
        /// </summary>
        /// <returns>The random title.</returns>
        internal static Rank GenerateTitle()
        {
            switch (R.Next() % 3) {
                case 0: return Rank.Doctor;
                case 1: return Rank.Assistent;
                case 2: return Rank.Scientist;
                default: return Rank.Assistent;
            }
        }

        /// <summary>
        /// Generate this random instance.
        /// </summary>
        /// <returns>The random generate.</returns>
        new public static Teacher Generate()
        {
            return new Teacher(Employee.Generate(), GenerateTitle());
        }
    }
}
