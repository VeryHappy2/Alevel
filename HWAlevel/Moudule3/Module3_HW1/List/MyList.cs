using System.Collections;

namespace Module3_HW1.List
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size;

        public void Add(T item)
        {
            int index = _size;
            Array.Resize(ref _array, _size + 1);

            _array[index] = item;
            _size += 1;
        }

        public void SetDefaultAt(int index)
        {
            Array.Clear(_array, index, 1);
            _array[index] = default;
        }

        public void Sort()
        {
            Array.Sort(_array);
        }

        public int Count()
        {
            return _array.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}