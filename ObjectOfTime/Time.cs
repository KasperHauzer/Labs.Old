using System;

namespace ObjectOfTime
{
    public class Time
    {
        int _minutes;
        int _hours;
        static int _itemsCount;

        /// <summary>
        /// Gets or sets the minutes.
        /// </summary>
        /// <value>The minutes.</value>
        public int Minutes 
        {
            get => _minutes;

            set {
                if (value < 0) throw new ArgumentException("A minutes can't be less than 0");

                Hours = value / 60;
                _minutes = value % 60;
            }
        }

        /// <summary>
        /// Gets or sets the hours.
        /// </summary>
        /// <value>The hours.</value>
        public int Hours
        {
            get => _hours;

            set {
                if (value < 0) throw new ArgumentException("A hours can't be less than 0");

                _hours = value % 24;
            }
        }

        /// <summary>
        /// Gets the minutes as is.
        /// </summary>
        /// <value>The get minutes.</value>
        public int GetMinutes
        {
            get => Hours * 60 + Minutes;

            private set {
                if (value < 0) throw new ArgumentException("A time can't be less than 0");

                Minutes = value;
            }
        }

        /// <summary>
        /// Gets the items count.
        /// </summary>
        /// <value>The items count.</value>
        public int ItemsCount
        {
            get => _itemsCount;

            private set {
                if (value < 0) _itemsCount = 0;

                _itemsCount = value;
            }
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="T:ObjectOfTime.Time"/> class.
        /// </summary>
        public Time()
        {
            Minutes = 0;
            Hours = 0;
            ++ItemsCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ObjectOfTime.Time"/> class.
        /// </summary>
        /// <param name="minutes">Minutes.</param>
        public Time(int minutes)
        {
            Minutes = minutes;
            ++ItemsCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ObjectOfTime.Time"/> class.
        /// </summary>
        /// <param name="hours">Hours.</param>
        /// <param name="minutes">Minutes.</param>
        public Time(int hours, int minutes)
        {
            Minutes = minutes;
            Hours = hours;
            ++ItemsCount;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:ObjectOfTime.Time"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ObjectOfTime.Time"/>.</returns>
        public override string ToString()
        {
            return Hours + " : " + Minutes;
        }
    
        /// <summary>
        /// Subtracts a <see cref="ObjectOfTime.Time"/> from a <see cref="int"/>, yielding a new <see cref="T:ObjectOfTime.Time"/>.
        /// </summary>
        /// <param name="time">The <see cref="ObjectOfTime.Time"/> to subtract from (the minuend).</param>
        /// <param name="value">The <see cref="int"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:ObjectOfTime.Time"/> that is the <c>time</c> minus <c>value</c>.</returns>
        public static Time operator -(Time time, int value)
        {
            return new Time(time.GetMinutes - value);
        }
    
        public static Time operator -(Time time)
        {
            time.GetMinutes = 0;

            return new Time();
        }

        public static Time operator --(Time time)
        {
            time.GetMinutes -= 1;

            return new Time(time.GetMinutes);
        }
    
        /// <summary>
        /// Ops the implicit.
        /// </summary>
        /// <returns>The implicit.</returns>
        /// <param name="value">Value.</param>
        public static implicit operator Time(int value)
        {
            return new Time(value);
        }
    
        /// <summary>
        /// Ops the explicit.
        /// </summary>
        /// <returns><c>true</c>, if explicit was oped, <c>false</c> otherwise.</returns>
        /// <param name="time">Time.</param>
        public static explicit operator bool(Time time)
        {
            return time.GetMinutes != 0;
        }
    
        /// <summary>
        /// Determines whether a specified instance of <see cref="ObjectOfTime.Time"/> is equal to another specified <see cref="ObjectOfTime.Time"/>.
        /// </summary>
        /// <param name="x">The first <see cref="ObjectOfTime.Time"/> to compare.</param>
        /// <param name="y">The second <see cref="ObjectOfTime.Time"/> to compare.</param>
        /// <returns><c>true</c> if <c>x</c> and <c>y</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Time x, Time y)
        {
            return x.GetMinutes == y.GetMinutes;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ObjectOfTime.Time"/> is not equal to another specified <see cref="ObjectOfTime.Time"/>.
        /// </summary>
        /// <param name="x">The first <see cref="ObjectOfTime.Time"/> to compare.</param>
        /// <param name="y">The second <see cref="ObjectOfTime.Time"/> to compare.</param>
        /// <returns><c>true</c> if <c>x</c> and <c>y</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Time x, Time y)
        {
            return x.GetMinutes != y.GetMinutes;
        }
    }
}
