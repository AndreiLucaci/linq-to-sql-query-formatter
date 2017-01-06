using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqQueryParser.Engine.Constants;
using LinqQueryParser.Engine.Helper;
using LinqQueryParser.Engine.Models;

namespace LinqQueryParser.Engine
{
	public class QueryEngineParser : IQueryParserEngine
	{
		public string ParseQuery(string query)
		{
			var commentedLines = GetCommentLines(query).Select(i => i.Trim('-', ' '));
			var variableList = commentedLines.Select(CreateVariable).Where(i => i != null).ToList();

			var declareLines = variableList.Select(CreateDeclareLine);
			var setLines = variableList.Select(CreateSetLine);

			var declareBlock = string.Join(Environment.NewLine, declareLines);
			var setBlock = string.Join(Environment.NewLine, setLines);

			var parsedQuery = $"{declareBlock}{Environment.NewLine}{setBlock}{Environment.NewLine}{query}";

			return parsedQuery;
		}

		public IEnumerable<string> GetCommentLines(string query)
		{
			return Regex.Split(query, Environment.NewLine).Where(i => i.Trim().StartsWith("--"));
		}

		private string CreateDeclareLine(Variable variable)
		{
			return string.Format(LinqConstants.DECLARE_LINE, variable.Name, variable.Type);
		}

		private string CreateSetLine(Variable variable) 
			=> string.Format(LinqConstants.SET_LINE, variable.Name, variable.Value);

		// @p0: Input Int (Size = -1; Prec = 0; Scale = 0) [1]
		private Variable CreateVariable(string line)
		{
			if (!line.StartsWith(@"@"))
			{
				return null;
			}

			var name = Regex.Match(line, "(@.*?):").Value;
			var size = Regex.Match(line, "Size = (.*?)[\\)\\;]").Value;
			var rawType = Regex.Match(line, "Input (.*?) ").Value;
			var type = rawType.GetTypeFromRawType();
			var value = Regex.Match(line, "\\[(.*?)\\]").Value.Trim('[', ']');

			return new Variable
			{
				Name = name.PurgeName(),
				Size = size,
				Type = type,
				RawType = rawType,
				Value = value.GetValueFromRawValue(type),
				Rawvalue = value
			};
		}
	}
}
