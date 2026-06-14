using System;
using System.Runtime.CompilerServices;
using Items.Data;
using Items.Interfaces;
namespace Items;

public abstract class BaseTool : BaseItem
{

    float MaxDurability; 
    float CurrentDurability; //How many durability points this has (I could make it deleted or just a different state idk yet)
    public float Level; //How "strong" this tool is. Will determine stat multipliers
    IItemOwner Owner;

    public BaseTool(ToolData data) : base (data.Value, data.Name)
    {
        Level = data.Level;
        MaxDurability = data.Durability;
        CurrentDurability = MaxDurability;
    }
    
    
    public void Decay(float decayAmt)
    {
        CurrentDurability -= decayAmt;
    }

}