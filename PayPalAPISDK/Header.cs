namespace PayPalAPISDK
{
    public class Header
    {
        public string PayPalClientMetadataId { get; set; }
        public string PayPalPartnerAttributionId { get; set; }
        public string PayPalRequestId { get; set; }
        public PreferType Prefer { get; set; }
        public string Authorization { get; set; }
        public string ContentType => "application/json";

    }
}