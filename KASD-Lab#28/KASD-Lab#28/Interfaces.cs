using MyTreeMapLib;

namespace MyCollection
{
    public interface MyCollection<T>
    {
        public void Add(T e);
        public void Clear();
        public bool Contains(T e);
        public void AddAll(T[] array);
        public bool ContainsAll(T[] a);
        public bool IsEmpty();
        public void Remove(T e);
        public void RemoveAll(T[] a);
        public void RetainAll(T[] a);
        public int Size();
        public T[] ToArray();
        public T[] ToArray(T[] a);
    }
    public interface MyList<T>: MyCollection<T>
    {
        public void Add(int index, T item);
        public void AddAll(int index, T[] a);
        public T Get(int index);
        public int IndexOf(T item);
        public int LastIndexOf(T item);
        public T RemoveByIndex(int index);
        public void Set(int index, T item);
        public T[] SubList(int start, int end);
    }
    public interface MyQueue<T> : MyCollection<T>
    {
        public T Element();
        public bool Offer(T item);
        public T Peek();
        public T Poll();

    }
    public interface MyDeQue<T> : MyCollection<T>
    {
        public void AddFirst(T item);
        public void AddLast(T item);
        public T GetFirst();
        public T GetLast();
        public bool OfferFirst(T item);
        public bool OfferLast(T item);
        public void Pop();
        public void Push(T item);
        public T PeekFirst();
        public T PollFirst();
        public T PeekLast();
        public T PollLast();
        public T RemoveLast();
        public T RemoveFirst();
        public bool RemoveLastOccurrence(T item);
        public bool RemoveFirstOccurrence(T item);
    }
    public interface MySet<K> : MyCollection<K>
    {
        public K First();
        public K Last();
        K[] SubSet(K fromElement, K Toelement);
        K[] HeadSet(K fromElement);
        K[] TailSet(K ToElement);
    }
    public interface MySortedSet<T> : MySet<T>
    {
        T[] SubSet(T fromElement, T Toelement);
        T[] HeadSet(T fromElement);
        T[] TailSet(T ToElement);
    }

    public interface MyNavigableSet<T> : MySortedSet<T>
    {
        T? LowerEntry(T key);
        T? FloorEntry(T key);
        T? HigherEntry(T key);
        T? CeilingEntry(T key);
        T? LowerKey(T key);
        T? FloorKey(T key);
        T? HigherKey(T key);
        T? CeilingKey(T key);
        T? PollFirstEntry();
        T? PollLastEntry();
        T? FirstEntry();
        T? LastEntry();
    }
    public interface MyMap<K, V>
    {
        void Clear();
        bool ContainsKey(K key);
        bool ContainsValue(V value);
        IEnumerable<KeyValuePair<K, V>> EntrySet();
        V Get(K Key);
        bool IsEmpty();
        K[] KeySet();
        void Put(K key, V value);
        void Remove(K key);
        int Size();
        void PutAll(MyMap<K, V> map);
        V[] Values();
    }
    public interface MySortedMap<K, V> : MyMap<K, V> where K : IComparable
    {
        public K First();
        public K Last();
        MyTreeMap<K, V> SubMap(K fromElement, K Toelement);
        MyTreeMap<K, V> HeadMap(K fromElement);
        MyTreeMap<K, V> TailMap(K ToElement);
    }
    public interface MyNavigableMap<K, V> : MySortedMap<K, V> where K : IComparable
    {
        IEnumerable<KeyValuePair<K, V>> LowerEntry(K key);
        IEnumerable<KeyValuePair<K, V>> FloorEntry(K key);
        IEnumerable<KeyValuePair<K, V>> HigherEntry(K key);
        IEnumerable<KeyValuePair<K, V>> CeilingEntry(K key);
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);
        K PollFirstEntry();
        K PollLastEntry();
        K FirstEntry();
        K? LastEntry();
    }
}