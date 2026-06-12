using System;
namespace Items;

abstract class BaseItem
{

    public int Value;

    public string Name;



    public BaseItem(int value, string name)
    {
        Value = value;
        Name = name;
    }


}