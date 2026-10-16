using ConsoleGame.Entities;

namespace ConsoleGame.World.Places.PointsOfInterest.Data;

public struct GatheringData
{
    public Entity[] GatheredEntities;
    public float DangerLevel; //Used to scale entity stats. POIS friendly entities get negative DangerLevel
    public string Name;
}