using System;
using Nancy;
using System.Collections.Generic;
using Cqrsdemo.Queries;

namespace Cqrsdemo
{
	public class RegistrationModule : NancyModule
	{
		public RegistrationModule() : base("/api/registrations")
		{
			Get["/"] = parameters => {
				return Negotiate.WithStatusCode(HttpStatusCode.OK)
					.WithModel(new List<Participant>(){
						new Participant("Annelies","De Meyere"), 
						new Participant("Erik", "Talboom")
					});
			};
		}
	}
}

