using System;
using System.Linq;
using LinqQueryParser.Engine;
using LinqQueryParser.Tests.Moqs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqQueryParser.Tests
{
	[TestClass]
	public class LinqQueryTests
	{
		private static readonly Func<MoqTest1, decimal, IQueryable<MoqTest3>> SCompiledQuery2 =
			System.Data.Entity.Core.Objects.CompiledQuery.Compile<MoqTest1, decimal, IQueryable<MoqTest3>>(
				(ctx, total) => from order in ctx.SalesOrderHeaders
					where order.TotalDue >= total
					select order);

		private const string CompiledQuery =
			@"SELECT TOP (1) [t4].[tes_id] AS [Id], [t4].[tte_title_customer] AS [Title], [t4].[tre_text_customer] AS [Text], [t4].[tva_value] AS [TravelDate], [t4].[tes_timestamp] AS [DateAdded], [t4].[tes_codes] AS [endecaFormatTestimonialScores], [t4].[value2] AS [entityLevelId], [t4].[value] AS [Id2], [t4].[tes_cus_name] AS [UserName], [t4].[tes_cus_admin_email] AS [UserEmail]
FROM (
    SELECT [t0].[tes_id], [t3].[tva_value], [t0].[tes_timestamp], [t1].[tte_title_customer], [t2].[tre_text_customer], [t0].[tes_cus_name], [t0].[tes_cus_admin_email], [t0].[tes_codes], [t0].[ent_id] AS [value], [t0].[ent_logical_level] AS [value2], [t0].[tes_identifier]
    FROM [dbo].[TTESTIMONIALS] AS [t0]
    INNER JOIN [dbo].[TTESTIMONIAL_TITLES] AS [t1] ON ([t0].[tes_id] = [t1].[tes_id]) AND (@p0 = [t1].[lan_id])
    INNER JOIN [dbo].[TTESTIMONIAL_REMARKS] AS [t2] ON ([t0].[tes_id] = [t2].[tes_id]) AND (@p1 = [t2].[lan_id])
    INNER JOIN [dbo].[TTESTIMONIAL_VALUES] AS [t3] ON ([t0].[tes_id] = [t3].[tes_id]) AND (@p2 = [t3].[tva_attribute])
    ) AS [t4]
WHERE [t4].[tes_identifier] = @p3
-- @p0: Input Int (Size = -1; Prec = 0; Scale = 0) [1]
-- @p1: Input Int (Size = -1; Prec = 0; Scale = 0) [1]
-- @p2: Input VarChar (Size = 8000; Prec = 0; Scale = 0) [period]
-- @p3: Input UniqueIdentifier (Size = -1; Prec = 0; Scale = 0) [c4f914fd-a924-41ef-a030-7ea59b7e3539]
-- Context: SqlProvider(Sql2005) Model: AttributedMetaModel Build: 4.6.1055.0";

		[TestMethod]
		public void QueryEngineParser_ParseQuery()
		{
			var engine = new QueryEngineParser();
			var query = engine.ParseQuery(CompiledQuery);
			Assert.IsNotNull(query);
		}
	}
}
