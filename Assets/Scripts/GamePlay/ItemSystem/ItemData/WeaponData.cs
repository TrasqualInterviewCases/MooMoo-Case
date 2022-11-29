using UnityEngine;

namespace Main.GamePlay.ItemSystem
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class WeaponData : ItemData
    {
        public float AttackRadius = 1f;
        public float AttackRange = 1.5f;
        public float AttackDamage = 1f;
        public float AttackCD = 0.5f;
        public AnimatorOverrideController overrideController;
    } 
}
