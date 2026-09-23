using System.Buffers;
using ConsoleGame.Effects.Data;
using ConsoleGame.Entities;
using ConsoleGame.Entities.Data;

namespace ConsoleGame.Effects;

class Rotting : BaseEffect
{

    Rotting(EffectData effectData, BaseEntity owner) : base(effectData, owner)
    {
        Name = "Rotting";
    }

    public override void Tick()
    {
        //Deal damage as Poison would
        Owner.TakeDamage(new DamageData
        {
            DamageAmount = Potency,
            DamageSource = this
        });

        
        //Apply the poison effect to each attacker this turn
        foreach (BaseEntity attacker in Owner.Attackers)
        {
            Poison newPoison = new Poison(new EffectData {Duration = 2, Potency = 0.5f}, attacker);
            attacker.GainEffect(newPoison);
        }
    }
}