namespace LinqQueryParser.Engine
{
	public interface IQueryParserEngine
	{
		string ParseQuery(string query);
	}
}