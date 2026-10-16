using ConsoleGame.Entities;
using ConsoleGame.World.Places.PointsOfInterest.Data;

namespace ConsoleGame.World.Places.PointsOfInterest;

class GatheringPoi : Poi
{
    public Entity[] GatheredEntites;
    public float DangerLevel;
    public GatheringPoi(GatheringData data) : base(data.Name)
    {
        GatheredEntites = data.GatheredEntities;
        DangerLevel = data.DangerLevel;
    }
}