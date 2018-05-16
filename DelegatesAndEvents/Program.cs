using System;
using Hierarchy;
using Collection;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main()
        {
            Random R = new Random();
            Journal journalA = new Journal();
            Journal journalB = new Journal();
            MyNewCollection seq = new MyNewCollection(20, "seq");
            MyNewCollection lis = new MyNewCollection(20, "lis");
            seq.CountChange += journalA.MyNewCollection_Change;
            seq.ReferenceChange += journalA.MyNewCollection_Change;
            seq.ReferenceChange += journalB.MyNewCollection_Change;
            lis.ReferenceChange += journalB.MyNewCollection_Change;


            for (int i = 0; i < 20; i++)
                switch (R.Next() % 3) {
                case 0: seq.Add(Student.Generate());  lis.Add(Student.Generate());  break; 
                case 1: seq.Add(Employee.Generate()); lis.Add(Employee.Generate()); break;
                case 2: seq.Add(Teacher.Generate());  lis.Add(Teacher.Generate());  break;
            }

            seq.Insert(10, Student.Generate());
            lis.Insert(10, Student.Generate());
            seq.Insert(-1, Student.Generate());
            lis.Insert(-1, Student.Generate());
            seq.Remove(seq[10]);
            lis.Remove(lis[10]);
            lis.Remove(Student.Generate());
            seq.Remove(Student.Generate());
            seq[10] = Student.Generate();
            lis[10] = Student.Generate();
            seq.Clear();
            lis.Clear();

            Console.WriteLine(journalA);
            Console.WriteLine("\n\n" + journalB);
        }
    }
}
