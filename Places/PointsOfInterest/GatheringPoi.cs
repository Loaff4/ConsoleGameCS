using Entities;
using Places.PointsOfInterest.Data;

namespace Places.PointsOfInterest;

class GatheringPoi : BasePoi
{
    public BaseEntity[] GatheredEntites;
    public float DangerLevel;
    GatheringPoi(GatheringData data, string name) : base(name)
    {
        GatheredEntites = data.GatheredEntities;
        DangerLevel = data.DangerLevel;
    }
}