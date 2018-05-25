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

            Console.WriteLine("1-автозаполнение, 2-ручное заполнение:");
            string ans = Console.ReadLine();

            if (ans == "1") {
                TimeArray timeArray = new TimeArray(20, new Random());

                for (int i = 0; i < timeArray.Size; i++)
                    Console.WriteLine(timeArray[i]);
            } else {
                TimeArray timeArray = new TimeArray(5);

                for (int i = 0; i < timeArray.Size; i++){
                    int a = 0;
                    while (!int.TryParse(Console.ReadLine(), out a) && a < 0)
                        Console.WriteLine("Введите целое положительное число!");

                    timeArray[i] = a;
                }

                for (int i = 0; i < timeArray.Size; i++)
                    Console.WriteLine(timeArray[i]);
            }
        }
    }
}
