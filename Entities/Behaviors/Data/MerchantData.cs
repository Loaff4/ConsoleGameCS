using ConsoleGame.Items;

namespace ConsoleGame.Entities.Behaviors.Data;

public struct MerchantData
{
    public int TotalBalance {get; set;}
    public Dictionary<Item, int> Wares {get; set;}
}