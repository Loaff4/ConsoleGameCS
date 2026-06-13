using System;
using Entities.Data;
namespace Entities;

class Goblin : BaseEntity
{
    public Goblin(float startingHealth, float startingStrength, string name) : base(startingHealth, startingStrength, name)
    {
        
    }


    public override void OnAttacked(BaseEntity attacker, DamageData dmg, bool trueAttack)
    {
        base.OnAttacked(attacker, dmg, trueAttack);
        if (!trueAttack)
        {
            Retaliate(attacker);
        }
        
    }

    /*
    Deal damage back to an attacker. 
    I'll probably think of a better "non-lazy" way to not make this a feedback loop other than making it a trueAttack but not right now
    (trueAttacks don't trigger retaliate)
    */
    public void Retaliate(BaseEntity attacker)
    {
        Console.WriteLine($"{Name} retaliated against {attacker.Name}");
        Attack(attacker, 0.1f, true);
    }

    
}