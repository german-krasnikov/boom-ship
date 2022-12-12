using System;

namespace Code.Logic.Carousel
{
    public class CarouselHelper<T>
    {
        public event Action<T> OnChange;
        private T[] _items;
        private int _index = 0;

        public void Set(T[] items)
        {
            _items = items;
            SetIndex(0);
        }

        public void SetIndex(int index)
        {
            _index = index;
            OnChange?.Invoke(_items[index]);
        }

        public void Next()
        {
            SetIndex(_index.GetNextSequenceNumber(_items.Length - 1, 0));
        }

        public void Prev()
        {
            SetIndex(_index.GetPrevSequenceNumber(_items.Length - 1, 0));
        }
    }
}