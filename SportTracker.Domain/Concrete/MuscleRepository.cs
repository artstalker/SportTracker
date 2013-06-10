using System.Linq;
using SportTracker.Domain.Abstract;

namespace SportTracker.Domain.Concrete
{
   public class MuscleRepository: BaseRepository, IMuscleRepository
   {      
      #region Implementation of IMuscleRepository
      System.Linq.IQueryable<Muscle> IMuscleRepository.Muscles
      {
         get { return _container.Muscles; }
      }
      #endregion
   }
}