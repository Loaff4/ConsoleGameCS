using System.Buffers;
using Effects.Data;
using Entities;
using Entities.Data;

namespace Effects;

class Poison : BaseEffect
{

    public Poison(EffectData effectData, BaseEntity owner) : base(effectData, owner)
    {
        
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