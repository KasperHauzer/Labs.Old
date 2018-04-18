using System;
using Hierarchy;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main()
        {
            MyCollection list = new MyCollection(100);
            Person[] array = new Person[100];

            list.CopyTo(array, 0);

            try {
                Console.WriteLine(list[100]);
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine(list[99]);
                list.Remove(list[99]);
            }
        }
    }
}
