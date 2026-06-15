using Entities;

namespace Game;

public class Battle
{

    //What entities are in this battle
    public List<BaseEntity> Participants {get; private set;}
    private int CurrentTurn;
    public Battle(List<BaseEntity> startingParticipants) 
    {
        Participants = startingParticipants;
    }

    
    
    private void EndTurn()
    {
        CurrentTurn++;
        foreach (BaseEntity entity in Participants)
        {
            entity.TickEffects();
        }
    }
}