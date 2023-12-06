using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Infrastructure.Common.Extensions
{
	public static class StringExtensions
	{
		public static string ToStringItems<T>(this IEnumerable<T> items, string seperator = ",")
		{
			return items != null ? string.Join(seperator, items) : null;
		}
	}
}
