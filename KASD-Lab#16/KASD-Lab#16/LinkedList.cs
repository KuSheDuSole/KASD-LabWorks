using System.Collections;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace MyLinkedLIst
{
    internal class MyNode<T>
    {
        public MyNode<T>? Pred { get; set; }
        public T? Element { get; set; }
        public MyNode<T>? Next { get; set; }
        public MyNode()
        {
            Pred = null;
            Element = default;
            Next = null;
        }
        public MyNode(MyNode<T>? pred, T element, MyNode<T>? next)
        {
            Pred = pred;
            Element = element;
            Next = next;
        }
    }
    public class MyLinkedList<T>: IEnumerable<T>
    {
        MyNode<T>? first;
        MyNode<T>? last;
        int size = 0;

        public MyLinkedList()
        {
            first = null;
            last = null;
        }
        public MyLinkedList(T[] array)
        {
            if (array.Length == 0) { Console.WriteLine("Array is empty"); return; }
            for (int i = 0; i < array.Length; i++) Add(array[i]);
            size = array.Length;
        }
        public void Add(T element)
        {
            if (first == null)
            {
                MyNode<T> node = new MyNode<T>(null, element, null);
                first = last = node;
                size++;
                return;
            }
            MyNode<T> current = new MyNode<T>(last, element, null);
            last!.Next = current;
            last = current;
            size++;
        }
        public void AddAll(T[] array)
        {
            if (array.Length == 0) { Console.WriteLine("Array is empty"); return; }
            for (int i = 1; i < array.Length; i++) Add(array[i]);
            size += array.Length;
        }
        public void Clear()
        {
            first = last = null;
            size = 0;
        }
        public bool Contains(T element)
        {
            foreach (var obj in this) if (obj!.Equals(element)) return true;
            return false;
        }
        public bool ContainsAll(T[] array)
        {
            for (int i = 0; i < array.Length; i++) if (!Contains(array[i])) return false;
            return true;
        }
        public bool IsEmpty() => size == 0? true: false;
        public void Remove(T element)
        {
            MyNode<T>? predNode = null;
            MyNode<T>? currentNode = first;
            MyNode<T>? nextNode = null;
            while (currentNode != null && currentNode.Element != null)
            {
                nextNode = currentNode.Next;
                if (currentNode.Element.Equals(element))
                {
                    if (predNode != null && nextNode != null)
                    {
                        predNode.Next = nextNode;
                        nextNode.Pred = predNode;
                    }
                    else if (predNode == null && nextNode != null)
                    {
                        nextNode.Pred = null;
                        first = nextNode;
                    }
                    else if (predNode != null && nextNode == null)
                    {
                        predNode.Next = null;
                        last = predNode;
                    }
                    else if (predNode == null && nextNode == null) Clear();
                    size--;
                    break;
                }
                predNode = currentNode;
                currentNode = nextNode;
            }
        }
        public void RemoveAll(T[] array)
        {   if (!ContainsAll(array)) return;
            for (int i = 0; i < array.Length; i++) Remove(array[i]);
        }
        public void RetainAll(T[] array)
        {
            if (!ContainsAll(array)) return;
            for (int i = 0; i < array.Length; i++) if (!Contains(array[i])) Remove(array[i]);
        }
        public int Size() => size;
        public T[] ToArray()
        {
            T[] values = new T[size];
            int index = 0;
            foreach (var element in this) values[index++] = element;
            return values;
        }
        public T[] ToArray(T[] array)
        {
            if (array == null || array.Length < size) array = new T[size];
            return array = ToArray();
        }
        public void Add(int index, T element)
        {
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
            MyNode<T> node = new MyNode<T>(null, element, null);
            if (index == 0)
            {
                if (size > 0)
                {
                    node.Next = first;
                    first = node;
                }
                else Add(element);
            }
            else if (index == size) Add(element);
            else
            {
                MyNode<T>? current = first;
                for (int i = 0; i < index - 1; i++) current = current!.Next;
                current!.Next!.Pred = node;
                node.Next = current.Next;
                current.Next = node;
                node.Pred = current;
            }

        }
        public void AddAll(int index, T[] array)
        {
            for (int i = 0; i < array.Length; i++) Add(index++, array[i]);
        }
        public T? Get(int index)
        {
            if ((index < 0 || index > size)) throw new ArgumentOutOfRangeException();
            int ind = 0;
            foreach(var element in this)
            {
                if (ind == index) return element;
                ind++;
            }
            return default;
        }
        public int IndexOf(T element)
        {
            int index = 0;
            foreach(var obj in this)
            {
                if (obj!.Equals(element)) return index;
                index++;
            }
            return -1;
        }
        public int LastIndexOf(T element)
        {
            int index = 0;
            int indexOflast = -1;
            foreach(var obj in this)
            {
                if (obj!.Equals(element)) indexOflast = index;
                index++;
            }
            return indexOflast;
        }
        public T? RemoveByIndex(int index)
        {
            if ((index < 0 || index > size)) throw new ArgumentOutOfRangeException();
            T? result = Get(index);
            int ind = 0;
            MyNode<T>? predNode = null;
            MyNode<T>? currentNode = first;
            MyNode<T>? nextNode = null;
            while (currentNode != null && currentNode.Element != null)
            {
                nextNode = currentNode.Next;
                if (ind == index)
                {
                    if (predNode != null && nextNode != null)
                    {
                        predNode.Next = nextNode;
                        nextNode.Pred = predNode;
                    }
                    else if (predNode == null && nextNode != null)
                    {
                        nextNode.Pred = null;
                        first = nextNode;
                    }
                    else if (predNode != null && nextNode == null)
                    {
                        predNode.Next = null;
                        last = predNode;
                    }
                    else if (predNode == null && nextNode == null) Clear();
                    size--;
                    break;
                }
                predNode = currentNode;
                currentNode = nextNode;
                ind++;
            }
            return result;
        }
        public void Set(int index, T element)
        {
            MyNode<T>? currentNode = first;
            int ind = 0;
            while (currentNode != null && currentNode.Element != null)
            {
                if (ind == index)
                {
                    currentNode.Element = element;
                    return;
                }
                currentNode = currentNode.Next;
                ind++;
            }
        }
        public T[] SubList(int fromIndex, int toIndex)
        {
            T[] values = new T[toIndex - fromIndex];
            int index = 0;
            int valuesindex = 0;
            foreach(var element in this)
            {
                if (index >= fromIndex && index < toIndex) values[valuesindex++] = element;
                index++;
            }
            return values;
        }
        public T? Element() => first!.Element;
        public bool Offer(T element)
        {
            try
            {
                Add(element);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public T? Peek() => Element();
        public T? Poll() => RemoveByIndex(0);
        public void AddFirst(T element) => Add(0, element);
        public void AddLast(T element) => Add(size, element);
        public T? GetFirst() => Element();
        public T? GetLast() => last!.Element;
        public bool OfferFirst(T element)
        {
            try
            {
                AddFirst(element);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool OfferLast(T element)
        {
            try
            {
                AddLast(element);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public T? Pop() => Poll();
        public void Push(T element) => AddFirst(element);
        public T? PeekFirst() => GetFirst();
        public T? PeekLast() => GetLast();
        public T? PollFirst() => Poll();
        public T? PollLast() => RemoveByIndex(size - 1);
        public T? RemoveLast() => PollLast();
        public T? RemoveFirst() => PollFirst();
        public void RemoveFirstOccurrence(T element) => Remove(element);
        public void RemoveLastOccurrence(T element)
        {
            MyNode<T>? predNode = null;
            MyNode<T>? currentNode = last;
            MyNode<T>? nextNode = null;
            while (currentNode != null && currentNode.Element != null)
            {
                predNode = currentNode.Pred;
                nextNode = currentNode.Next;
                if (currentNode.Element.Equals(element))
                {
                    if (predNode != null && nextNode != null)
                    {
                        predNode.Next = nextNode;
                        nextNode.Pred = predNode;
                    }
                    else if (predNode == null && nextNode != null)
                    {
                        nextNode.Pred = null;
                        first = nextNode;
                    }
                    else if (predNode != null && nextNode == null)
                    {
                        predNode.Next = null;
                        last = predNode;
                    }
                    else if (predNode == null && nextNode == null) Clear();
                    size--;
                    break;
                }
                currentNode = predNode;
            }
        }
        public void Print()
        {
            foreach (var element in this) Console.WriteLine(element);
            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            MyNode<T>? current = first;
            while (current != null)
            {
                yield return current.Element!;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}