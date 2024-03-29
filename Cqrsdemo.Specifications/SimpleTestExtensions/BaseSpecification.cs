﻿using System;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace Cqrsdemo.Specifications.SimpleTestExtensions
{
	public abstract class BaseSpecification<TSubjectUnderTest>
	{
		private Dictionary<Type, object> mocks;

		protected Dictionary<Type, object> DoNotMock;
		protected TSubjectUnderTest SubjectUnderTest;
		protected Exception CaughtException;
		protected virtual void SetupDependencies() { }
		protected virtual void Given() { }
		protected abstract void When();
		protected virtual void Finally() { }

		[Given]
		public void Setup()
		{
			mocks = new Dictionary<Type, object>();
			DoNotMock = new Dictionary<Type, object>();
			CaughtException = new ThereWasNoExceptionButOneWasExpectedException();

			BuildMocks();
			SetupDependencies();
			SubjectUnderTest = BuildSubjectUnderTest();

			Given();

			try
			{
				When();
			}
			catch (Exception exception)
			{
				CaughtException = exception;
			}
			finally
			{
				Finally();
			}
		}

		public Mock<TType> OnDependency<TType>() where TType : class
		{
			return (Mock<TType>)mocks[typeof(TType)];
		}

		private TSubjectUnderTest BuildSubjectUnderTest()
		{
			var constructorInfo = typeof(TSubjectUnderTest).GetConstructors().First();

			var parameters = new List<object>();
			foreach (var mock in mocks)
			{
				object theObject;
				if (!DoNotMock.TryGetValue(mock.Key, out theObject))
					theObject = ((Mock) mock.Value).Object;

				parameters.Add(theObject);
			}

			return (TSubjectUnderTest)constructorInfo.Invoke(parameters.ToArray());
		}

		private void BuildMocks()
		{
			var constructorInfo = typeof(TSubjectUnderTest).GetConstructors().First();

			foreach (var parameter in constructorInfo.GetParameters())
			{
				mocks.Add(parameter.ParameterType, CreateMock(parameter.ParameterType));
			}
		}

		private static object CreateMock(Type type)
		{
			var constructorInfo = typeof(Mock<>).MakeGenericType(type).GetConstructors().First();
			return constructorInfo.Invoke(new object[] { });
		}
	}
}

