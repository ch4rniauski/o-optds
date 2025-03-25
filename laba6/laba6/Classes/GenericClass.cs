namespace laba6.Classes
{
    class GenericClass<T> where T : class
    {
        private List<T> _list;

        public GenericClass(int n)
        {
            _list = new(n);
        }

        public void AddElem(T elem)
        {
            _list.Add(elem);
        }

        public T GetByIndex(int index)
        {
            return _list[index];
        }

        public int FindItem(T obj)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i] == obj)
                    return i;
            }

            return -1;
        }

        public T Min()
        {
            return _list.Min()!;
        }

        public T Max()
        {
            return _list.Max()!;
        }

        public void Sort()
        {
            _list.Sort();
        }
    }
}
