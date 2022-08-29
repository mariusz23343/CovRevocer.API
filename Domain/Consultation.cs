using System;
using System.Collections.Generic;

namespace Domain
{
    public class Consultation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsClosed { get; set; }
        public string Category { get; set; }
        public ICollection<Comment> ConsultationComments { get; set; }
        public AppUser Patient { get; set; }
        public AppUser Medic { get; set; }
    }
}
