using System;
using Items.Data;
namespace Items;

class Weapon : BaseTool
{

    public float AttackDamage;


    public float CriticalFactor;

    //How much damage is returned to the user as healing
    public float Lifesteal;


    public Weapon(WeaponData data) : base (data.Level, data.MaxDurability, data.Value, data.Name)
    {
        AttackDamage = data.AttackDamage * (Level*0.01f+1);
        CriticalFactor = data.CriticalFactor;
        Lifesteal = data.Lifesteal;
    }
    
    public float GetCritDamage() {
        float critDamage = 0;

        critDamage = AttackDamage + AttackDamage * CriticalFactor *0.01f; //Add more damage based on the current AttackDamage. This is the best way I could think of
        return critDamage;
                
    }
    
}