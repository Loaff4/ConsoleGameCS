using System;
using ConsoleGame.Entities;
using ConsoleGame.Items.Data;
using ConsoleGame.Items.Interfaces;
namespace ConsoleGame.Items;

public class Weapon : Tool
{

    public float AttackDamage {get; private set;}


    public float CriticalFactor {get; private set;}

    //How much damage is returned to the user as healing
    public float Lifesteal {get; private set;}

    public Action<IItemOwner, Entity, Tool> OnHit;


    public Weapon(ToolData data) : base (data)
    {
        AttackDamage = data.AttackDamage + (data.AttackDamage*Level*0.01f); //Level 100 doubles dmg, Level 200 triples dmg, etc...
        CriticalFactor = data.CriticalFactor;
        Lifesteal = data.Lifesteal;
        OnHit = data.OnAttack ?? new Action<IItemOwner, Entity, Tool>((IItemOwner owner, Entity target, Tool thisWeapon) => {});
    }

    
    public float GetCritDamage() {
        float critDamage = 0;

        critDamage = AttackDamage * CriticalFactor; //Add more damage based on the current AttackDamage. This is the best way I could think of
        return critDamage;
                
    }
    
}