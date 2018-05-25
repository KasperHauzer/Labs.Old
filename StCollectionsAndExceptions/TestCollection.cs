using System;
using Hierarchy;
using System.Linq;
using System.Collections.Generic;

namespace StCollectionsAndExceptions
{
    public class TestCollection
    {
        public Student[] baseArray;
        public List<Person> keys;
        public List<string> stringKeys;
        public Dictionary<Person, Student> dictionary;
        public Dictionary<string, Student> stringDictionary;
        static int ageKoefficient = 100;

        /// <summary>
        /// Creates the array.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="count">Count.</param>
        protected static Student[] CreateArray(int count)
        {
            Student[] arr = new Student[count];

            for (int i = 0, age = 1000; i < count; i++, age += 10)
                arr[i] = Generate(i);

            return arr;
        }

        /// <summary>
        /// Generate the specified Student.
        /// </summary>
        /// <returns>The Student.</returns>
        /// <param name="num">Number.</param>
        protected static Student Generate(int num)
        {
            return new Student
            {
                Age = num + ageKoefficient++,
                Name = Person.Names[num % Person.Names.Length]
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StCollectionsAndExceptions.TestCollection"/> class.
        /// </summary>
        /// <param name="count">Count.</param>
        public TestCollection(int count)
        {
            baseArray = CreateArray(count);

            keys = baseArray.Select(x => x.GetBase).ToList();
            stringKeys = baseArray.Select(x => x.GetBase.ToString()).ToList();
            dictionary = baseArray.ToDictionary(x => x.GetBase);
            stringDictionary = baseArray.ToDictionary(x => x.GetBase.ToString());
        }
    
        /// <summary>
        /// Pruns the specified index.
        /// </summary>
        /// <returns>The prun.</returns>
        /// <param name="index">Index.</param>
        public void Prun (int index)
        {
            if (index < 0 || index > baseArray.Length) throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Pruns a lists and a dectionaries.
        /// </summary>
        /// <returns>The pruned lists and dectionaries.</returns>
        /// <param name="lastIndex">Last index.</param>
        void Redefinition(Student[] newBaseArray)
        {
            if (newBaseArray == null && newBaseArray.Length == 0) throw new BaseArrayIsEmptyException();

            baseArray = newBaseArray;

            keys = baseArray.Select(x => x.GetBase).ToList();
            stringKeys = baseArray.Select(x => x.GetBase.ToString()).ToList();
            dictionary = baseArray.ToDictionary(x => x.GetBase);
            stringDictionary = baseArray.ToDictionary(x => x.GetBase.ToString());
        }
    
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(Student item)
        {
            Student[] array = new Student[baseArray.Length + 1];
            Array.Copy(baseArray, array, baseArray.Length);
            array[array.Length - 1] = item;
            Redefinition(array);
        }
    
        /// <summary>
        /// Removes an item at index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < baseArray.Length) 
            {
                Student[] array = new Student[baseArray.Length - 1];
                Array.Copy(baseArray, array, index);

                for (int i = index, k = index + 1; i < array.Length && k < baseArray.Length; i++, k++)
                    array[i] = baseArray[k];

                Redefinition(array);
            }
        }
    }

    public class BaseArrayIsEmptyException : ApplicationException
    {
        public BaseArrayIsEmptyException() : base() { }
        public BaseArrayIsEmptyException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
