﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SevenDigital.Api.OAuthConsole.Core.Extensions
{
	public static class CollectionExtensions
	{
		public static IEnumerable<KeyValuePair<string, string>> ToPairs(
			this NameValueCollection collection) {
			if (collection == null) {
				throw new ArgumentNullException("collection");
			}

			return
				collection.Cast<string>().Select(
					key => new KeyValuePair<string, string>(key, collection[(string) key]));
		}
	}
}