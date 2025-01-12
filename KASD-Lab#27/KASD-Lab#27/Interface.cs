namespace MyInterfaces
{
    public interface MyIterator<T>
    {
        public T? Cursor { get; set; }
        public bool HasNext();
        public T? Next();
        public void Remove();
    }
    public interface MyListIterator<T>
    {
        public T? Cursor { get; set; }
        public bool HasNext();
        public T? Next();
        public void Remove();
        public bool HasPrevious();
        public T? Previous();
        public int? NextIndex();
        public int? PreviousIndex();
        public void Set(T element);
        public void Add(T element);
    }
}