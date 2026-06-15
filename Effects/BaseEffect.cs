using System;
using Effects.Data;
using Entities;
namespace Effects;

public abstract class BaseEffect
{
    public int Duration {get; protected set;}

    //How strong is the effect
    public float Potency {get; protected set;}

    //Who is this effect applied to
    public BaseEntity Owner {get; protected set;}

    public string Name {get; protected set;}

    public BaseEffect(EffectData effectData, BaseEntity owner)
    {
        Duration = effectData.Duration;
        Potency = effectData.Potency;
        Owner = owner;
    }


    //Do whatever the effect does this tick
    public abstract void Tick();

}