using System.Text.RegularExpressions;

namespace LinqQueryParser.Engine.Helper
{
	public static class StringExtensions
	{
		public static Regex InvalidCharactersForName = new Regex(@"\:");
		public static Regex RawTypeRegex = new Regex("Input ");

		public static bool IsString(this string value) 
			=> value.ToLowerInvariant() == Types.STRING;

		public static bool IsInt(this string value) 
			=> value.ToLowerInvariant() == Types.INT;

		public static string PurgeName(this string value)
			=> InvalidCharactersForName.Replace(value, string.Empty);

		public static string GetTypeFromRawType(this string rawType) 
			=> RawTypeRegex.Replace(rawType, string.Empty).Trim();

		public static string GetValueFromRawValue(this string rawValue, string type) 
			=> TypeMapper.WrapVariable(rawValue, type);
	}
}