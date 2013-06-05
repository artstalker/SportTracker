using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportTracker.Domain.Abstract;
using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Concrete
{
	public class EFMuscleRepository : IMuscleRepository
	{
		private EFDbContext context = new EFDbContext();
		public IQueryable<Muscle> Muscles
		{
			get { return context.Muscles; }
		}

		
	}
}
