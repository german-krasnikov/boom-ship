using Code.Logic.Carousel;
using Code.StaticData;
using TMPro;
using UnityEngine;

namespace Code.Screens.ShipSetup.Carousel
{
    public class ModuleCarouselUI : CarouselHelperUI<ModuleStaticData>
    {
        [SerializeField]
        private TMP_Text _text;

        protected override void OnChanged(ModuleStaticData value)
        {
            _text.text = value.Name;
        }
    }
}