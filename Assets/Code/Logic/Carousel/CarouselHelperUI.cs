using UnityEngine;

namespace Code.Logic.Carousel
{
    public class CarouselHelperUI<T> : MonoBehaviour
    {
        private CarouselHelper<T> _carouselHelper = new CarouselHelper<T>();

        public void Init(T[] items)
        {
            _carouselHelper.Set(items);
        }

        public void OnEnable()
        {
            _carouselHelper.OnChange += OnChanged;
        }

        public void OnDisable()
        {
            _carouselHelper.OnChange -= OnChanged;
        }

        public void OnNextClick()
        {
            _carouselHelper.Next();
        }

        public void OnPrevClick()
        {
            _carouselHelper.Prev();
        }

        protected virtual void OnChanged(T value)
        {
        }
    }
}