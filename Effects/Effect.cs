using System;
using ConsoleGame.Effects.Data;
using ConsoleGame.Entities;
namespace ConsoleGame.Effects;

public abstract class Effect
{
    public int Duration {get; protected set;}

    //How strong is the effect
    public float Potency {get; protected set;}

    //Who is this effect applied to
    public Entity Owner {get; protected set;}

     public string Name {get; protected set;} = "UNTITLED_EFFECT";

    public Effect(EffectData effectData, Entity owner)
    {
        Duration = effectData.Duration;
        Potency = effectData.Potency;
        Owner = owner;
    }


    //Do whatever the effect does this tick
    public abstract void Tick();

}