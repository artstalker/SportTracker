#region using
using System.Collections.Generic;

#endregion

namespace SportTracker.Domain.Entities
{
   public class User
   {
      public User()
      {
         BodyStamps = new HashSet<BodyStamp>();
         Friends = new HashSet<User>();
         Programs = new HashSet<Program>();
         Tweets = new HashSet<Tweet>();
         Trainings = new HashSet<Training>();
         Roles = new HashSet<Role>();
      }

      public int UserId { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }

      public virtual ICollection<BodyStamp> BodyStamps { get; set; }
      public virtual ICollection<User> Friends { get; set; }
      public virtual ICollection<Program> Programs { get; set; }
      public virtual ICollection<Tweet> Tweets { get; set; }
      public virtual ICollection<Training> Trainings { get; set; }
      public virtual ICollection<Role> Roles { get; set; }
   }
}