using System.Collections.Generic;
using System.Linq;

namespace LinqQueryParser.Engine.Helper
{
	public static class TypeMapper
	{
		public static Dictionary<List<string>, string> Mapper =
			new Dictionary<List<string>, string>
			{
				{new List<string> {"VarChar", "NVarChar", "UniqueIdentifier"}, Types.STRING},
				{
					new List<string>
					{
						"tinyint",
						"smallint",
						"int",
						"bigint",
						"decimal",
						"numberic",
						"smallmoney",
						"money",
						"float",
						"real"
					},
					Types.INT
				}
			};

		public static string GetTypeFromSql(string value)
		{
			var key = Mapper.Keys.FirstOrDefault(i => i.Any(j => j.ToLowerInvariant().Contains(value.ToLowerInvariant())));
			string result;
			Mapper.TryGetValue(key, out result);
			return result;
		}

		public static string WrapVariable(string value, string type)
		{
			var resultType = GetTypeFromSql(type);
			return resultType.IsString() || !resultType.IsInt() ? $"'{value}'" : value;
		}
	}
}
