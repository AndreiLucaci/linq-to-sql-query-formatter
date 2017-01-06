using System.Collections.Generic;

namespace LinqQueryParser.Engine.Models
{
	public class Variable
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Value { get; set; }
		public string Rawvalue { get; set; }
		public string Size { get; set; }
		public string RawType { get; set; }

		private readonly List<string> _numberTypes = new List<string>
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
		};

		public string GetSetValue() => _numberTypes.Contains(Type.Trim()) ? GetNumberSetValue() : GetStringSetValue();
		private string GetNumberSetValue() => $"SET {Name} = {Value}";
		private string GetStringSetValue() => $"SET {Name} = '{Value}'";
		public string GetDeclareValue() => Size != "-1" ? $"DECLARE {Name} {Type}({Size})" : $"DECLARE {Name} {Type}";
	}
}
