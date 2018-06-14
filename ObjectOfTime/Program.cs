using System;

namespace ObjectOfTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Time m = new Time(120);
            Console.WriteLine(m);

            Time c = m - 70;
            Console.WriteLine(c);

            Time mc = new Time(120);
            Console.WriteLine(-mc);

            Time qwe = --m;
            Console.WriteLine(m);

            Time first = 560;
            Console.WriteLine(first);

            Console.WriteLine("{0} - {1}", mc, (bool)mc);

            Time a1 = 1440;
            Time a2 = 2880;
            Console.WriteLine(a1 == a2);
            Console.WriteLine(-a1 != -a2);
            Console.WriteLine();
        }
    }
}
