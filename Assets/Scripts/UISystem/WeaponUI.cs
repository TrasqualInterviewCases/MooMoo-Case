using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] WeaponHandler weaponHandler;
    [SerializeField] GameObject buttons;


    private void ActivateWeaponUI()
    {
        buttons.SetActive(true);
    }

    private void DeactivateWeaponUI()
    {
        buttons.SetActive(false);
    }

    private void OnEnable()
    {
        weaponHandler.OnWeaponEquipped += ActivateWeaponUI;
        weaponHandler.OnWeaponDropped += DeactivateWeaponUI;
    }

    private void OnDisable()
    {
        weaponHandler.OnWeaponEquipped -= ActivateWeaponUI;
        weaponHandler.OnWeaponDropped -= DeactivateWeaponUI;
    }
}
