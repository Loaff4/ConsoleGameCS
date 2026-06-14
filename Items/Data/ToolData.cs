using Entities;
using Items.Interfaces;

namespace Items.Data;

public struct ToolData
{
    public string Name;
    public int Value;
    public float Level;
    public int AttackDamage;
    public float Durability;
    public float CriticalFactor;
    public float Lifesteal;
    public Action<IItemOwner, BaseEntity, BaseTool> OnAttack;
}