using System;
using System.Linq;

namespace ObjectOfTime
{
    public class TimeArray
    {
        Time[] times;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size
        {
            get => times.Length;

            set {
                if (value < 0) throw new ArgumentException();

                times = new Time[value];

                for (int i = 0; i < times.Length; i++)
                    times[i] = new Time();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:ObjectOfTime.TimeArray"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Time this[int index]
        {
            get {
                if (index < 0 || index > times.Length - 1) throw new IndexOutOfRangeException();

                return times[index];
            }

            set {
                if (index < 0 || index > times.Length - 1) throw new IndexOutOfRangeException();

                times[index] = value;
            }
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:ObjectOfTime.TimeArray"/> class.
        /// </summary>
        public TimeArray()
        {
            Size = 20;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ObjectOfTime.TimeArray"/> class.
        /// </summary>
        /// <param name="length">Length.</param>
        public TimeArray(int length)
        {
            Size = length;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ObjectOfTime.TimeArray"/> class.
        /// </summary>
        /// <param name="length">Length.</param>
        /// <param name="random">Koefficient.</param>
        public TimeArray(int length, Random random)
        {
            Size = length;

            foreach (Time i in times)
                i.Minutes = random.Next();
        }
    
        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <returns>The minimum.</returns>
        public int GetMin()
        {
            return times.Select(x => x.GetMinutes).Min();
        }
    }
}
