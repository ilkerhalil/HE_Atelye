using System.Collections;
using System.Collections.Generic;

namespace CommonMailLibrary.Interfaces {

    public class MailAddressCollection : ICollection<MailAddress> {
        private readonly List<MailAddress> _collection;
        public MailAddressCollection() {
            _collection = new List<MailAddress>();
        }

        public IEnumerator<MailAddress> GetEnumerator() {
            var enumerator = _collection.GetEnumerator();
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public virtual MailAddress this[int index] {
            get { return (MailAddress)_collection[index]; }
            set { _collection[index] = value; }
        }

        public void Add(MailAddress item) {
            _collection.Add(item);
        }

        public void Clear() {
            _collection.Clear();
        }

        public bool Contains(MailAddress item) {
            return _collection.Contains(item);
        }

        public void CopyTo(MailAddress[] array, int arrayIndex) {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(MailAddress item) {
            return _collection.Remove(item);
        }

        public int Count => _collection.Count;

        public bool IsReadOnly => false;
    }
}