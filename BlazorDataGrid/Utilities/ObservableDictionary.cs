using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace BlazorApps.BlazorDataGrid.Utilities
{
    public class ObservableDictionary<TKey, TValue> : IDictionary, INotifyCollectionChanged
        where TKey : notnull
    {
        public void Add(object key, object? value)
        {
            if (key is TKey k && value is TValue v)
            {
                _internalDict.Add(k, v);
                CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                        new KeyValuePair<TKey, TValue>(k, v)));
            }
        }

        public void Clear()
        {
            _internalDict.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(object key)
        {
            return key is TKey k && _internalDict.ContainsKey(k);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _internalDict.GetEnumerator();
        }

        public void Remove(object key)
        {
            if (key is TKey k)
            {
                var v = _internalDict[k];
                _internalDict.Remove(k);
                CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                        new KeyValuePair<TKey, TValue>(k, v)));
            }
        }

        public bool IsFixedSize => false;
        public bool IsReadOnly => false;

        public object? this[object key]
        {
            get
            {
                if (key is TKey k)
                {
                    return _internalDict[k];
                }

                return null;
            }
            set
            {
                if (key is TKey k && value is TValue v)
                {
                    _internalDict[k] = v;
                    CollectionChanged?.Invoke(this,
                        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                            new KeyValuePair<TKey, TValue>(k, v)));
                }
            }
        }

        public ICollection Keys => _internalDict.Keys;
        public ICollection Values => _internalDict.Values;

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
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public bool ContainsKey(TKey key)
        {
            return _internalDict.ContainsKey(key);
        }

        private readonly Dictionary<TKey, TValue> _internalDict = new();
    }
}