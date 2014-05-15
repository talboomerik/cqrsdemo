using System;
using System.Collections.Generic;

namespace Cqrsdemo.Queries
{
	public class EmailAddress
	{
		private readonly string _emailAddress;

		public EmailAddress (string emailAddress)
		{
			this._emailAddress = emailAddress;
		}

		public static implicit operator string(EmailAddress emailAddress)
		{
			return emailAddress._emailAddress;
		}

		public override string ToString() {
			return _emailAddress;
		}
	}
}