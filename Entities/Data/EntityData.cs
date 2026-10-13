namespace ConsoleGame.Entities.Data;


public struct EntityData
{
    public float Level {get; private set;}
    public float Health {get; private set;}
    public float DodgeChance {get; private set;}
    public float Shield {get; private set;}
    public float Strength {get; private set;}
    public float Lethality {get; private set;}
    public string Name {get; private set;}

    private static EntityData _empty = new EntityData {
        Level = 0,
        Health = 1,
        DodgeChance = 0,
        Shield = 0,
        Strength = 0,
        Lethality = 0,
        Name = "EMPTY ENTITY"
    };

    public static EntityData Empty
    {
        get
        {
            return _empty; 
        }
        private set
        {
            
        }
    }
}