#region using
using System.Linq;

#endregion

namespace SportTracker.Domain.Abstract
{
   public interface IMuscleRepository : IBaseRepository
   {
      IQueryable<Muscle> Muscles { get; }
   }
}