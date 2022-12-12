using System;
using System.Collections.Generic;
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
            ShipCarouselHelperOnOnChange(_shipCarousel.GetSelected());
        }

        public void OnEnable()
        {
            _shipCarousel.CarouselHelper.OnChange += ShipCarouselHelperOnOnChange;
        }

        public void OnDisable()
        {
            _shipCarousel.CarouselHelper.OnChange -= ShipCarouselHelperOnOnChange;
        }

        private void ShipCarouselHelperOnOnChange(ShipStaticData ship)
        {
            for (int i = 0; i < _moduleCarouselList.Length; i++)
                _moduleCarouselList[i].gameObject.SetActive(i < ship.ModuleCount);
        }

        public ShipStaticData GetSelectedShip()
        {
            return _shipCarousel.CarouselHelper.GetSelected();
        }

        public IEnumerable<WeaponStaticData> GetSelectedWeapons()
        {
            return _weaponCarouselList.Select(it => it.CarouselHelper.GetSelected());
        }

        public IEnumerable<ModuleStaticData> GetSelectedModules()
        {
            return _moduleCarouselList.Select(it => it.CarouselHelper.GetSelected());
        }
    }
}