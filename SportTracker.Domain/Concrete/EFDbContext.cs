using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public DbSet<Muscle> Muscles { get; set; }
	}
}
