using System;
using Nancy;
using Cqrsdemo.Queries;
using System.Collections.Generic;

namespace Cqrsdemo
{
	public class ScheduledEventModule : NancyModule
	{
		public ScheduledEventModule () : base("/api/scheduledevents/{id}/participants")
		{
			Get["/"] = parameters => {
				return Negotiate.WithStatusCode(HttpStatusCode.OK)
					.WithModel(new List<Participant>(){
						new Participant("Annelies","De Meyere", new EmailAddress("annelies.demeyere@gmail.com")), 
						new Participant("Erik", "Talboom", new EmailAddress("talboomerik@gmail.com"))
					});
			};
		}
	}
}

