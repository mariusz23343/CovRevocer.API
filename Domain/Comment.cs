using System;

namespace Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public AppUser Author { get; set; }
        public Consultation Consultation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
