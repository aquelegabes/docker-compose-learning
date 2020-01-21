using System;

namespace Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get;set; }
        DateTime CreatedAt { get;set; }
        DateTime? UpdatedAt { get;set; }
    }
}