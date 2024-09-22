using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Russkyc.GumroadLicensing.NetStandard
{
    internal static class HttpClientExtensions
    {
        internal static async Task<LicenseInfo> PostLisenseInfoAsync(this HttpClient client, string requestUri, object? content = null)
        {
            HttpResponseMessage? response;
            string? responseContent;
            dynamic dynamicContent;
            dynamic? license;
            
            if (content != null)
            {
                var serializedContent = JsonSerializer.Serialize(content);
                response = await client.PostAsync(requestUri, new StringContent(serializedContent));
                responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent == null)
                {
                    return default!;
                }

                dynamicContent = JsonSerializer.Deserialize<JsonObject>(responseContent)!;
                
                license = JsonSerializer.Deserialize<LicenseInfo>(dynamicContent["purchase"]) ?? default!;
                license.Uses = (int)dynamicContent["uses"];
                
                return license;
            }

            response = await client.PostAsync(requestUri, new StringContent(String.Empty));
            responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null)
            {
                return default!;
            }

            dynamicContent = JsonSerializer.Deserialize<JsonObject>(responseContent)!;
            
            license = JsonSerializer.Deserialize<LicenseInfo>(dynamicContent["purchase"]) ?? default!;
            license.Uses = (int)dynamicContent["uses"];
            
            return license;
        }
    }
}