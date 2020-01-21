using System;

namespace Application.Models
{
    public class TodoResponse
    {
        public Guid Id { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DisplayName { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}