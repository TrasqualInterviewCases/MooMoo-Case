using System;
using UnityEngine;

public class WeaponHandler : ItemHandler<WeaponBase>
{
    public event Action OnWeaponEquipped;
    public event Action OnWeaponDropped;

    [SerializeField] private Transform weaponHolder;

    private WeaponBase currentWeapon;

    public override void PickUpItem(WeaponBase weapon)
    {
        if (currentWeapon != null) DropItem();
        currentWeapon = weapon;
        currentWeapon.transform.SetParent(weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
        OnWeaponEquipped?.Invoke();
    }

    public override void DropItem()
    {
        if (currentWeapon == null) return;

        currentWeapon.GetDropped();
        currentWeapon = null;
        OnWeaponDropped?.Invoke();
    }
}
