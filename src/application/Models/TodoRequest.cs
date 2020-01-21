using System;

namespace Application.Models
{
    public class TodoRequest
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}