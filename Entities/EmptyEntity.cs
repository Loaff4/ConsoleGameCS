using Entities.Data;

namespace Entities;

public class EmptyEntity : BaseEntity
{
    public EmptyEntity() : base(EntityData.empty)
    {
    }
}