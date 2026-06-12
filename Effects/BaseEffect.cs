using System;
namespace Effects;

abstract class BaseEffect
{
    int Duration;

    //How strong is the effect
    int Potency;

    public BaseEffect(int startingDuration, int potency)
    {
        Duration = startingDuration;
        Potency = potency;
    }


    //Do whatever the effect does this tick
    public abstract void Tick();

}