using System.Text.Json.Serialization;

namespace Russkyc.GumroadLicensing.NetStandard
{
    public class ValidationInfo
    {
        
        [JsonPropertyName("seats")]
        public int Seats { get; set; }
        
        [JsonPropertyName("uses")]
        public int Uses { get; set; }

    }
}