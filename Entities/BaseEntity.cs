using System;
using Effects;
using Entities.Data;
using Items;
namespace Entities;

public abstract class BaseEntity
{
    public float MaxHealth = 200; 
    public float CurrentHealth;
    public float DodgeChance; //How likely this entity is to dodge
    public float Sheild; //How much damage is reduced (dmg = Shield*0.01+1)
    public float Strength; //The base damage this entity deals with attacks
    public float Lethality; //How likely this entity is to deal critical damage when holding a weapon

    public List<BaseEntity> Attackers = new(); //Which entity has attacked it this turn
    public List<BaseEffect> CurrentEffects; 
    public string Name = "nameless entity";
    public List<BaseItem> InventoryItems = new(); 
    public int CoinBalance = 0;
    public BaseTool EquippedTool;
    public int id; //This will be used to find the entity in lists (not using Name since those can have duplicates)

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

            float randFloat = (float)Random.Shared.NextDouble()*100;
            if (randFloat < Lethality) {
                bonusDamage = weapon.GetCritDamage();
            } else {
                bonusDamage += weapon.AttackDamage;
            }


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
        

        

        Console.WriteLine($"{Name} is attacking {targetEntity.Name}");
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
        if (healAmt + CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }
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
}