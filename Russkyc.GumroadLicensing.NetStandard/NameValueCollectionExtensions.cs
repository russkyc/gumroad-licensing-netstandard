﻿using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Russkyc.GumroadLicensing.NetStandard
{
    internal static class NameValueCollectionExtensions
    {
        internal static string ToQueryString(this NameValueCollection collection)
        {
            var array = (
                from key in collection.AllKeys
                from value in collection.GetValues(key)
                select string.Format(
                    "{0}={1}",
                    HttpUtility.UrlEncode(key),
                    HttpUtility.UrlEncode(value))
            ).ToArray();
            return "?" + string.Join("&", array);
        }
    }
}