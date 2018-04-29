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
                OnMyNewCollectionChange(Name, "Изменена ссылка на объект", value); 
            }
        }

        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DelegatesAndEvents.MyNewCollection"/> class and fills it.
        /// </summary>
        /// <param name="length">Length.</param>
        public MyNewCollection(int length, string name) : base(length) { Name = name; }
    
        /// <summary>
        /// Ons my new collection change.
        /// </summary>
        /// <param name="collectionName">Collection name.</param>
        /// <param name="changeDescription">Change description.</param>
        /// <param name="changedItem">Changed item.</param>
        protected virtual void OnMyNewCollectionChange(string collectionName, string changeDescription, Person changedItem)
        {
            Change?.Invoke(this, new MyNewCollectionEventArgs(collectionName, changeDescription, changedItem));
        }
    

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
        new public void Add(Person item)
        {
            Seq.Add(item);
            OnMyNewCollectionChange(Name, "Добавлен новый элемент: " + item.ToString(), item);
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
                OnMyNewCollectionChange(Name, "Удален элемент: " + item, item);
            else
                OnMyNewCollectionChange(Name, "Попытка удалить несуществующий элемент: " + item, item);

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
                OnMyNewCollectionChange(Name, "Добавлен новый элемент по индексу " + index + $": {item}", item);
            else 
                OnMyNewCollectionChange(Name, "Неудачная попытка добавить элемент по индексу " + index + $": {item}", item);

            return flag;
        }
    
        /// <summary>
        /// Clears this instance.
        /// </summary>
        new public void Clear()
        {
            Seq.Clear();
            OnMyNewCollectionChange(Name, "Песледовательно была очищена", new Student());
        }
    }

    public class MyNewCollectionEventArgs : EventArgs
    {
        public string ChangeDescription { get; private set; }   //is readonly
        public string CollectionName { get; private set; }      //is readonly
        public Person ChangedItem { get; private set; }         //is readonly

        public MyNewCollectionEventArgs(string collectionName, string changeDescription, Person changedItem)
        {
            CollectionName = collectionName;
            ChangeDescription = changeDescription;
            ChangedItem = changedItem;
        }

        public override string ToString() => $"{CollectionName} - {ChangedItem} : {ChangeDescription}";
    }
}
