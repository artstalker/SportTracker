namespace SportTracker.Domain.Entities
{
   public class SendEmailModel
   {
      public string EmailAddress { get; set; }
      public string Subject { get; set; }

      public string WebsiteURL { get; set; }
      public string WebsiteTitle { get; set; }
      public string WebsiteUrlName { get; set; }
   }
}