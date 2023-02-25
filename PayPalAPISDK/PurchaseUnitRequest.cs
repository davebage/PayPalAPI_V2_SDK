using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PayPalAPISDK
{
    public class PurchaseUnitRequest
    {
        public Amount amount;
        public string custom_id;
        public string description;
        public string invoice_id;
        public List<Item> items;
        public Payee payee;
        public PaymentInstruction paymment_instruction;
        public string reference_id;
        public ShippingDetail shipping;
        public string soft_descriptor;


    }

    public class ShippingDetail
    {
        public AddressPortable address;
        public ShippingDetailName name;
        [JsonConverter(typeof(StringEnumConverter))]
        public ShippingDetailType type;

    }

    public enum ShippingDetailType
    {
        SHIPPING,
        PICKUP_IN_PERSON
    }

    public class ShippingDetailName
    {
        public string full_name;
    }

    public class AddressPortable
    {
        public string address_line_1;
        public string address_line_2;
        public string admin_area_1;
        public string admin_area_2;
        public string postal_code;
    }


    public class Payee
    {
        public string email_address;
        public string merchant_id;
    }

    public class PaymentInstruction
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DisbursementModeType disbursement_mode;
        public string payee_pricing_tier_id;
        public string payee_receivable_fx_rate_id;
        public List<PlatformFee> platform_fees;
    }

    public class PlatformFee
    {
        public Amount amount;
        public Payee payee;
    }

    public enum DisbursementModeType
    {
        INSTANT,
        DELAYED
    }
}