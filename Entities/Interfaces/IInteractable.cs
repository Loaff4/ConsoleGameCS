namespace ConsoleGame.Entities.Interfaces;


public interface IInteractable
{
    public int InteractLevel {get; protected set;}

    public void OnInteract(BaseEntity interactingEntity);
}