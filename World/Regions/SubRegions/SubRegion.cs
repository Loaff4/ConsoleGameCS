using ConsoleGame.World.Regions;

namespace World.Regions.SubRegions;

public class SubRegion : Region
{
    public SubRegion(string name, List<SubRegion> subRegions) : base(name, subRegions)
    {
        
    }
}