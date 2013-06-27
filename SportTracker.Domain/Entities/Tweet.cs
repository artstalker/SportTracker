namespace SportTracker.Domain.Entities
{
   public class Tweet
   {
      public int TweetId { get; set; }
      public int UserUserId { get; set; }
      public string Message { get; set; }
      public System.DateTime DateTime { get; set; }

      public virtual User User { get; set; }
   }
}