using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] Transform weaponHolder;

    private WeaponBase currentWeapon;

    public void PickUpWeapon(WeaponBase weapon)
    {
        if (currentWeapon != null) DropWeapon();
        currentWeapon = weapon;
        currentWeapon.transform.SetParent(weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
    }

    public void DropWeapon()
    {
        currentWeapon.GetDropped();
        currentWeapon = null;
    }
}
