﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Web.WebPages.OAuth;

using SportTracker.WebUI.Membership;

namespace SportTracker.WebUI.App_Start
{
	public static class AuthConfig
	{
		public static void RegisterAuth()
		{
			// To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
			// you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

			//OAuthWebSecurity.RegisterMicrosoftClient(
			//    clientId: "",
			//    clientSecret: "");

			OAuthWebSecurity.RegisterClient(new TwitterAuthenticationClient(), "Twitter", new Dictionary<string, object>());
			/*    OAuthWebSecurity.RegisterTwitterClient(
					  consumerKey: "slCCLcgj5V7AYiCvaFa4hQ",
					  consumerSecret: "FYmJOrrHr1dvV2T77uws2tIonF4UqGlOdonfkjLOaU");
			 */

			OAuthWebSecurity.RegisterFacebookClient(
				 appId: "545356245493022",
				 appSecret: "1db60d6a94ff14a9621948ea38ceef79");

			//OAuthWebSecurity.RegisterGoogleClient();
		}

	}
}