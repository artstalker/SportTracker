#region using
using System;
using System.Collections.Generic;

#endregion

namespace SportTracker.Domain.Entities
{
   public class Training
   {
      public Training()
      {
         Statistics = new HashSet<Statistic>();
      }

      public int TrainingId { get; set; }
      public DateTime? StartDate { get; set; }
      public int? Shift { get; set; }
      public bool IsActive { get; set; }

      public virtual Program Program { get; set; }
      public virtual User User { get; set; }
      public virtual ICollection<Statistic> Statistics { get; set; }
   }
}