namespace Russkyc.GumroadLicensing.NetStandard
{
    public class LicenseInfoResult
    {
        public LicenseInfoResult(bool success, LicenseInfo licenseInfo, string? message = null)
        {
            Success = success;
            LicenseInfo = licenseInfo;
            Message = message;
        }

        public bool Success { get; set; }
        public LicenseInfo LicenseInfo { get; set; }
        public string? Message { get; set; }
    }
}