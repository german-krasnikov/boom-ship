using System;
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
            var description = "";
            switch (value.Type)
            {
                case ModuleType.SpeedupReloadWeapon:
                    description = $"-{value.Value}%";
                    break;
                case ModuleType.AdditionalHP:
                    description = $"+{value.Value} HP";
                    break;
                case ModuleType.AdditionalShield:
                    description = $"+{value.Value} Shield";
                    break;
                case ModuleType.SpeedupRestoreShield:
                    description = $"+{value.Value}%";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _text.text = $"{value.Name} -- {value.Type} {description}";
        }
    }
}