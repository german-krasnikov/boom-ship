using UnityEngine;

namespace Code.Logic.Carousel
{
    public abstract class CarouselHelperUI<T> : MonoBehaviour
    {
        public readonly CarouselHelper<T> CarouselHelper = new CarouselHelper<T>();

        public void Init(T[] items)
        {
            CarouselHelper.Set(items);
        }

        public void OnEnable()
        {
            OnChanged(CarouselHelper.GetSelected());
            CarouselHelper.OnChange += OnChanged;
        }

        public void OnDisable()
        {
            CarouselHelper.OnChange -= OnChanged;
        }

        public void OnNextClick()
        {
            CarouselHelper.Next();
        }

        public void OnPrevClick()
        {
            CarouselHelper.Prev();
        }

        public T GetSelected()
        {
            return CarouselHelper.GetSelected();
        }

        protected abstract void OnChanged(T value);
    }
}