using System;
using System.Linq;
using Code.Screens.ShipSetup.Carousel;
using Code.StaticData;
using UnityEngine;

namespace Code.Screens.ShipSetup
{
    public class ShipSetupPanelUI : MonoBehaviour
    {
        [SerializeField]
        private ShipCarouselUI _shipCarousel;
        [SerializeField]
        private WeaponCarouselUI[] _weaponCarouselList;
        [SerializeField]
        private ModuleCarouselUI[] _moduleCarouselList;

        public void Init(GameStaticData gameData)
        {
            _shipCarousel.Init(gameData.Ships);
            foreach (var weaponCarousel in _weaponCarouselList)
                weaponCarousel.Init(gameData.Weapons);
            foreach (var moduleCarousel in _moduleCarouselList)
                moduleCarousel.Init(gameData.Modules);
        }

        public void OnEnable()
        {
            _shipCarousel._carouselHelper.OnChange += ShipCarouselHelperOnOnChange;
        }

        public void OnDisable()
        {
            _shipCarousel._carouselHelper.OnChange -= ShipCarouselHelperOnOnChange;
        }

        private void ShipCarouselHelperOnOnChange(ShipStaticData ship)
        {
            for (int i = 0; i < _moduleCarouselList.Length; i++)
                _moduleCarouselList[i].gameObject.SetActive(i < ship.ModuleCount);
        }
    }
}