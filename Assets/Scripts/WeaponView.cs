using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellBtn;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellBtnClick; 

    private void OnEnable()
    {
        _sellBtn.onClick.AddListener(OnBtnClick);
        _sellBtn.onClick.AddListener(TryLogItem);
    }

    private void OnDisable()
    {
        _sellBtn.onClick.RemoveListener(OnBtnClick);
        _sellBtn.onClick.RemoveListener(TryLogItem);
    }

    private void TryLogItem()
    {
        Debug.Log(_weapon.IsBuyed);
        if (_weapon.IsBuyed == true)
            _sellBtn.interactable = false;
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void OnBtnClick()
    {
        SellBtnClick?.Invoke(_weapon, this);
    }
}
