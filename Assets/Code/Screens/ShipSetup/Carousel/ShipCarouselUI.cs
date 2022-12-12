using Code.Logic.Carousel;
using Code.StaticData;
using TMPro;
using UnityEngine;

namespace Code.Screens.ShipSetup.Carousel
{
    public class ShipCarouselUI : CarouselHelperUI<ShipStaticData>
    {
        [SerializeField]
        private TMP_Text _text;

        protected override void OnChanged(ShipStaticData value)
        {
            _text.text =
                $"{value.Name}\nHP: {value.HP}, Shield: {value.Shield}, Shield inc cooldown: {value.ShieldIncCooldown}, Shield inc value: {value.ShieldIncValue}";
        }
    }
}