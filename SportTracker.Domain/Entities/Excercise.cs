#region using
using System.Collections.Generic;

#endregion

namespace SportTracker.Domain.Entities
{
   public class Excercise
   {
      public Excercise()
      {
         Muscles = new HashSet<Muscle>();
         ProgramExcercises = new HashSet<ProgramExcercise>();
         Statistics = new HashSet<Statistic>();
      }

      public int ExcerciseId { get; set; }
      public string Name { get; set; }
      public string Complexity { get; set; }
      public string Description { get; set; }
      public string Url { get; set; }

      public virtual ICollection<Muscle> Muscles { get; set; }
      public virtual ICollection<ProgramExcercise> ProgramExcercises { get; set; }
      public virtual ICollection<Statistic> Statistics { get; set; }
   }
}