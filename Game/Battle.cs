using ConsoleGame.Entities;

namespace ConsoleGame.Game;

public class Battle
{

    //What entities are in this battle
    public List<Entity> Participants {get; private set;}
    private int CurrentTurn;
    public Battle(List<Entity> startingParticipants) 
    {
        Participants = startingParticipants;
    }

    
    
    private void EndTurn()
    {
        CurrentTurn++;
        foreach (Entity entity in Participants)
        {
            entity.TickEffects();
        }
    }
}