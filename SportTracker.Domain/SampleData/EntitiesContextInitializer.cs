using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportTracker.Domain.Entities;
using SportTracker.Domain.Migrations;

namespace SportTracker.Domain.SampleData
{
	public class EntitiesContextInitializer :MigrateDatabaseToLatestVersion<ModelContext, Configuration>
	{

	}
}

