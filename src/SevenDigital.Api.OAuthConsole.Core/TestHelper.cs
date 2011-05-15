using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using SevenDigital.Api.OAuthConsole.Core.Extensions;

namespace SevenDigital.Api.OAuthConsole.Core
{
	public static class TestHelper
	{
		public static event EventHandler<EventArgs<string>> OnLogMessage;

		internal static void FireLogMessage(string message) {
			if (OnLogMessage != null) {
				OnLogMessage(null, new EventArgs<string>(message));
			}
		}

		internal static void FireLogMessage(string message, params object[] args) {
			FireLogMessage(String.Format(message, args));
		}

		internal static void DumpNameValueCollection(NameValueCollection pNameValue,
		                                             string pCollectionName) {
			var sb = new StringBuilder();
			Enumerable.ToList<KeyValuePair<string, string>>(pNameValue.ToPairs()
				                                      	.OrderBy(x => x.Key))
				.ForEach(x => sb.Append((string) "{0}={1},".FormatWith(x.Key, x.Value)));

			FireLogMessage("[{1}] : {0}", sb.ToString(), pCollectionName);
		}
	}
}