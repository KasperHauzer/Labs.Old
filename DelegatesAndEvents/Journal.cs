using Hierarchy;
using Collection;

namespace DelegatesAndEvents
{
    public class Journal
    {
        Sequence<JournalEntry> list = null;

        public Journal()
        {
            list = new Sequence<JournalEntry>();
        }

        public void MyNewCollection_Change(object sender, MyNewCollectionEventArgs e)
        {
            list.Add(new JournalEntry(e.CollectionName, e.ChangeDescription, e.ChangedItem));
        }

        public override string ToString()
        {
            string report = string.Empty;

            for (int i = 0; i < list.Count; i++)
                report += list[i] + "\n";

            return report;
        }
    }

    class JournalEntry
    {
        public string CollectionName { get; private set; } //is readonly
        public string ChangeDescription { get; private set; } //is readonly
        public Person ChangedItem { get; private set; } //is readonly

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DelegatesAndEvents.JournalEntry"/> class.
        /// </summary>
        /// <param name="collectionName">Collection name.</param>
        /// <param name="changeDescription">Change description.</param>
        /// <param name="changedItem">Changed item.</param>
        public JournalEntry(string collectionName, string changeDescription, Person changedItem)
        {
            CollectionName = collectionName;
            ChangeDescription = changeDescription;
            ChangedItem = changedItem;
        }

        public override string ToString() => $"{CollectionName} - {ChangeDescription}";
    }
}
