using System;
using Entities;
using Items.Data;
using Items.Interfaces;
namespace Items;

public class Weapon : BaseTool
{

    public float AttackDamage {get; private set;}


    public float CriticalFactor {get; private set;}

    //How much damage is returned to the user as healing
    public float Lifesteal {get; private set;}

    public Action<IItemOwner, BaseEntity, BaseTool> OnAttack;


    public Weapon(ToolData data) : base (data)
    {
        AttackDamage = data.AttackDamage + (data.AttackDamage*Level*0.01f); //Level 100 doubles dmg, Level 200 triples dmg, etc...
        CriticalFactor = data.CriticalFactor;
        Lifesteal = data.Lifesteal;
        OnAttack = data.OnAttack ?? new Action<IItemOwner, BaseEntity, BaseTool>((IItemOwner owner, BaseEntity target, BaseTool thisWeapon) => {});
    }

    
    public float GetCritDamage() {
        float critDamage = 0;

        critDamage = AttackDamage + AttackDamage * CriticalFactor *0.01f; //Add more damage based on the current AttackDamage. This is the best way I could think of
        return critDamage;
                
    }
    
}