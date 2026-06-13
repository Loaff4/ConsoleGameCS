using System.Buffers;
using Effects.Data;
using Entities;
using Entities.Data;

namespace Effects;

public class Poison : BaseEffect
{

    
    
    public Poison(EffectData effectData, BaseEntity owner) : base(effectData, owner)
    {
        Name = "Poison";
    }

    public override void Tick()
    {
        Owner.TakeDamage(new DamageData
        {
            DamageAmount = Potency * 5,
            DamageSource = this
        });
    }
}