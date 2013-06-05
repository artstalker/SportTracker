using System.Linq;

using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Abstract
{
	public interface IMuscleRepository
	{
		IQueryable<Muscle> Muscles { get; }
	}
}