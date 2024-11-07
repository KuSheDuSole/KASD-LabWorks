using MyListLib;


namespace MyHeapLib
{
    public class MyHeap<T> where T: IComparable<T>
    {
        private MyArrayList<T> heap = new MyArrayList<T>();

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = heap.Get(firstIndex);
            heap.Set(firstIndex, heap.Get(secondIndex));
            heap.Set(secondIndex, temp);
        }
        public MyHeap(T[] array)
        {
            heap.AddAll(array);
            for (int i = heap.Size() / 2; i >= 0; i--) Heapify(i);
        }
        public void Add(T item)
        {
            heap.Add(item);
            int i = heap.Size() - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && heap.Get(parent).CompareTo(heap.Get(i)) < 0)
            {
                Swap(i, parent);
                i = parent;
                parent = (i - 1) / 2;
            }
        }
        public void Heapify(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            while (true)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;
                if (leftChild < heap.Size() && heap.Get(leftChild).CompareTo(heap.Get(largestChild)) > 0) largestChild = leftChild;
                if (rightChild < heap.Size() && heap.Get(rightChild).CompareTo(heap.Get(largestChild)) > 0) largestChild = rightChild;
                if (largestChild == i) break;
                Swap(i, largestChild);
                i = largestChild;
            }
        }
        public void GetMax() => heap.Get(heap.Size() - 1);
        public T GetAndDelMax()
        {
            if (heap.IsEmpty()) throw new Exception("Heap is empty");
            T maxElement = heap.Get(0);
            if (heap.Size() == 1)
            {
                heap.RemoveByIndex(heap.Size() - 1);
                return maxElement;
            }
            Swap(0, heap.Size() - 1);
            heap.RemoveByIndex(heap.Size() - 1);
            Heapify(0);
            return maxElement;
        }
        public void KeyIncr(int index, T e)
        {
            if (index > heap.Size() - 1) throw new IndexOutOfRangeException();
            heap.Set(index, e);
            for (int i = heap.Size() / 2; i >= 0; i--) Heapify(i);
        }
        public int Size() => heap.Size();

        public void MergeHeaps(MyHeap<T> newHeap)
        {
            while (newHeap.Size() != 0)
            {
                T element = newHeap.GetAndDelMax();
                Add(element);
            }
        }
        public void Print()
        {
            for (int i = 0; i < heap.Size(); i++) Console.Write(heap.Get(i) + "\n");
        }
    }
    class Project
    {
        static void Main(string[] args)
        {
            int[] mas = { 2, 10, 4, 11, 6, 9 };
            int[] mas1 = { 14, 57, 89 };
            MyHeap<int> hp = new MyHeap<int>(mas);
            MyHeap<int> hp1 = new MyHeap<int>(mas1);
            //hp.GetAndDelMax();
            hp.MergeHeaps(hp1);
            hp.Print();
        }
    }
}