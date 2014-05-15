using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;
using Cqrsdemo;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cqrsdemo.Queries;

namespace Cqrsdemo.Specifications
{
	[TestFixture ()]
	public class RegistrationSpecification
	{
		[Test]
		public void Should_return_status_ok_when_route_exists()
		{
			// Given
			var bootstrapper = new DefaultNancyBootstrapper();
			var browser = new Browser(with => with.Module(new RegistrationModule()));
			var list = new List<Participant>(){
				new Participant("Annelies","De Meyere"), 
				new Participant("Erik", "Talboom")
			};

			// When
			var result = browser.Get("/api/registrations", with => {
				with.HttpRequest();
				with.Header("accept", "application/json"); 
			});

			// Then
			Assert.That (result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			Assert.That (result.Body.AsString(), Is.EqualTo(JsonConvert.SerializeObject(list)));
		}
	}
}

