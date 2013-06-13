using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Abstract
{
	public interface IEmailService
	{
		void SendEmail(string emailAddress, string title, string message);

		void SendEmail(SendEmailModel sendEmailModel, string templateName, object data);
	}
}
