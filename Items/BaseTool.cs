using System;
using System.Runtime.CompilerServices;
namespace Items;

abstract class BaseTool : BaseItem
{

    float MaxDurability; 
    float CurrentDurability; //How many durability points this has (I could make it deleted or just a different state idk yet)
    int Level; //How "strong" this tool is. Will determine stat multipliers

    public BaseTool(int startingLevel, float startingDurability, int value, string name) : base (value, name)
    {
        MaxDurability = startingDurability;
        CurrentDurability = MaxDurability;
        Level = startingLevel;
    }
    
    
    public void Decay(float decayAmt)
    {
        CurrentDurability -= decayAmt;
    }

}