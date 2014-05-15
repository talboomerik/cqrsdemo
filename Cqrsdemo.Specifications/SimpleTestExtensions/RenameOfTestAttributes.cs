using System;
using NUnit.Framework;

namespace Cqrsdemo.Specifications.SimpleTestExtensions
{
	public class SpecificationAttribute : TestFixtureAttribute {}
	public class GivenAttribute : SetUpAttribute {}
	public class ThenAttribute : TestAttribute {}
}

