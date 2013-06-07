#region using
using System.Linq;

#endregion

namespace SportTracker.Domain.Abstract
{
   public interface IMuscleRepository
   {
      IQueryable<Muscle> Muscles { get; }
   }
}