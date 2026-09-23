using ConsoleGame.Entities;
using ConsoleGame.Places.PointsOfInterest.Data;

namespace ConsoleGame.Places.PointsOfInterest;

class GatheringPoi : BasePoi
{
    public BaseEntity[] GatheredEntites;
    public float DangerLevel;
    public GatheringPoi(GatheringData data) : base(data.Name)
    {
        GatheredEntites = data.GatheredEntities;
        DangerLevel = data.DangerLevel;
    }
}