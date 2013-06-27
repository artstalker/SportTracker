using System;
using System.Collections.Generic;

namespace SportTracker.Domain.Entities
{
   public partial class Program
    {
        public Program()
        {
            this.Trainings = new HashSet<Training>();
            this.ProgramExcercises = new HashSet<ProgramExcercise>();
        }
    
        public int ProgramId { get; set; }
        public int UserUserId { get; set; }
        public string Name { get; set; }
        public bool IsOpenToWorld { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Author { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<ProgramExcercise> ProgramExcercises { get; set; }
    }
}
