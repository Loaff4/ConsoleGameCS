using System.Collections.Generic;
using ConsoleGame.Items;
using ConsoleGame.Entities.Behaviors.Data;

namespace ConsoleGame.Entities.Behaviors;

public class MerchantBehavior : Behavior
{


    public Dictionary<Item, int> Wares;
    public MerchantBehavior(MerchantData data, Entity owner) : base(owner)
    {
        Wares = data.Wares;
        
        Owner = owner;

        Owner.OnItemRemoved += RemoveWare;
    }

    private void RemoveWare(Item item)
    {
        Wares.Remove(item);
    }

    public void ListWares()
    {
        
    }
}