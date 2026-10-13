using System.Collections.Generic;
using ConsoleGame.Items;
using ConsoleGame.Entities.Behaviors.Data;

namespace ConsoleGame.Entities.Behaviors;

public class MerchantBehavior
{


    private BaseEntity Owner;
    public Dictionary<BaseItem, int> Wares;
    MerchantBehavior(MerchantData data, BaseEntity owner)
    {
        Wares = data.Wares;
        
        Owner = owner;

        Owner.OnItemRemoved += RemoveWare;
    }

    private void RemoveWare(BaseItem item)
    {
        
    }
}