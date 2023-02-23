using System.Collections.Generic;

namespace PayPalAPISDK
{
    public class CreateOrderBody
    {
        public IntentType intent;

        public List<PurchaseUnitRequest> purchase_units;

        public ApplicationContext application_context;
    }
}