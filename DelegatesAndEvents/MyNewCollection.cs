using System;

namespace DelegatesAndEvents
{
    public delegate void Method();

    public class MyNewCollection : MyCollection
    {
        public MyNewCollection(int length) : base(length)
        {
        }


    }
}
