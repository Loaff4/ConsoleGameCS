using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using Effects;
using Entities.Data;
using Items;
using Items.Interfaces;
using Utilities;
namespace Entities;

public abstract class BaseEntity : IItemOwner
{

    public float Level;
    public float MaxHealth {get; protected set;} 
    public float CurrentHealth {get; protected set;}
    protected float DodgeChance; //How likely this entity is to dodge
    public float Sheild {get; protected set;} //How much damage is reduced (dmg = Shield*0.01+1)
    public float Strength {get; protected set;} //The base damage this entity deals with attacks
    public float Lethality; //How likely this entity is to deal critical damage when holding a weapon

    public List<BaseEntity> Attackers {get; protected set;} = new(); //Which entity has attacked it this turn
    public List<BaseEffect> CurrentEffects {get; protected set;} = new(); 
    public string Name = "nameless entity";
    public List<BaseItem> InventoryItems {get; protected set;}= new(); 
    public int CoinBalance {get; protected set;}= 0;
    public BaseTool EquippedTool {get; protected set;}
    
    public static EmptyEntity Empty {get; private set;} = new EmptyEntity();

    List<BaseItem> IItemOwner.InventoryItems {get; set;}

    public BaseEntity(EntityData data) 
    {
        Level = data.Level;
        MaxHealth = MathUtil.Scale(data.Health, Level);
        CurrentHealth = MaxHealth;
        Strength = MathUtil.Scale(data.Strength, Level);
        Name = data.Name;
        
    }


    //Target an enemy with an attack (true attacks bypass dodging and dmg reduction)
    public void Attack(BaseEntity targetEntity, float miscMultiplier = 1, bool trueAttack = false)
    {   
        

        float dmgAmt = Strength;

        float bonusDamage = 0;
        if (EquippedTool is Weapon weapon) {
            float randFloat = (float)Random.Shared.NextDouble()*100;
            if (randFloat < Lethality) {
                bonusDamage = weapon.GetCritDamage();
            } else {
                bonusDamage += weapon.AttackDamage;
            }

            weapon.OnAttack(this, targetEntity, weapon);
            weapon.Decay(1);

            dmgAmt += bonusDamage;
            dmgAmt *= miscMultiplier;

            float healAmt = dmgAmt*weapon.Lifesteal*0.01f; //100 Lifesteal means heal for the same amount as dmg dealt

            Heal(healAmt);
        }
        else
        {
            dmgAmt += bonusDamage;
            dmgAmt *= miscMultiplier;
        }

        
        DamageData dmg = new DamageData
        {
            DamageAmount = dmgAmt,
            DamageSource = this
        };
        

        

        Console.WriteLine($"{Name} is attacking {targetEntity.Name}\n");
        targetEntity.OnAttacked(this, dmg, trueAttack);
    }
   

    //Calculate dodging and damage reduction
    public virtual void OnAttacked(BaseEntity attacker, DamageData dmg, bool trueAttack) {
        

        Attackers.Add(attacker);

        float dmgAmt = dmg.DamageAmount;

        //True attacks bypass all dodging and dmg reduction
        if (trueAttack) {
            TakeDamage(dmg);
            return;
        }

        //Reduce damage with shields
        dmgAmt /= Sheild*0.01f+1; //Each magnitude of 100 is: 1/2, 1/3, 1/4, etc...

        //Try to dodge the attack (take no damage)
        float randFloat = (float)Random.Shared.NextDouble() * 100;
        if (randFloat < DodgeChance) {
            Console.WriteLine($"{Name} has dodged {attacker.Name}'s attack\n");
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
        if (healAmt + CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }
        CurrentHealth += healAmt;
        Console.WriteLine($"{Name} has healed by {healAmt} health points\n");
    }


    public void TakeDamage(DamageData dmg) {

        float dmgAmt = dmg.DamageAmount;
        object dmgSource = dmg.DamageSource;

        if (dmgAmt <= 0) return; //Don't print or do anything if the dmg is 0 or less since that's redundant
        CurrentHealth -= dmgAmt;
        Console.WriteLine($"{Name} has taken {dmgAmt} damage\n");
    }


    //Sell an item to any particular shop (might put this under the BaseItem class idk yet)
    public void SellItem(BaseItem item) {
        InventoryItems.Remove(item);
        CoinBalance += item.Value;
    }


    public void Equip(BaseTool tool) {
        EquippedTool = tool;
    }

    public void GainEffect(BaseEffect effect)
    {
        CurrentEffects.Add(effect);
    }

    public void TickEffects()
    {
        foreach (BaseEffect effect in CurrentEffects)
        {
            effect.Tick();       
        }
    }

    public void DeleteItem(BaseItem item)
    {
        InventoryItems.Remove(item);
    }
}