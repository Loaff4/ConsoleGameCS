namespace ConsoleGame.Entities.Behaviors;

public abstract class BaseBehavior
{
    protected BaseEntity Owner;

    public int Proficiency {get; set;}
    public void OnInteract()
    {
        
    }

    protected BaseBehavior(BaseEntity owner)
    {
        Owner = owner;
    }
}