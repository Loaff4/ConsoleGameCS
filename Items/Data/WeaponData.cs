using Entities;

namespace Items.Data;

public struct WeaponData
{
    public string Name;
    public int Value;
    public int Level;
    public int AttackDamage;
    public float MaxDurability;
    public float CurrentDurability;
    public float CriticalFactor;
    public float Lifesteal;
    public Action<BaseEntity, Weapon> OnAttack;
}