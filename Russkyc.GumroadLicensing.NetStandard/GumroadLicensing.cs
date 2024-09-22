using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace Russkyc.GumroadLicensing.NetStandard
{
    public static class GumroadLicensing
    {
        private const string ApiEndpoint = "https://api.gumroad.com/v2/licenses/verify";
        private static string? _productId;

        public static void Initialize(string productId)
        {
            _productId = productId;
        }

        public static async Task<ValidationInfoResult> ValidateLicense(string licenseKey, string? email = null,
            bool validateSeats = true, bool subscription = false)
        {
            if (_productId is null)
            {
                return new ValidationInfoResult(false, null!,
                    "ProductId is not set. Please call the GumroadLicensing.Initialize() method anywhere in the startup before you call the verify method.");
            }

            var client = new HttpClient();

            var validateInfo = await GetLicenseInfo(licenseKey);

            if (!validateInfo.Success)
            {
                return new ValidationInfoResult(false, null!);
            }

            var licenseInfo = validateInfo.LicenseInfo;

            if (email != null && !licenseInfo.Email.Equals(email))
            {
                return new ValidationInfoResult(false, new ValidationInfo()
                {
                    Seats = licenseInfo.Quantity,
                    Uses = licenseInfo.Uses
                }, "Email does not match the email used by the license.");
            }

            if (licenseInfo.Chargebacked || licenseInfo.DisputeWon)
            {
                return new ValidationInfoResult(false, new ValidationInfo()
                {
                    Seats = licenseInfo.Quantity,
                    Uses = licenseInfo.Uses
                }, "License has been revoked as per user request.");
            }

            if (validateSeats && licenseInfo.Uses >= licenseInfo.Quantity)
            {
                return new ValidationInfoResult(false, new ValidationInfo()
                {
                    Seats = licenseInfo.Quantity,
                    Uses = licenseInfo.Uses
                }, "All license seats have been used.");
            }

            if (subscription)
            {
                if (licenseInfo.SubscriptionCancelledAt != null && DateTime.Now < licenseInfo.SubscriptionCancelledAt)
                {
                    return new ValidationInfoResult(false, new ValidationInfo()
                    {
                        Seats = licenseInfo.Quantity,
                        Uses = licenseInfo.Uses
                    }, "License subscription has been cancelled.");
                }

                if (licenseInfo.SubscriptionEndedAt != null && DateTime.Now < licenseInfo.SubscriptionEndedAt)
                {
                    return new ValidationInfoResult(false, new ValidationInfo()
                    {
                        Seats = licenseInfo.Quantity,
                        Uses = licenseInfo.Uses
                    }, "License subscription has ended.");
                }

                if (licenseInfo.SubscriptionFailedAt != null && DateTime.Now < licenseInfo.SubscriptionFailedAt)
                {
                    return new ValidationInfoResult(false, new ValidationInfo()
                    {
                        Seats = licenseInfo.Quantity,
                        Uses = licenseInfo.Uses
                    }, "Failed to process license subscription renewal.");
                }
            }

            try
            {
                var queryBuilder = new QueryUrlBuilder()
                    .WithUrl(ApiEndpoint)
                    .AddParam("product_id", _productId)
                    .AddParam("license_key", licenseKey);

                if (!validateSeats)
                {
                    queryBuilder.AddParam("increment_uses_count", false);
                }

                var query = queryBuilder.Build();

                var response = await client.PostLisenseInfoAsync(query);

                var result = new ValidationInfoResult(!validateSeats || response.Uses <= response.Quantity,
                    new ValidationInfo()
                    {
                        Seats = licenseInfo.Quantity,
                        Uses = licenseInfo.Uses
                    });
                return result;
            }
            catch (RuntimeBinderException)
            {
                return new ValidationInfoResult(false, null!);
            }
        }

        public static async Task<LicenseInfoResult> GetLicenseInfo(string licenseKey)
        {
            if (_productId is null)
            {
                return new LicenseInfoResult(false, null!,
                    "ProductId is not set. Please call the GumroadLicensing.Initialize() method anywhere in the startup before you call the verify method.");
            }

            var client = new HttpClient();

            try
            {
                var query = new QueryUrlBuilder()
                    .WithUrl(ApiEndpoint)
                    .AddParam("product_id", _productId)
                    .AddParam("license_key", licenseKey)
                    .AddParam("increment_uses_count", false)
                    .Build();

                var response = await client.PostLisenseInfoAsync(query);
                var result = new LicenseInfoResult(true, response);
                return result;
            }
            catch (RuntimeBinderException)
            {
                return new LicenseInfoResult(false, null!);
            }
        }
    }
}