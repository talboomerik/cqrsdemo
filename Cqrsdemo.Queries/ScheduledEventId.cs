using System;

namespace Cqrsdemo.Queries
{
	public struct ScheduledEventId
	{
		private readonly Guid _id;

		public ScheduledEventId(Guid id) {
			_id = id;
		}

		public static implicit operator Guid(ScheduledEventId id) {
			return id._id;
		}

		public override string ToString() {
			return _id.ToString();
		}
	}
}

