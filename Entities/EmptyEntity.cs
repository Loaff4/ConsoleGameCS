using ConsoleGame.Entities.Data;

namespace ConsoleGame.Entities;

public class EmptyEntity : Entity
{
    public EmptyEntity() : base(EntityData.Empty)
    {
    }
}