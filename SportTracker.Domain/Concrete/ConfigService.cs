using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportTracker.Domain.Abstract;

namespace SportTracker.Domain.Concrete
{
	public class ConfigService : BaseRepository, IConfigService
	{
		

		public ConfigService()
		{
			
		}

		string IConfigService.GetValue(ConfigName name)
		{
			var config = _container.Configs.FirstOrDefault(x => x.Key.Equals(name.ToString()));
			if (config != null)
			{
				return config.Value;
			}
			return null;
		}

		IDictionary<string, string> IConfigService.GetValues(ConfigName[] configNames)
		{
			var names = configNames.Select(x => x.ToString());
			var configs = _container.Configs.Where(x => names.Contains(x.Key));

			return configs.ToDictionary(x => x.Key, x => x.Value);
		}

	}
}
