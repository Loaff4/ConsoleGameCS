using System;
using ConsoleGame.Entities.Data;
namespace ConsoleGame.Entities.Creatures;

class Goblin : Entity
{
    public Goblin(EntityData data) : base(data)
    {
        
    }


    public override void OnAttacked(Entity attacker, DamageData dmg, bool trueAttack)
    {
        base.OnAttacked(attacker, dmg, trueAttack);
        Retaliate(attacker, dmg);
    }

    //Attacker takes damage from this entity proportional to damage dealt to this entity 
    public void Retaliate(Entity attacker, DamageData dmg)
    {
        Console.WriteLine($"{Name} retaliated against {attacker.Name}\n");
        DamageData retaliateDmg = new DamageData {DamageAmount = dmg.DamageAmount*0.1f, DamageSource = this};
        attacker.TakeDamage(retaliateDmg);
    }

    
}