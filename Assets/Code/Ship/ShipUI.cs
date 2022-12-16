using System;
using Code.Health;
using Code.Ship;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipUI : MonoBehaviour
{
    public HPBarUI HPBar;
    public ShieldBarUI ShieldBar;
    public HealthBarUI HealthBar;
    public Transform[] GunPositions;

    private Ship _ship;

    public void Set(Ship ship)
    {
        _ship = ship;
        ship.Health.HP.Changed += InvalidateHP;
        ship.Health.Shield.Changed += InvalidateShield;
    }

    private void OnDestroy()
    {
        _ship.Health.HP.Changed -= InvalidateHP;
        _ship.Health.Shield.Changed -= InvalidateHP;
    }

    private void InvalidateHP()
    {
        var hp = _ship.Health.HP;
        HPBar.SetValue(hp.GetTotalHP(), hp.GetTotalMaxHP());
        InvalidateHealthBar();
    }

    private void InvalidateShield()
    {
        var shield = _ship.Health.Shield;
        ShieldBar.SetValue(shield.GetTotalShield(), shield.GetTotalMaxShield());
        InvalidateHealthBar();
    }

    private void InvalidateHealthBar()
    {
        HealthBar.SetValue(_ship.Health.HP.GetTotalHP(), _ship.Health.Shield.GetTotalShield());
    }
}