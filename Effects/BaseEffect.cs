using System;
using Effects.Data;
using Entities;
namespace Effects;

public abstract class BaseEffect
{
    public int Duration;

    //How strong is the effect
    public float Potency;

    //Who is this effect applied to
    public BaseEntity Owner;

    public BaseEffect(EffectData effectData, BaseEntity owner)
    {
        Duration = effectData.Duration;
        Potency = effectData.Potency * 5;
        Owner = owner;
    }


    //Do whatever the effect does this tick
    public abstract void Tick();

}