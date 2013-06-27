#region using
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace SportTracker.Domain.Entities
{
   public class Membership
   {      
      public User User { get; set; }
      public DateTime? CreateDate { get; set; }
      public string ConfirmationToken { get; set; }
      public bool IsConfirmed { get; set; }
      public DateTime? LastPasswordFailureDate { get; set; }
      public int PasswordFailuresSinceLastSuccess { get; set; }
      public DateTime? PasswordChangedDate { get; set; }
      public string PasswordSalt { get; set; }
      public string PasswordVerificationToken { get; set; }
      public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
      [Key]
      public int UserId { get; set; }
   }
}