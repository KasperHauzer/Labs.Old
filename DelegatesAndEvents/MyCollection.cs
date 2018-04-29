using System;
using Hierarchy;
using Collection;

namespace DelegatesAndEvents
{
    public class MyCollection : Sequence<Person>
    {
        Random _r = new Random();      //closed field of random number
        Sequence<Person> _sequence;     //closed field of sequence

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>The seq.</value>
        protected Sequence<Person> Seq 
        { 
            get => _sequence; 
            set => _sequence = value; 
        }

        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <value>The random.</value>
        protected Random R => _r;

        /// <summary>
        /// Gets the length (is readonly).
        /// </summary>
        /// <value>The length.</value>
        public int Length => Seq.Count;


        /// <summary>
        /// Initializes a new default instance of the <see cref="T:DelegatesAndEvents.MyCollection"/> class and fills it.
        /// </summary>
        public MyCollection(int length)
        {
            Seq = new Sequence<Person>();

            for (int i = 0; i < length; i++)
                switch (R.Next() % 3) {
                    case 0: Seq.Add(Student.Generate()); break;
                    case 1: Seq.Add(Employee.Generate()); break;
                    case 2: Seq.Add(Teacher.Generate()); break;
                }
        }
    

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        new public void Add(Person item)
        {
            Seq.Add(item);
        }
    
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        new public bool Remove(Person item)
        {
            return Seq.Remove(item);
        }

        /// <summary>
        /// Inserts the specified index and item.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        new public bool Insert(int index, Person item)
        {
            return Seq.Insert(index, item);
        }
    
        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="comparer">Comparer.</param>
        new public void Sort(System.Collections.IComparer comparer)
        {
            Seq.Sort(comparer);
        }
    
        /// <summary>
        /// Clears this instance.
        /// </summary>
        new public void Clear()
        {
            Seq.Clear();
        }
    }
}
