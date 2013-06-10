using SportTracker.Domain.Abstract;

namespace SportTracker.Domain
{   
   partial class ModelSportTrackerContainer
   {
      public ModelSportTrackerContainer(string connectionName)
         : base(connectionName)
      {
         this.Configuration.LazyLoadingEnabled = false;
      }      
   }
}