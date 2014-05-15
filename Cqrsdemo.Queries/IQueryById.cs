using System;
using System.Collections.Generic;

namespace Cqrsdemo.Queries
{
	public interface IQueryById<T>
	{
		Guid SearchCriterium {
			get;
		}
		IEnumerable<T> QueryResults {
			get;
		}
	}
}

