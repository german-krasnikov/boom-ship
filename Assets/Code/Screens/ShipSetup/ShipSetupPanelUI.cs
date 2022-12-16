using System.Collections.Generic;
using System.Linq;
using Code.Screens.ShipSetup.Carousel;
using Code.StaticData;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Screens.ShipSetup
{
    public class ShipSetupPanelUI : MonoBehaviour
    {
        [FormerlySerializedAs("_shipCarousel")]
        [SerializeField]
        private ShipBaseCarouselUI shipBaseCarousel;
        [SerializeField]
        private WeaponBaseCarouselUI[] _weaponCarouselList;
        [SerializeField]
        private ModuleBaseCarouselUI[] _moduleCarouselList;

        public void Init(GameStaticData gameData)
        {
            shipBaseCarousel.Init(gameData.Ships);
            foreach (var weaponCarousel in _weaponCarouselList)
                weaponCarousel.Init(gameData.Weapons);
            foreach (var moduleCarousel in _moduleCarouselList)
                moduleCarousel.Init(gameData.Modules);
            ShipCarouselHelperOnOnChange(shipBaseCarousel.GetSelected());
        }

        public void OnEnable()
        {
            shipBaseCarousel.CarouselHelper.OnChange += ShipCarouselHelperOnOnChange;
        }

        public void OnDisable()
        {
            shipBaseCarousel.CarouselHelper.OnChange -= ShipCarouselHelperOnOnChange;
        }

        private void ShipCarouselHelperOnOnChange(ShipStaticData ship)
        {
            for (int i = 0; i < _moduleCarouselList.Length; i++)
                _moduleCarouselList[i].gameObject.SetActive(i < ship.ModuleCount);
        }

        public ShipStaticData GetSelectedShip()
        {
            return shipBaseCarousel.CarouselHelper.GetSelected();
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