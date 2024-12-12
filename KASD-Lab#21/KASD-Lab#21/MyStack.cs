using MyVectorLib;
public class Project
{
    public class MyStack<T> : MyVector<T>
    {
        private MyVector<T> stack;
        private int top;
        public MyStack()
        {
            top = -1;
            stack = new MyVector<T>(1);
        }
        public void Push(T element)
        {
            stack.Add(element);
            top++;
        }
        public T Pop()
        {
            T element = stack.Get(top);
            stack.RemoveByIndex(top);
            top--;
            return element;
        }
        public T Peek()
        {
            return stack.Get(top);
        }
        public new bool IsEmpty()
        {
            return stack.IsEmpty();
        }
        public int Search(T item)
        {
            if (stack.IndexOf(item) == -1) return -1;
            return top - stack.IndexOf(item) + 1;
        }
        public new void Print()
        {
            stack.Print();
        }
    }
}