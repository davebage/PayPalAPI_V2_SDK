using System;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayPalAPISDK
{
    public class CreateOrderBody
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public IntentType intent { get; set; }

        public List<PurchaseUnitRequest> purchase_units;

        public Payer payment_source;
    }

    public class Payer
    {
        public PayPalWallet paypal;
    }

    public class PayPalWallet
    {
        public AddressPortable address;
        public string birth_date;
        public string email_address;
        public PayPalWalletExperienceContext experience_context;
        public PayPalWalletName name;

    }

    public class PayPalWalletExperienceContext
    {
        public string brand_name;
        public string cancel_url;
        public string return_url;
        [JsonConverter(typeof(StringEnumConverter))]
        public LandingPageType landing_page;
        public string locale;
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethodPreferenceType payment_method_preference;
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingPreferenceType shipping_preference;
        [JsonConverter(typeof(StringEnumConverter))]
        public UserActionType user_action;
    }

    public enum UserActionType
    {
        CONTINUE,
        PAY_NOW
    }

    public enum ShippingPreferenceType
    {
        GET_FROM_FILE,
        NO_SHIPPING,
        SET_PROVIDED_ADDRESS
    }

    public enum PaymentMethodPreferenceType
    {
        UNRESTRICTED,
        IMMEDIATE_PAYMENT_REQUIRED
    }

    public enum LandingPageType
    {
        LOGIN,
        GUEST_CHECKOUT,
        NO_PREFERENCE
    }

    public class PayPalWalletName
    {
        public string given_name;
        public string surname;
    }
}