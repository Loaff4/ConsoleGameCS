namespace Entities.Data;

public struct EntityData
{
    public float Level;
    public float Health;
    public float DodgeChance;
    public float Shield;
    public float Strength;
    public float Lethality;
    public string Name;

    public static EntityData empty = new EntityData
    {
        Level = 0,
        Health = 1,
        DodgeChance = 0,
        Shield = 0,
        Strength = 0,
        Lethality = 0,
        Name = "EMPTY ENTITY"
    };
}