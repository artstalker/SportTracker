using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using SportTracker.WebUI.Infrastructure.Abstract;

using WebMatrix.WebData;

namespace SportTracker.WebUI.Infrastructure.Concrete
{
	public class FormsAuthProvider : IAuthProvider
	{
		public bool Authenticate(string username, string password, bool rememberMe)
		{

			bool result = WebSecurity.Login(username, password, rememberMe);
			if (result)
			{
				
				//FormsAuthentication.SetAuthCookie(username, rememberMe);
			}
			return result;
		}
	}
}