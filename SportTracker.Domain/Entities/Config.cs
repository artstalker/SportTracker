#region using
using System.ComponentModel.DataAnnotations;

#endregion

namespace SportTracker.Domain.Entities
{
   public class Config
   {
      [Key]
      public string Key { get; set; }

      public string Value { get; set; }
   }
}