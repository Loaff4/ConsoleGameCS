namespace ConsoleGame.Entities.Interfaces;


public interface IInteractable
{
    public int InteractLevel {get; protected set;}

    public void OnInteract(Entity interactingEntity);
}