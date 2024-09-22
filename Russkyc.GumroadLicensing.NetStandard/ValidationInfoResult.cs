namespace Russkyc.GumroadLicensing.NetStandard
{
    public class ValidationInfoResult
    {
        public ValidationInfoResult(bool valid, ValidationInfo validationInfo, string? message = null)
        {
            Valid = valid;
            ValidationInfo = validationInfo;
            Message = message;
        }

        public bool Valid { get; set; }
        public ValidationInfo ValidationInfo { get; set; }
        public string? Message { get; set; }
    }
}