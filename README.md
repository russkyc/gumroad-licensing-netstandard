
<h2 align="center">Russkyc.GumroadLicensing.NetStandard</h2>

<p align="center">
    <img src="https://img.shields.io/nuget/v/Russkyc.GumroadLicensing.NetStandard?color=1f72de" alt="Nuget">
    <img src="https://img.shields.io/badge/-.NET%20Standard%202.0-blueviolet?color=1f72de&label=NET" alt="">
    <img src="https://img.shields.io/github/license/russkyc/gumroad-licensing-netstandard">
    <img src="https://img.shields.io/github/issues/russkyc/gumroad-licensing-netstandard">
    <img src="https://img.shields.io/nuget/dt/Russkyc.GumroadLicensing.NetStandard">
</p>

<p style="text-align: justify">
This is a managed .NET client for license validation using the Gumroad API. Making Gumroad license key validation for .NET easier to implement.
</p>

## Setup

```csharp
// Imports
using Russkyc.GumroadLicensing.NetStandard;

// !important
// Initialize licensing using product key
// before calling any GetLicenseInfo or ValidateLicense
GumroadLicensing.Initialize("<your-product-id>");
```

### Get License Information

This can be used to get license information from the gumroad api. Do note the following:

- This does not perform license validation.
- This does not increment or decrement license uses.
- Use this only if you need to get information regarding a specific license key.

**Code:**

```csharp
var licenseInfo = await GumroadLicensing.GetLicenseInfo("<your-product-license>");
```
**Serialized LicenseInfo Object (Class Properties are in PascalCase):**
```json
{
  "Success": true,
  "LicenseInfo": {
    "id": "<redacted>",
    "order_number": "<redacted>",
    "sale_id": "<redacted>",
    "sale_timestamp": "2024-09-22T12:36:37Z",
    "created_at": "2024-09-22T12:36:37Z",
    "product_id": "<redacted>",
    "product_name": "<redacted>",
    "short_product_id": "<redacted>",
    "permalink": "<redacted>",
    "product_permalink": "https://<redacted>.gumroad.com/<redacted>",
    "variants": "",
    "license_key": "<redacted>",
    "quantity": 1,
    "uses": 2,
    "price": 1500,
    "currency": "usd",
    "gumroad_fee": 150,
    "email": "<redacted>@gmail.com",
    "purchaser_id": "<redacted>",
    "ip_country": "Philippines",
    "seller_id": "<redacted>",
    "refunded": false,
    "disputed": false,
    "dispute_won": false,
    "chargebacked": false,
    "is_gift_receiver_purchase": false,
    "test": true,
    "referrer": "https://app.gumroad.com/",
    "can_contact": true,
    "discover_fee_charged": false
  },
  "Message": null
}
```

### Validate License

This can be used to verify licenses using the gumroad api. Do note the following:

- This performs license validation only and does not return any additional information except seats and uses.
- Validation fails if the license has been refunded.
- By default, the behavior is set to validate seats and increment the use per validation. If the use is equal to the seats then the validation will fail unless seat validation is disabled.
- If subscription validation is enabled, it will also check if the subscription has been cancelled or expired.
- Use this only if you need to check license key validity.

**Code:**

```csharp
// Validate License
// Optional Parameters:
// email: default null, validates if provided
// validateSeats: default true (validates uses and seats, does not increment uses if disabled)
// subscription: default true (validates expiration and cancelation of subscription)
var validationInfo = await GumroadLicensing.ValidateLicense("<your-product-license>");
```
**Serialized validationInfo Object (Class Properties are in PascalCase):**

```json
{
  "Valid": true,
  "ValidationInfo": {
    "seats": 2,
    "uses": 1
  },
  "Message": null
}
```