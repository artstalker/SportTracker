using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebMatrix.WebData;

namespace SportTracker.WebUI.Infrastructure
{
	public class WebSecurityInitializer
	{
		private WebSecurityInitializer() { }
		public static readonly WebSecurityInitializer Instance = new WebSecurityInitializer();
		private bool isNotInit = true;
		private readonly object SyncRoot = new object();
		public void EnsureInitialize()
		{
			if (isNotInit)
			{
				lock (this.SyncRoot)
				{
					if (isNotInit)
					{
						isNotInit = false;
						WebSecurity.InitializeDatabaseConnection("EFDbContext", userTableName: "UserProfile", userIdColumn: "UserId", userNameColumn: "UserName", autoCreateTables: true);
					}
				}
			}
		}
	}
}