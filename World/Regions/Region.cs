using World.Regions.SubRegions;

namespace ConsoleGame.World.Regions;

public class Region
{
    public string Name {get; private set;}
    public List<SubRegion> SubRegions {get; private set;}
    
    Region(string name, List<SubRegion> subRegions)
    {
        Name = name;

        SubRegions = subRegions;
        
    }
}