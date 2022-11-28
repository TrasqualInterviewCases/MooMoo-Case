using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class WeaponData : ItemData
{
    public float AttackDamage = 1f;
    public float AttackSpeed = 0.5f;
    public AnimatorOverrideController overrideController;
}
