namespace SportTracker.Domain.Entities
{
   public class Statistic
   {
      public int StatisticId { get; set; }
      public short SetNumber { get; set; }
      public short RepsCount { get; set; }
      public double Weight { get; set; }
      public string Note { get; set; }
      public System.DateTime DateTime { get; set; }

      public virtual Excercise Excercise { get; set; }
      public virtual Training Training { get; set; }
   }
}