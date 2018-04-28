using System;
using Hierarchy;

namespace DelegatesAndEvents
{
    public class MyNewCollection : MyCollection
    {
        public delegate void MynewCollectionHandler(object sender, MyNewCollectionEventArgs e);
        public event MynewCollectionHandler Change;

        /// <summary>
        /// Gets or sets the <see cref="T:DelegatesAndEvents.MyNewCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        new public Person this[int index]
        {
            get => Seq[index];

            set {
                Seq[index] = value;
                OnMyNewCollectionChange("Изменена ссылка на объект"); 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DelegatesAndEvents.MyNewCollection"/> class and fills it.
        /// </summary>
        /// <param name="length">Length.</param>
        public MyNewCollection(int length) : base(length) { }
    
        /// <summary>
        /// Ons my new collection change.
        /// </summary>
        /// <param name="change">Change.</param>
        protected virtual void OnMyNewCollectionChange(string change)
        {
            Change?.Invoke(this, new MyNewCollectionEventArgs(change));
        }
    

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        new public void Add(Person item)
        {
            Seq.Add(item);
            OnMyNewCollectionChange("Добавлен новый элемент: " + item.ToString());
        }
    
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="item">Item.</param>
        new public bool Remove(Person item)
        {
            bool flag = Seq.Remove(item);

            if (flag)
                OnMyNewCollectionChange("Удален элемент: " + item);
            else
                OnMyNewCollectionChange("Попытка удалить несуществующий элемент: " + item);

            return flag;
        }
    
        /// <summary>
        /// Inserts the specified index and item.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        new public bool Insert(int index, Person item)
        {
            bool flag = Seq.Insert(index, item);

            if (flag)
                OnMyNewCollectionChange("Добавлен новый элемент по индексу " + index + $": {item}");
            else 
                OnMyNewCollectionChange("Неудачная попытка добавить элемент по индексу " + index + $": {item}");

            return flag;
        }
    
        /// <summary>
        /// Clears this instance.
        /// </summary>
        new public void Clear()
        {
            Seq.Clear();
            OnMyNewCollectionChange("Песледовательно была очищена");
        }
    }

    public class MyNewCollectionEventArgs : EventArgs
    {
        public string ChangeDescription { get; private set; } //is readonly

        public MyNewCollectionEventArgs(string changeDescription) { ChangeDescription = changeDescription; }
    }
}
