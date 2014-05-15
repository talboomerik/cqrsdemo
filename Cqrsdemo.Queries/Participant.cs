using System;
using System.Collections.Generic;

namespace Cqrsdemo.Queries
{
	public class Participant
	{
		public string FirstName {
			get;
			set;
		}

		public string LastName {
			get;
			set;
		}

		public Participant (string firstName, string lastName, EmailAddress emailAddress)
		{
			this.LastName = lastName;
			this.FirstName = firstName;

		}
	}
}

