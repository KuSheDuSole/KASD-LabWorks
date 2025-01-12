using MyInterfaces;
using MyVectorLib;

namespace MyListLib
{
    public class MyArrayList<T>
    {
        public class MyItr : MyListIterator<T>
        {
            public T? Cursor { get; set; }
            private int index;
            private MyArrayList<T> arrayList;
            private T[] array;
            public MyItr(MyArrayList<T> newArrayList)
            {
                arrayList = newArrayList;
                array = arrayList.ToArray();
                index = 0;
                if (array.Length != 0) Cursor = array[index];
                else Cursor = default;
            }
            public MyItr(MyArrayList<T> newArrayList, int index)
            {
                arrayList = newArrayList;
                array = arrayList.ToArray();
                this.index = index;
                if (array.Length != 0 && index < array.Length) Cursor = array[index];
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
                arrayList.Remove(Cursor!);
                array = arrayList.ToArray();
                index = 0;
                if (array.Length != 0) Cursor = array[index];
                else Cursor = default;
            }
            public bool HasPrevious()
            {
                if ((index == 0) || array.Length == 0) return false;
                return true;
            }
            public T? Previous()
            {
                if (HasPrevious())
                {
                    Cursor = array[--index];
                    return Cursor;
                }
                return default;
            }
            public int? NextIndex()
            {
                if (HasNext()) return index + 1;
                return default;
            }
            public int? PreviousIndex()
            {
                if (HasPrevious()) return index - 1;
                return default;
            }
            public void Set(T element)
            {
                arrayList.Set(index, element);
            }
            public void Add(T element)
            {
                arrayList.Add(index, element);
                array = array.ToArray();
            }
        }
        public MyItr Iterator() => new MyItr(this);
        public MyItr Iterator(int index) => new MyItr(this, index);

        private int size;
        private T[] elementData;
        public MyArrayList()
        {
            size = 0;
            elementData = new T[1];
        }
        public MyArrayList(T[] array)
        {
            size = array.Length;
            elementData = new T[size];
            for (int i = 0; i < size; i++) elementData[i] = array[i];
        }
        public MyArrayList(int capacity)
        {
            size = 0;
            elementData = new T[capacity];
        }
        public void Add(T element)
        {
            if (size == elementData.Length) Resize();
            elementData[size++] = element;
        }
        public void AddAll(T[] array)
        {
            int j = size;
            while (size + array.Length > elementData.Length) Resize();
            for (int i = 0; i < array.Length; i++) elementData[j++] = array[i];
            size += array.Length;
        }
        public void Resize()
        {
            T[] newArray = new T[elementData.Length * (3 / 2) + 1];
            for (int i = 0; i < elementData.Length; i++) newArray[i] = elementData[i];
            Array.Clear(elementData);
            elementData = newArray;
        }
        public void Clear()
        {
            Array.Clear(elementData);
            size = 0;
        }
        public bool Contains(T obj)
        {
            foreach (T member in elementData) if (member.Equals(obj)) return true;
            return false;
        }
        public bool ContainsAll(T[] array)
        {
            bool flag = true;
            foreach (T checkMember in array)
                if (flag)
                {
                    flag = false;
                    foreach (T member in elementData)
                        if (checkMember.Equals(member))
                        {
                            flag = true;
                            break;
                        }
                }
                else break;
            return flag;
        }
        public bool IsEmpty()
        {
            if (size == 0) return true;
            return false;
        }
        public void Remove(T obj)
        {
            for (int i = 0; i < elementData.Length; i++)
                if (elementData[i].Equals(obj))
                {
                    for (int j = i; j < elementData.Length - 1; j++) elementData[j] = elementData[j + 1];
                    size--;
                    Array.Resize(ref elementData, size);
                    return;
                }
            Console.WriteLine($"Элемента {obj} нет в динамическом массиве");
        }
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > size) throw new Exception("Please, enter correct index");
            for (int j = index; j < elementData.Length - 1; j++) elementData[j] = elementData[j + 1];
            size--;
            Array.Resize(ref elementData, size);
            return;
        }
        public void RemoveAll(T[] array)
        {
            foreach (T member in array) Remove(member);
        }
        public void RetainAll(T[] array)
        {
            T[] arrayCopy = new T[elementData.Length];
            for (int i = 0; i < elementData.Length; i++) arrayCopy[i] = elementData[i];
            bool flag = true;
            if (!ContainsAll(array))
            {
                Console.WriteLine("Какие-то элементы не присутствуют в массиве");
                return;
            }
            foreach (T member in arrayCopy)
            {
                foreach (T retainMember in array)
                    if (member.Equals(retainMember))
                    {
                        flag = false;
                        break;
                    }
                if (flag == true) Remove(member);
                flag = true;
            }
            Array.Clear(arrayCopy);
        }
        public int Size()
        {
            return size;
        }
        public T[] ToArray()
        {
            T[] newArray = new T[size];
            for (int i = 0; i < size; i++) newArray[i] = elementData[i];
            return newArray;
        }
        public T[] ToArray(T[] array)
        {
            if (array.Length < size)
            {
                Console.WriteLine("В массиве недостаточно элементов, для хранения элементов динамического массива");
                return array;
            }
            if (array == null) array = new T[size];
            for (int i = 0; i < size; i++) array[i] = elementData[i];
            return array;
        }
        public void Add(int index, T element)
        {
            if (index < 0 || index > size) throw new Exception("Please, enter correct index");
            if (size == elementData.Length) Resize();
            for (int i = size - 1; i >= index; i--) elementData[i + 1] = elementData[i];
            elementData[index] = element;
            size++;
        }
        public void AddAll(int index, T[] array)
        {
            if (index < 0 || index > size) throw new Exception("Please, enter correct index");
            int j = 0;
            while (size + array.Length > elementData.Length) Resize();
            for (int i = size - 1; i >= index; i--) elementData[i + array.Length] = elementData[i];
            for (int i = index; i < index + array.Length; i++) elementData[i] = array[j++];
            size += array.Length;
        }
        public T Get(int index)
        {
            if (index < 0 || index > size) throw new Exception("Please, enter correct index");
            return elementData[index];
        }
        public int IndexOf(T obj)
        {
            for (int i = 0; i < size; i++) if (elementData[i].Equals(obj)) return i;
            return -1;
        }
        public int LastIndexOf(T obj)
        {
            for (int i = size - 1; i <= 0; i--) if (elementData[i].Equals(obj)) return i;
            return -1;
        }

        public void Set(int index, T element)
        {
            if (index < 0 || index > size) throw new Exception("Please, enter correct index");
            elementData[index] = element;
        }
        public T[] SubList(int fromIndex, int toIndex)
        {
            int j = 0;
            if (fromIndex < 0 || fromIndex > size) throw new Exception("Please, enter correct start index");
            if (toIndex < 0 || toIndex > size) throw new Exception("Please, enter correct end index");
            T[] newArray = new T[toIndex - fromIndex];
            for (int i = fromIndex; i < toIndex; i++) newArray[j++] = elementData[i];
            return newArray;
        }
        public void Print()
        {
            if (size != 0)
                for (int i = 0; i < size; i++) Console.Write(elementData[i] + " ");
            Console.WriteLine();
        }
    }
}