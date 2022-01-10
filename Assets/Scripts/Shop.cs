using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemConteiner;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    public void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemConteiner.transform);

        view.SellBtnClick += OnSellBtnClick;
        view.Render(weapon);

    }

    private void OnSellBtnClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            Debug.Log("dsads");
            view.SellBtnClick -= OnSellBtnClick;
        }
    }
}
