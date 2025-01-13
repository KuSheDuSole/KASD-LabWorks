using MyCollection;
namespace MyHashMapLib
{
    public class MyHashMap<K, V>: MyMap<K, V>
    {
        private class Entry
        {
            public K key { get; set; }
            public V value { get; set; }
            public Entry? next { get; set; }
            public Entry(K key, V value)
            {
                this.key = key;
                this.value = value;
                next = null;
            }
        }
        private Entry[] table;
        int size = 0;
        double loadFactor;
        public MyHashMap(int initialCapacity, double loadFactor)
        {
            table = new Entry[initialCapacity];
            this.loadFactor = loadFactor;
        }
        public MyHashMap() : this(16, 0.75) { }
        public MyHashMap(int initialCapacity) : this(initialCapacity, 0.75) { }
        public void Clear()
        {
            Array.Clear(table);
            size = 0;
        }
        public int GetHashCode(K element) => element!.GetHashCode();
        public int GetHashCode(V element) => element!.GetHashCode();
        public bool ContainsKey(K key)
        {
            int index = Math.Abs(GetHashCode(key)) % table.Length;
            Entry entry = table[index];
            while(entry != null)
            {
                if (entry.key!.Equals(key)) return true;
                entry = entry.next!;
            }
            return false;
        }
        public bool ContainsValue(V value)
        {
            foreach (var element in table)
            {
                for (var step = element; step != null; step = step.next)
                    if (step.value!.Equals(value))return true;
            }
            return false;
        }
        public V? Get(K key)
        {
            int index = Math.Abs(GetHashCode(key)) % table.Length;
            Entry entry = table[index];
            while (entry != null)
            {
                if (entry.key!.Equals(key)) return entry.value;
                entry = entry.next!;
            }
            return default;
        }
        public bool IsEmpty() => size == 0;
        public K[] keySet()
        {
            K[] array = new K[size];
            int index = 0;
            foreach (var element in table)
            {
                for (var step = element; step != null; step = step.next)
                    array[index++] = step.key;
            }
            return array;
        }
        public int Size() => size;
        public void Put(K key, V value) 
        {
            if (size / (float)table.Length >= loadFactor) 
                Resize();
            Entry pair = new Entry(key, value);
            int index = Math.Abs(GetHashCode(key)) % table.Length;
            Entry entry = table[index];
            if (entry == null) {
                table[index] = pair;
                size++;
                return;
            }
            while(entry != null)
            {
                if (GetHashCode(entry.key).Equals(GetHashCode(key)))
                    if (entry.key!.Equals(key)) {
                        entry.value = value;
                        return;
                    }
                if (entry.next == null)
                {
                    entry.next = pair;
                    size++;
                    return;
                }
                entry = entry.next!;
            }
        }
        public void Resize()
        {
            Entry[] newTable = new Entry[table.Length * 2 + 1];
            foreach (var element in table)
            {
                for (var step = element; step != null; step = step.next)
                {
                    Entry pair = new Entry(step.key, step.value);
                    int index = Math.Abs(GetHashCode(pair.key)) % newTable.Length;
                    Entry entry = newTable[index];
                    if (entry == null) newTable[index] = pair;
                    while (entry != null)
                    {
                        if (entry.next == null)
                        {
                            entry.next = pair;
                            return;
                        }
                        entry = entry.next;
                    }
                }
            }
            table = newTable;
        }
        public void Remove(K key)
        {
            int index = Math.Abs(GetHashCode(key)) % table.Length;
            Entry entry = table[index];
            if (entry == null) throw new ArgumentException("Данного ключа не обнаружено");
            if (entry.key!.Equals(key))
            {
                table[index] = entry.next!;
                size--;
                return;
            }
            while (entry.next != null)
            {
                if (entry.next.key!.Equals(key))
                {
                    entry.next = entry.next.next;
                    size--;
                    return;
                }
                entry = entry.next;
            }
        }
        public IEnumerable<KeyValuePair<K, V>> EntrySet()
        {
            foreach (var entry in table)
            {
                for (var step = entry; step != null; step = step.next)
                    yield return new KeyValuePair<K, V>(step.key, step.value);
            }
        }
        public void PutAll(MyMap<K, V> map)
        {
            IEnumerable<KeyValuePair<K, V>> Pair = map.EntrySet();
            foreach (var pair in Pair)
            {
                K key = pair.Key;
                V value = pair.Value;
                Put(key, value);
            }
        }
        public V[] Values()
        {
            IEnumerable<KeyValuePair<K, V>> Pair = EntrySet();
            V[] fin = new V[size];
            int ind = 0;
            foreach (var pair in Pair)
            {
                fin[ind++] = pair.Value;
            }
            return fin;
        }
        public K[] KeySet()
        {
            K[] arrayRet = new K[size];
            int index = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    Entry step = table[i];

                    while (step != null)
                    {
                        arrayRet[index] = step.key;
                        index++;
                        step = step.next;
                    }
                }
            }
            return arrayRet;
        }
        public void Print()
        {
            int index = 0;
            foreach (var element in table)
            {
                Console.WriteLine($"[{index++}]:");
                for (var step = element; step != null; step = step.next)
                    Console.WriteLine($"\t <{step.key}, {step.value}>");
            }
            Console.WriteLine();
        }
    }
    
}