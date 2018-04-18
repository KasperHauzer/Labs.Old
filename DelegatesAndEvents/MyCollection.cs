using System;
using Hierarchy;
using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEvents
{
    public class MyCollection : ICollection<Person>
    {
        protected List<Person> _list;   //closed field of list ;)

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => _list.Capacity;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:DelegatesAndEvents.MyCollection"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>The list.</value>
        internal List<Person> list
        {
            get => _list;
            set => _list = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="T:DelegatesAndEvents.MyCollection"/> with the specified i.
        /// </summary>
        /// <param name="i">The index.</param>
        public Person this[int i]
        {
            get => list[i];
            set => list[i] = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DelegatesAndEvents.MyCollection"/> class.
        /// </summary>
        /// <param name="length">Length.</param>
        public MyCollection(int length)
        {
            
            fillArray();
        }

        /// <summary>
        /// Fills the array.
        /// </summary>
        internal bool fillArray()
        {
            if (list != null) {
                Random R = new Random();

                for (int i = 0; i < Count; i++)
                    switch (R.Next() % 3) {
                    case 0: list.Add(Student.Generate()); break;
                    case 2: list.Add(Teacher.Generate()); break;
                    case 1: list.Add(Employee.Generate()); break;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(Person item)
        {
            list.Add(item);
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        /// <summary>
        /// Contains the specified item.
        /// </summary>
        /// <returns>The contains.</returns>
        /// <param name="item">Item.</param>
        public bool Contains(Person item)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="arrayIndex">Array index.</param>
        public void CopyTo(Person[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<Person> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(Person item)
        {
            return list.Remove(item);
        }

        /// <summary>
        /// System.s the collections. IE numerable. get enumerator.
        /// </summary>
        /// <returns>The collections. IE numerable. get enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
