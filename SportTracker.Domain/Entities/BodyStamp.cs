#region using
using System.ComponentModel.DataAnnotations;

#endregion

namespace SportTracker.Domain.Entities
{
   public class BodyStamp
   {
      [Key]
      public int BodyStampId { get; set; }

      public int UserUserId { get; set; }
      public double Weight { get; set; }
      public double Height { get; set; }
      public double Biceps { get; set; }
      public double Waist { get; set; }
      public System.DateTime Date { get; set; }

      public virtual User User { get; set; }
   }
}