using System;
using System.Collections.Generic;

namespace Cqrsdemo.Queries
{
	public class ParticipantsOfScheduledEventQuery : IQueryById<Participant>
	{
		public ParticipantsOfScheduledEventQuery ()
		{
		}

		public Guid SearchCriterium {
			get; 
			private set;
		}

		public IEnumerable<Participant> QueryResults {
			get;
			private set;
		}
	}
}

