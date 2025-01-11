using MyHashMapLib;
namespace MyHashSetLib
{
    public class MyHashSet<T> where T: IComparable
    {
        MyHashMap<T, object> map;
        public MyHashSet() => map = new MyHashMap<T, object>();
        public MyHashSet(T[] array)
        {
            map = new MyHashMap<T, object>(array.Length);
            foreach(T element in array) map.Put(element, true);
        }
        public MyHashSet(int initialCapacity, float loadFactor) => map = new MyHashMap<T, object>(initialCapacity, loadFactor);
        public MyHashSet(int initialCapacity) => map = new MyHashMap<T, object>(initialCapacity);
        public void Add(T item) => map.Put(item, true);
        public void AddAll(T[] array)
        {
            foreach (T element in array) map.Put(element, true);
        }
        public void Clear() => map.Clear();
        public bool Contains(T element) => map.ContainsKey(element);
        public bool ContainsAll(T[] array)
        {
            foreach (T element in array) if (!map.ContainsKey(element)) return false;
            return true;
        }
        public bool IsEmpty() => map.IsEmpty();
        public void Remove(T element) => map.Remove(element);
        public void RemoveAll(T[] array)
        {
            foreach(T element in array) map.Remove(element);
        }
        public void RetainAll(T[] array)
        {
            T[] keys = map.keySet();
            foreach(T element in keys) if (!array.Contains(element)) map.Remove(element);
        }
        public int Size() => map.Size();
        public T[] ToArray() => map.keySet();
        public T[] ToArray(ref T[] array)
        {
            if (array == null) return ToArray();
            return array = ToArray();

        }
        public void Print()
        {
            T[] table = ToArray();
            foreach (var element in table) Console.WriteLine(element);
            Console.WriteLine();
        }
    }
}