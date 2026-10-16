using System;
using ConsoleGame.Entities;
using ConsoleGame.Items.Data;
using ConsoleGame.Items.Interfaces;
namespace ConsoleGame.Items;

public abstract class Item
{

    public int Value {get; protected set;}

    public IItemOwner Owner {get; protected set;} = Entity.Empty;

    public string Name;

    public Item(int value, string name)
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