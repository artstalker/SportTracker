#region using
using System.Collections.Generic;

#endregion

namespace SportTracker.Domain.Entities
{
   public class Muscle
   {
      public Muscle()
      {
         Excercises = new HashSet<Excercise>();
      }

      public int MuscleId { get; set; }      
      public string Name { get; set; }
      public string Description { get; set; }
      public string Url { get; set; }

      public virtual ICollection<Excercise> Excercises { get; set; }
   }
}