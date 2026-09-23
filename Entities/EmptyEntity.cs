using ConsoleGame.Entities.Data;

namespace ConsoleGame.Entities;

public class EmptyEntity : BaseEntity
{
    public EmptyEntity() : base(EntityData.empty)
    {
    }
}