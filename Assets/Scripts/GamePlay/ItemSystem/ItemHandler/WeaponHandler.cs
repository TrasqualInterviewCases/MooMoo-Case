using Main.GamePlay.InputSystem;
using System;
using UnityEngine;

namespace Main.GamePlay.ItemSystem
{
    public class WeaponHandler : ItemHandler<WeaponBase>
    {
        public event Action<WeaponBase> OnWeaponEquipped;
        public event Action OnWeaponDropped;

        [SerializeField] private Transform weaponHolder;

        private PlayerInputBase playerInput;
        public WeaponBase CurrentWeapon { get; private set; }

        private void Awake()
        {
            playerInput = GetComponent<PlayerInputBase>();
        }

        public override void PickUpItem(WeaponBase weapon)
        {
            if (CurrentWeapon != null) DropItem();
            CurrentWeapon = weapon;
            CurrentWeapon.transform.SetParent(weaponHolder);
            CurrentWeapon.transform.localPosition = Vector3.zero;
            CurrentWeapon.transform.localRotation = Quaternion.identity;
            OnWeaponEquipped?.Invoke(weapon);
        }

        public override void DropItem()
        {
            if (CurrentWeapon == null) return;

            CurrentWeapon.GetDropped();
            CurrentWeapon = null;
            OnWeaponDropped?.Invoke();
        }

        private void OnEnable()
        {
            playerInput.OnDropPressed += DropItem;
        }

        private void OnDisable()
        {
            playerInput.OnDropPressed -= DropItem;
        }
    }
}