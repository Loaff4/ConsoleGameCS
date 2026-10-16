
namespace ConsoleGame.Entities.Behaviors;

public abstract class Behavior
{
    protected Entity Owner;

    public int Proficiency {get; set;}
    public void OnInteract()
    {
        
    }

    protected Behavior(Entity owner)
    {
        Owner = owner;
    }
}