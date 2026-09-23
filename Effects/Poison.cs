using System.Buffers;
using ConsoleGame.Effects.Data;
using ConsoleGame.Entities;
using ConsoleGame.Entities.Data;

namespace ConsoleGame.Effects;

public class Poison : BaseEffect
{

    
    
    public Poison(EffectData effectData, BaseEntity owner) : base(effectData, owner)
    {
        Name = "Poison";
    }

    public override void Tick()
    {
        Console.WriteLine($"{Owner.Name} was hurt by {Name}\n");
        Owner.TakeDamage(new DamageData
        {
            DamageAmount = Potency * 5,
            DamageSource = this
        });
        
    }
}