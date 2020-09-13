using System.Text;

namespace MTSChrzanow.Helpers
{
	class QueryBuilder
	{
		public static string CreateQuery(params string[] p)
		{
			StringBuilder builder = new StringBuilder();
			foreach (string s in p) builder.Append(s);
			return builder.ToString();
		}
	}
}
