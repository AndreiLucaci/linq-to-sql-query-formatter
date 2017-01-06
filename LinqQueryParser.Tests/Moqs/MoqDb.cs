using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace LinqQueryParser.Tests.Moqs
{
	public class MoqTest1 : ObjectContext
	{
		public MoqTest1(EntityConnection connection) : base(connection)
		{
		}

		public MoqTest1(EntityConnection connection, bool contextOwnsConnection) : base(connection, contextOwnsConnection)
		{
		}

		public MoqTest1(string connectionString) : base(connectionString)
		{
		}

		public MoqTest1(string connectionString, string defaultContainerName) : base(connectionString, defaultContainerName)
		{
		}

		public MoqTest1(EntityConnection connection, string defaultContainerName) : base(connection, defaultContainerName)
		{
		}

		public IQueryable<MoqTest3> SalesOrderHeaders { get; set; }
	}
}