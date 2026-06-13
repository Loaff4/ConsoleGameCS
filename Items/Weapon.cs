using System;
using Entities;
using Items.Data;
namespace Items;

class Weapon : BaseTool
{

    public float AttackDamage;


    public float CriticalFactor;

    //How much damage is returned to the user as healing
    public float Lifesteal;

    public Action<BaseEntity> OnAttack;


    public Weapon(WeaponData data) : base (data.Level, data.MaxDurability, data.Value, data.Name)
    {
        AttackDamage = data.AttackDamage * (Level*0.01f+1); //Level 100 doubles dmg, Level 200 triples dmg, etc...
        CriticalFactor = data.CriticalFactor;
        Lifesteal = data.Lifesteal;
        OnAttack = data.OnAttack ?? new Action<Entities.BaseEntity>((BaseEntity target) => {});
    }

    
    public float GetCritDamage() {
        float critDamage = 0;

        critDamage = AttackDamage + AttackDamage * CriticalFactor *0.01f; //Add more damage based on the current AttackDamage. This is the best way I could think of
        return critDamage;
                
    }
    
}