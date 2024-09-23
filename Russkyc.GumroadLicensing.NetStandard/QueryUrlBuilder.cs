using System;
using System.Collections.Specialized;
using System.Text.Json;

namespace Russkyc.GumroadLicensing.NetStandard
{
    internal class QueryUrlBuilder
    {
        private string? _baseUrl;
        private readonly NameValueCollection _query = new NameValueCollection();

        internal QueryUrlBuilder WithUrl(string url)
        {
            _baseUrl = url;
            return this;
        }

        internal QueryUrlBuilder AddParam<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value).Replace("\"", string.Empty);
            _query.Add(key, serializedValue);
            return this;
        }

        internal string Build()
        {
            if (_baseUrl is null)
            {
                throw new NullReferenceException(
                    "Url cannot be null. please use the .WithUrl() extension to add a url to the builder.");
            }

            return _baseUrl + _query.ToQueryString();
        }
    }
}