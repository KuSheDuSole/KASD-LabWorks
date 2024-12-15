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
    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        MyHashSet<int> array = new MyHashSet<int>();
    //        array.Add(1);
    //        array.Add(2);
    //        array.Add(3);
    //        array.Add(4);
    //        array.Add(5);
    //        array.Add(7);
    //        array.Add(1);
    //        array.Add(90);
    //        array.Add(6);
    //        array.Add(7);
    //        array.Add(8);
    //        array.Add(9);
    //        array.Remove(6);
    //        array.Add(10);
    //        array.Add(11);
    //        array.Add(12);
    //        array.Add(13);
    //        array.Add(14);
    //        array.Add(15);
    //        array.Print();
    //    }
    //}
}