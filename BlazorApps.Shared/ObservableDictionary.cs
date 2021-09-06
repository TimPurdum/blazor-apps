using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BlazorApps.Shared
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, INotifyCollectionChanged
        where TKey : notnull
    {
        public void Add(TKey key, TValue value)
        {
            _internalDict.Add(key, value);
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                    new KeyValuePair<TKey, TValue>(key, value)));
        }

        public void Clear()
        {
            _internalDict.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(TKey key)
        {
            return _internalDict.ContainsKey(key);
        }

        public IEnumerable<TResult> Select<TResult>(Func<KeyValuePair<TKey, TValue>, TResult> selector)
        {
            return _internalDict.Select(selector);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _internalDict.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            var value = _internalDict[key];
            var result = _internalDict.Remove(key);
            if (result)
            {
                CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                    new KeyValuePair<TKey, TValue>(key, value)));
            }
            return result;
        }

        public bool IsFixedSize => false;
        public bool IsReadOnly => false;

        public TValue this[TKey key]
        {
            get
            {
                return _internalDict[key];
            }
            set
            {
                _internalDict[key] = value;
                CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                        new KeyValuePair<TKey, TValue>(key, value)));
            }
        }

        public ICollection<TKey> Keys => _internalDict.Keys;
        public ICollection<TValue> Values => _internalDict.Values;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count => _internalDict.Count;
        public bool IsSynchronized => true;
        public object SyncRoot { get; } = new();

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;

        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public bool ContainsKey(TKey key)
        {
            return _internalDict.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return _internalDict.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _internalDict.Add(item.Key, item.Value);
            CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _internalDict.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection)_internalDict).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var result = _internalDict.Remove(item.Key);
            CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            return result;
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return _internalDict.GetEnumerator();
        }

        private readonly Dictionary<TKey, TValue> _internalDict = new();
    }
}