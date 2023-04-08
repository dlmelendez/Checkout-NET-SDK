using System;
using System.Collections.Generic;
using System.Text;

namespace PayPalCheckoutSdk
{
    public static class MimeTypeConstants
    {
        public const string ApplicationJson = "application/json";
    }

    public static class HeaderNameConstants
    {
        public const string PayPalPartnerAttributionId = "PayPal-Partner-Attribution-Id";
        public const string Prefer = "Prefer";
        public const string PayPalRequestId = "PayPal-Request-Id";
        public const string PayPalClientMetadataId = "PayPal-Client-Metadata-Id";

        public static class VerifySignature
        {
            public const string AuthAlgo = "PAYPAL-AUTH-ALGO";
            public const string CertUrl = "PAYPAL-CERT-URL";
            public const string TransmissionId = "PAYPAL-TRANSMISSION-ID";
            public const string TransmissionSig = "PAYPAL-TRANSMISSION-SIG";
            public const string TransmissionTime = "PAYPAL-TRANSMISSION-TIME";
        }
    }
    public static class HeaderValueConstants
    {
        public const string PreferValueMinimal = "return=minimal";
        public const string PreferValueRepresentation = "return=representation";
    }
}
