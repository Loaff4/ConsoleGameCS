using ConsoleGame.Entities;

namespace ConsoleGame.Places.PointsOfInterest.Data;

public struct GatheringData
{
    public BaseEntity[] GatheredEntities;
    public float DangerLevel; //Used to scale entity stats. POIS friendly entities get negative DangerLevel
    public string Name;
}