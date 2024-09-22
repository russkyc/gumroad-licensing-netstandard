// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Russkyc.GumroadLicensing.NetStandard;

// !important
// Initialize licensing using product key
// before calling any GetLicenseInfo or ValidateLicense
GumroadLicensing.Initialize("<your-product-key>");

// Get License Info (does not increment uses, does not validate license)
var licenseInfo = await GumroadLicensing.GetLicenseInfo("<license-key>");

Console.WriteLine(JsonSerializer.Serialize(licenseInfo));

// Validate License
// Optional Parameters:
// email: default null, validates if provided
// validateSeats: default true (validates uses and seats, does not increment uses if disabled)
// subscription: default true (validates expiration and cancelation of subscription)
var validationInfo = await GumroadLicensing.ValidateLicense("<license-key>", validateSeats: false);

Console.WriteLine(JsonSerializer.Serialize(validationInfo));