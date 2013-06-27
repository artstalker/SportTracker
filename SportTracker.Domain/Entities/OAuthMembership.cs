using System.ComponentModel.DataAnnotations;

namespace SportTracker.Domain.Entities
{
   public class OAuthMembership
   {
      public string Provider { get; set; }
      public string ProviderUserId { get; set; }
      [Key]
      public int UserId { get; set; }
   }
}