using System;
using Entities.Data;
using Items;
namespace Entities;

abstract class BaseEntity
{
    public float MaxHealth = 200; 
    public float CurrentHealth; 
    public float DodgeFactor; //How likely this creature is to dodge
    public float Sheild; //How much damage is reduced (dmg = Shield*0.01+1)
    public float Strength; //The base damage this creature deals with attacks
    public float lethality; //How likely this creature is to deal critical damage when holding a weapon
    public string Name = "nameless entity";
    public List<BaseItem> InventoryItems = new(); 
    public int CoinBalance = 0;

    public BaseTool EquippedTool;
    public int id; //This will be used to find the creature in lists (not using Name since those can have duplicates)

    public BaseEntity(float startingHealth, float startingStrength, string name) 
    {
        MaxHealth = startingHealth;
        CurrentHealth = MaxHealth;
        Strength = startingStrength;
        Name = name;
    }


    //Target an enemy with an attack (true attacks bypass dodging and dmg reduction)
    public void Attack(BaseEntity targetEntity, float miscMultiplier = 1, bool trueAttack = false)
    {   
        

        float dmgAmt = Strength;

        float bonusDamage = 0;
        if (EquippedTool is Weapon weapon) {
            
            Random random = new();
            float randFloat = (float)random.NextDouble() * lethality;
            if (randFloat>=25) {
                bonusDamage = weapon.GetCritDamage();
            } else {
                bonusDamage += weapon.AttackDamage;
            }
        }

        

        dmgAmt += bonusDamage;
        dmgAmt *= miscMultiplier;

        DamageData dmg = new DamageData
        {
            DamageAmount = dmgAmt,
            DamageSource = this
        };

        Console.WriteLine($"{Name} is attacking {targetEntity.Name}");
        targetEntity.OnAttacked(this, dmg, trueAttack);
    }
   

    //Calculate dodging and damage reduction
    public virtual void OnAttacked(BaseEntity attacker, DamageData dmg, bool trueAttack) {
        
        float dmgAmt = dmg.DamageAmount;

        //True attacks bypass all dodging and dmg reduction
        if (trueAttack) {
            TakeDamage(dmg);
            return;
        }

        //Reduce damage with shields
        dmgAmt /= Sheild*0.01f+1; //Each magnitude of 100 is: 1/2, 1/3, 1/4, etc...

        //Try to dodge the attack (take no damage)
        Random random = new();
        float randFloat = (float)random.NextDouble() * DodgeFactor; //Higher DodgeFactor means more chance to dodge
        if (randFloat>=25) {
            Console.WriteLine($"{Name} has dodged {attacker.Name}'s attack");
            dmgAmt = 0;
        }
        
        DamageData newDmg = new DamageData
        {
            DamageAmount = dmgAmt,
            DamageSource = attacker

        };

        TakeDamage(newDmg);
    }
    public void Heal(float healAmt) 
    {
        CurrentHealth += healAmt;
        Console.WriteLine($"{Name} has healed by {healAmt} health points");
    }


    public void TakeDamage(DamageData dmg) {

        float dmgAmt = dmg.DamageAmount;
        object dmgSource = dmg.DamageSource;

        if (dmgAmt <= 0) return; //Don't print or do anything if the dmg is 0 or less since that's redundant
        CurrentHealth -= dmgAmt;
        Console.WriteLine($"{Name} has taken {dmgAmt} damage");
    }

    //Sell an item to any particular shop (might put this under the BaseItem class idk yet)
    public void SellItem(BaseItem item) {
        InventoryItems.Remove(item);
        CoinBalance += item.Value;
    }


    //Equip a tool for use such as a weapon so it can be used in combat or for whatever else
    public void Equip(BaseTool tool) {
        EquippedTool = tool;
    }
}