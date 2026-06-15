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

    public static ToolData Empty = new ToolData
    {
        Name = "EMPTY TOOL",
        Value = 0,
        Level = 0,
        AttackDamage = 0,
        Durability = 1,
        CriticalFactor = 0,
        Lifesteal = 0,
        OnAttack = new Action<IItemOwner, BaseEntity, BaseTool>((IItemOwner owner, BaseEntity target, BaseTool thisTool) => {})
    };
}