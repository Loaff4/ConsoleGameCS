
using ConsoleGame.Data;
namespace ConsoleGame.Entities.Data;


public struct EntityData : IBaseData
{
    public float Level {get; set;}
    public float Health {get; set;}
    public float DodgeChance {get; set;}
    public float Shield {get; set;}
    public float Strength {get; set;}
    public float Lethality {get; set;}
    public string Name {get; set;}

    private static EntityData _empty = new EntityData {
        Level = 0,
        Health = 100,
        DodgeChance = 0,
        Shield = 0,
        Strength = 0,
        Lethality = 0,
        Name = "EMPTY ENTITY"
    };

    public static EntityData empty
    {
        get
        {
            return _empty; 
        }
        private set {}
    }
}