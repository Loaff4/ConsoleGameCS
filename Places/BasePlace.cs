using Places.PointsOfInterest;

namespace Places;


public abstract class BasePlace
{
    List<BasePoi> Pois;
    string Name;

    bool FirstTime = true;
    string EnteringMessage;
    string IntroMessage;

    public BasePlace(List<BasePoi> pois, string name)
    {
        Pois = pois;
        Name = name;
    }

    public void OnEntered()
    {
        Console.Write($"Welcome to {Name}. ");
        if (FirstTime) {
            Console.WriteLine(IntroMessage);
        }
        else
        {
            Console.WriteLine(EnteringMessage);
        }
    }
    public void OnExited()
    {

        FirstTime = false;
    }


}