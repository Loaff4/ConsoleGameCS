using System;
using System.Runtime.CompilerServices;
using Items.Data;
using Items.Interfaces;
namespace Items;

public abstract class BaseTool : BaseItem
{

    public float MaxDurability {get; protected set;} 
    public float CurrentDurability {get; protected set;} //How many durability points this has (I could make it deleted or just a different state idk yet)
    public float Level {get; protected set;} //How "strong" this tool is. Will determine stat multipliers
    public IItemOwner Owner {get; protected set;}

    public static BaseTool Empty {get; private set;} = new EmptyTool(ToolData.Empty);

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