using ConsoleGame.Data;
using ConsoleGame.Effects;
using ConsoleGame.Items;

namespace ConsoleGame.Entities.Data;

public struct DamageData : IBaseData
{
    public float DamageAmount {get; set;}
    public object DamageSource {get; set;}

    private static DamageData _empty = new DamageData
    {
        DamageAmount = 0,
        DamageSource = EntityData.Empty
    };

    public static DamageData Empty
    {
        get
        {
            return _empty;
        }
        set
        {
            
        }
    }
}