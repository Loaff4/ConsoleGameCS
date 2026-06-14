using Entities;
using Places.PointsOfInterest.Data;

namespace Places.PointsOfInterest;

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