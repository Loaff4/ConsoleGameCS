using Places.Data;
using Places.PointsOfInterest;

namespace Places;


public class Place
{
    public List<BasePoi> Pois;

    bool FirstTime = true;
    string EnteringMessage;
    string Name;


    public Place(PlaceData data)
    {
        Pois = data.Pois;
        EnteringMessage = data.EnteringMessage;
        Name = data.Name;
    }

    public void OnEnter()
    {
        if (FirstTime) {
            Console.Write($"Welcome to {Name}. ");
        }
        else
        {
            Console.Write($"Welcome back to {Name}. ");
        }
        Console.WriteLine(EnteringMessage);
    }
    public void OnExit()
    {
        FirstTime = false;
    }


}