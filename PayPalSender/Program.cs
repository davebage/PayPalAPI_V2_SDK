// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using PayPalAPISDK;
using System;
using System.Net.Http.Headers;
using System.Text;

Console.WriteLine("Hello, World!");
const string clientId = "AfixC4Bq0xQCCQK6Wo5HwPXCdzfSb2rumlhjKtMR-IYHisT_1gcQ9aJofMOuA2FU5jwWEOaiT5_vLgT9";
const string clientSecret = "EPiSekitZfUkoJ3dgcTwnZ_-NRaA8wSl3hoODcrAOlQPNQr4HBohtMtamV2unYaGVn0FClhFkDuCfumv";
var token = new PayPalAuth(clientId, clientSecret).GetToken();

Console.WriteLine($"{token.token_type} {token.access_token}");

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);




//client.DefaultRequestHeaders.Add("Content-Type", "application/json");
client.DefaultRequestHeaders.Add("PayPal-Request-Id", Guid.NewGuid().ToString());

var purchaseUnits = new List<PurchaseUnitRequest>();
purchaseUnits.Add(new PurchaseUnitRequest()
{
    reference_id = Guid.NewGuid().ToString(),
    amount = new Amount()
    {
        value = "100.00",
        currency_code = "USD"
    },
});
var orderBody = new CreateOrderBody
{
    intent = IntentType.AUTHORIZE,
    purchase_units = purchaseUnits,
    payment_source = new Payer
    {
        paypal = new PayPalWallet
        {
            experience_context = new PayPalWalletExperienceContext
            {
                payment_method_preference = PaymentMethodPreferenceType.IMMEDIATE_PAYMENT_REQUIRED,
                brand_name = "brand name",
                cancel_url = "http://example.com/cancelurl",
                landing_page = LandingPageType.NO_PREFERENCE,
                locale = "en-GB",
                return_url = "https://example.com/returnUrl",
                shipping_preference = ShippingPreferenceType.SET_PROVIDED_ADDRESS, 
                user_action = UserActionType.PAY_NOW
            }
        }

    }
};

var json = JsonConvert.SerializeObject(orderBody);
var data = new StringContent(json, Encoding.UTF8, "application/json");
// https://api-m.sandbox.paypal.com/v2/checkout/orders
var response = await client.PostAsync("https://api-m.sandbox.paypal.com/v2/checkout/orders", data);
Console.WriteLine(json);
Console.WriteLine();
var result = await response.Content.ReadAsStringAsync();
Console.WriteLine(result);