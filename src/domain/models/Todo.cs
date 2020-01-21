using System;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Todo : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDone { get; set; } = false;
        public string DisplayName { get; set; }
        public string Content { get; set; }
    }
}