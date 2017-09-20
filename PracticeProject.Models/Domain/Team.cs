using System;

namespace PracticeProject.Models.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
