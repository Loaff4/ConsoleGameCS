using System;
using ConsoleGame.Entities;
using ConsoleGame.Items.Data;
using ConsoleGame.Items.Interfaces;
namespace ConsoleGame.Items;

public abstract class BaseItem
{

    public int Value {get; protected set;}

    public IItemOwner Owner {get; protected set;} = BaseEntity.Empty;

    public string Name;

    public BaseItem(int value, string name)
    {
        Value = value;
        Name = name;
    }

    
    public void Transfer(IItemOwner newOwner)
    {
        Owner = newOwner;
        newOwner.ReceiveItem(this);
    }

}