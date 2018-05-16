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
        /// Pruns a lists and a dectionaries.
        /// </summary>
        /// <returns>The pruned lists and dectionaries.</returns>
        /// <param name="lastIndex">Last index.</param>
        public void Prun(int lastIndex)
        {
            if (baseArray == null) throw new BaseArrayIsEmptyException();
            if (lastIndex < 0 || lastIndex > baseArray.Length) throw new IndexOutOfRangeException();

            for (int i = 0; i < baseArray.Length; i++) {
                keys.Add(baseArray[i].GetBase);
                stringKeys.Add(baseArray[i].GetBase.ToString());
                dictionary.Add(baseArray[i].GetBase, baseArray[i]);
                stringDictionary.Add(baseArray[i].GetBase.ToString(), baseArray[i]);
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
