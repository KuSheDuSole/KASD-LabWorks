using MyCollection;
using MyHashMapLib;
using MyInterfaces;
namespace MyHashSetLib
{
    public class MyHashSet<T>: MySet<T> where T: IComparable
    {
        public class MyItr : MyIterator<T>
        {
            public T? Cursor { get; set;}
            private int index;
            private MyHashSet<T> hashSet;
            private T[] array;
            public MyItr(MyHashSet<T> hash)
            {
                hashSet = hash;
                array = hashSet.ToArray();
                index = 0;
                if (array.Length != 0) Cursor = array[index];
                else Cursor = default;
            }
            public bool HasNext()
            {
                if ((index + 1) == array.Length || array.Length == 0) return false;
                return true;
            }
            public T? Next()
            {
                if (HasNext())
                {
                    Cursor = array[++index];
                    return Cursor;
                }
                return default;
            }
            public void Remove()
            {
                hashSet.Remove(Cursor!);
                array = hashSet.ToArray();
                index = 0;
                if (array.Length != 0) Cursor = array[index];
                else Cursor = default;
            }
        }
        public MyItr Iterator() => new MyItr(this);

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
        public T[] ToArray(T[] array)
        {
            if (array == null) return ToArray();
            return array = ToArray();

        }
        public T First()
        {
            T[] array = ToArray();
            return array[0];
        }
        public T Last()
        {
            T[] array = ToArray();
            return array[array.Length - 1];
        }
        public T[] SubSet(T fromElement, T Toelement)
        {
            T[] array = ToArray();
            MyHashSet<T> ret = new MyHashSet<T>();
            foreach (T obj in array)
                if ((obj.CompareTo(fromElement) == 0 || obj.CompareTo
                    (fromElement) > 0) && obj.CompareTo(Toelement) < 0) ret.Add(obj);
            T[] mas = ret.ToArray();
            return mas;

        }
        public T[] HeadSet(T fromElement)
        {
            MyHashSet<T> ret = new MyHashSet<T>();
            T[] arr = ToArray();
            foreach (T obj in arr)
                if (obj.CompareTo(fromElement) < 0) ret.Add(obj);
            T[] mas = ret.ToArray();
            return mas;
        }
        public T[] TailSet(T ToElement)
        {
            MyHashSet<T> ret = new MyHashSet<T>();
            T[] arr = ToArray();
            foreach (T obj in arr)
                if (obj.CompareTo(ToElement) > 0) ret.Add(obj);
            T[] mas = ret.ToArray();
            return mas;
        }
        public void Print()
        {
            T[] table = ToArray();
            foreach (var element in table) Console.WriteLine(element);
            Console.WriteLine();
        }
    }
}