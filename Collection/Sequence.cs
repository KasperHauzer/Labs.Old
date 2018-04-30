using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class Sequence<T> : IEnumerable
    {
        internal T[] _array;                    // closed field of base array
        internal int _count;                    // closed field of items count in sequence
        internal int _capacity;                 // closed field of base array length
        internal int _expandingKoefficient;     // closed field of expanding koefficient


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count 
        {
            get => _count;

            //count is readonly
            private set => _count = value; 
        }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public int Capacity
        {
            get => _capacity;

            //capacity is readonly
            private set {
                _capacity = value;
                _expandingKoefficient = value * 7 / 10;
            }
        }

        public T this[int index]
        {
            get {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();

                return Source[index];
            }

            set {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();

                Source[index] = value;
            }
        }

        /// <summary>
        /// Gets or sets the base array.
        /// </summary>
        /// <value>The base array.</value>
        protected T[] Source
        {
            get => _array;
            set => _array = value;
        }

        /// <summary>
        /// Gets or sets the expanding koefficient.
        /// </summary>
        /// <value>The expanding koefficient.</value>
        protected int ExpandingKoefficient
        {
            //expanding kofficient is readonly
            get => _expandingKoefficient;
        }


        /// <summary>
        /// Initializes a new default instance of the <see cref="T:Collection.Sequence`1"/> class.
        /// </summary>
        public Sequence()
        {
            Capacity = 70;
            Source = new T[Capacity];
            Count = 0;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Collection.Sequence`1"/> class.
        /// </summary>
        /// <param name="capacity">Capacity.</param>
        public Sequence(int capacity)
        {
            Capacity = capacity;
            Source = new T[Capacity];
            Count = 0;
        }


        /// <summary>
        /// Expands the base array.
        /// </summary>
        protected void ExpandBaseArray()
        {
            T[] newSource = new T[Source.Length + ExpandingKoefficient];

            for (int i = 0; i < Count; i++)
                newSource[i] = Source[i];

            Source = newSource;
            Capacity = newSource.Length;
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Collection.Sequence`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Collection.Sequence`1"/>.</returns>
        public override string ToString()
        {
            return typeof(T) + " - " + Count;
        }
    
        /// <summary>
        /// Inserts to sequence item by index.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public bool Insert(int index, T item)
        {
            if (index < 0 || index > Count + 1) return false;

            if (Count == Capacity)
                ExpandBaseArray();

            for (int i = Count; i > index; i--)
                Source[i + 1] = Source[i];

            Source[index] = item;
            ++Count;

            return true;
        }
    
        /// <summary>
        /// Adds the specified item in the end of sequence.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        public void Add(T item)
        {
            Insert(Count, item);
        }
    
        /// <summary>
        /// Gets the index of item in sequence.
        /// </summary>
        /// <returns>The index of item.</returns>
        /// <param name="item">Item.</param>
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (Source[i].Equals(item))
                    return i;

            return -1;
        }
    
        /// <summary>
        /// Gets the index of item in sequence.
        /// </summary>
        /// <returns>The last index of item.</returns>
        /// <param name="item">Item.</param>
        public int LastIndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
                if (Source[i].Equals(item))
                    index = i;

            return index;
        }
    
        /// <summary>
        /// Clears this sequence.
        /// </summary>
        public void Clear()
        {
            Source = new T[Capacity];
            Count = 0;
        }
    
        /// <summary>
        /// Removes the item at index.
        /// </summary>
        /// <returns>The <see cref="T:System.Boolean"/>.</returns>
        /// <param name="index">Index.</param>
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count) return false;

            for (int i = index; i < Count; i++)
                Source[i] = Source[i + 1];

            --Count;
            return true;
        }
    
        /// <summary>
        /// Removes the item at index.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        public bool Remove(T item)
        {
            return RemoveAt(IndexOf(item));
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return Source[i];
        }
    
        /// <summary>
        /// Sorts this sequence.
        /// </summary>
        public void Sort()
        {
            Array.Sort(Source, 0, Count);
        }
    
        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="comparer">Comparer.</param>
        public void Sort(IComparer comparer)
        {
            Array.Sort(Source, 0, Count, comparer);
        }
    
        /// <summary>
        /// Reverses this instance.
        /// </summary>
        public void Reverse()
        {
            Array.Reverse(Source, 0, Count);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>The list.</returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();

            foreach (T obj in this)
                list.Add(obj);

            return list;
        }
    
        /// <summary>
        /// Gets the array.
        /// </summary>
        /// <returns>The array.</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
                array[i] = this[i];

            return array;
        }
    }
}
