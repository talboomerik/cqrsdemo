﻿using System;
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
						new Participant("Annelies","De Meyere", new EmailAddress("annelies.demeyere@gmail.com")), 
						new Participant("Erik", "Talboom", new EmailAddress("talboomerik@gmail.com"))
					});
			};
		}
	}
}

