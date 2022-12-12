using Code.Logic.Carousel;
using Code.StaticData;
using TMPro;
using UnityEngine;

namespace Code.Screens.ShipSetup.Carousel
{
    public class WeaponCarouselUI : CarouselHelperUI<WeaponStaticData>
    {
        [SerializeField]
        private TMP_Text _text;

        protected override void OnChanged(WeaponStaticData value)
        {
            _text.text = $"{value.Name} -- Damage: {value.Damage}, Cooldown: {value.Cooldown}, Bullet time: {value.BulletTime}";
        }
    }
}