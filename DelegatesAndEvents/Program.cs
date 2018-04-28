using System;
using Hierarchy;
using Collection;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main()
        {
            void X(object sender, MyNewCollectionEventArgs e) {
                Console.WriteLine(e.ChangeDescription);
            }

            MyNewCollection seq = new MyNewCollection(20);
            seq.Change += X;

            seq.Add(Student.Generate());            // добавление элемента
            seq.Insert(12, Student.Generate());     // вставка элемента
            seq.Insert(100, Student.Generate());    // вставка элемента на недоступное место
            seq.Remove(seq[0]);                     // удаление элемента
            seq.Remove(Student.Generate());         // удаление несуществующего элемента
            seq.Clear();                            // очистка коллекции
        }
    }
}
