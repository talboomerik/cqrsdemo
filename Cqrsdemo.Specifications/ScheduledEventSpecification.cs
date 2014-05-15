using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;
using Cqrsdemo;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cqrsdemo.Queries;
using Cqrsdemo.Specifications.SimpleTestExtensions;

namespace Cqrsdemo.Specifications
{
	[Specification]
	public class ScheduledEventSpecification : BaseSpecification<ScheduledEventModule>
	{
		Browser browser;
		List<Participant> list;
		BrowserResponse result;

		protected override void Given ()
		{
			browser = new Browser (with => with.Module (new ScheduledEventModule ()));
			list = new List<Participant> () {
				new Participant ("Annelies", "De Meyere", new EmailAddress ("annelies.demeyere@gmail.com")),
				new Participant ("Erik", "Talboom", new EmailAddress ("talboomerik@gmail.com"))
			};
		}

		protected override void When ()
		{
			result = browser.Get ("/api/scheduledevents/{id}/participants", with => {
				with.HttpRequest ();
				with.Header ("accept", "application/json"); 
			});
		}

		[Then]
		public void The_participants_route_exists()
		{
			Assert.That (result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		[Then]
		public void The_response_contains_the_expected_participants()
		{
			Assert.That (result.Body.AsString(), Is.EqualTo(JsonConvert.SerializeObject(list)));
		}
	}
}