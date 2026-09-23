using System;
namespace ConsoleGame.Items;

public abstract class BaseItem
{

    public int Value {get; protected set;}

    public string Name;

    public BaseItem(int value, string name)
    {
        Value = value;
        Name = name;
    }
}