
<h2 align="center">Russkyc.GumroadLicensing.NetStandard</h2>

<p style="text-align: justify">
This is a managed .NET client for license validation using the Gumroad API.
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
Code:
```csharp
var licenseInfo = await GumroadLicensing.GetLicenseInfo("<your-product-license>");
```
Serialized LicenseInfo Object (Class Properties are in PascalCase):
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

Code:
```csharp
// Validate License
// Optional Parameters:
// email: default null, validates if provided
// validateSeats: default true (validates uses and seats, does not increment uses if disabled)
// subscription: default true (validates expiration and cancelation of subscription)
var validationInfo = await GumroadLicensing.ValidateLicense("<your-product-license>");
```
Serialized validationInfo Object (Class Properties are in PascalCase):
```json
{
  "Valid": true,
  "ValidationInfo": {
    "seats": 1,
    "uses": 2
  },
  "Message": null
}
```