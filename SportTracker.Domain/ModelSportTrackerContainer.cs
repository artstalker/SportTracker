using SportTracker.Domain.Abstract;

namespace SportTracker.Domain
{   
   partial class ModelSportTrackerContainer: IMuscleRepository
   {
      System.Linq.IQueryable<Muscle> IMuscleRepository.Muscles
      {
         get { return this.Muscles; }
      }
   }
}