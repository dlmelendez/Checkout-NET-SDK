using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Force.Crc32;

namespace PayPalCheckoutSdk.Webhooks
{
    public static class VerifyWebhookEvent
    {
        private const string WithRSAToken = "withRSA";

        public static async Task<bool> ValidateReceivedEventAsync(VerifyWebhookSignature verifySignature)
        {
            if (string.IsNullOrWhiteSpace(verifySignature.TransmissionTime))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.TransmissionTime)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.TransmissionId))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.TransmissionId)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.TransmissionSig))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.TransmissionSig)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.AuthAlgo))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.AuthAlgo)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.CertUrl))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.CertUrl)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.WebhookEventRequestBody))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.WebhookEventRequestBody)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(verifySignature.WebhookId))
            {
                throw new ArgumentNullException(nameof(verifySignature), $"{nameof(verifySignature.WebhookId)} is null or empty");
            }

            // Convert the provided auth alrogithm header into a known hash alrogithm name.
            if (!verifySignature.AuthAlgo.EndsWith(WithRSAToken))
            {
                throw new ArgumentException($"{nameof(verifySignature.AuthAlgo)} must end with {WithRSAToken}", nameof(verifySignature));
            }
            string hashAlgorithm = verifySignature.AuthAlgo.Replace(WithRSAToken, "");
            string? oid = CryptoConfig.MapNameToOID(hashAlgorithm);
            if (string.IsNullOrWhiteSpace(oid))
            {
                throw new Exception($"Invalid OID from {hashAlgorithm}");
            }
            // Calculate a CRC32 checksum using the request body.
            byte[] bytes = Encoding.UTF8.GetBytes(verifySignature.WebhookEventRequestBody);
            uint crc32 = Crc32Algorithm.Compute(bytes);

            // Generate the expected signature.
            var expectedSignature = string.Format("{0}|{1}|{2}|{3}", verifySignature.TransmissionId, verifySignature.TransmissionTime, verifySignature.WebhookId, crc32);
            var expectedSignatureBytes = Encoding.UTF8.GetBytes(expectedSignature);

            // Get the cert from the cache and load the trusted certificate.
            using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            byte[] certificateBytes = await httpClient.GetByteArrayAsync(verifySignature.CertUrl);

            X509Certificate2Collection remoteCertificateCollection = new X509Certificate2Collection();
            remoteCertificateCollection.Import(certificateBytes);

            using var publicCertStream = typeof(Event).Assembly.GetManifestResourceStream("PayPalCheckoutSdk.Webhooks.DigiCertSHA2ExtendedValidationServerCA.crt");
            byte[] resourceBytes = new byte[publicCertStream!.Length];
            _ = await publicCertStream.ReadAsync(resourceBytes, 0, resourceBytes.Length);

            X509Certificate2 publicLocalCertificate = new X509Certificate2(resourceBytes);
            // Create and configure the X509Chain object
            using X509Chain chain = new X509Chain();
            chain.ChainPolicy.RevocationMode = X509RevocationMode.Online; 
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

            bool validateRemoteCert = chain.Build(remoteCertificateCollection[0]);
            if (!validateRemoteCert)
            {
                throw new Exception($"Invalid chain on remote certificate {verifySignature.CertUrl}");
            }

            // Validate the certificate chain.
            bool validateChain = chain.ChainElements.Any(a => a.Certificate.Thumbprint == publicLocalCertificate.Thumbprint);
            if (!validateChain)
            {
                throw new Exception($"Invalid remote certificate, public key not found in chain {verifySignature.CertUrl}");
            }

            // Verify the received signature matches the expected signature.
            using var rsa = remoteCertificateCollection[0].GetRSAPublicKey() ?? throw new Exception($"GetRSAPublicKey() failed on remote certificate, {verifySignature.CertUrl}");
            var signatureBytes = Convert.FromBase64String(verifySignature.TransmissionSig);
            return rsa.VerifyData(expectedSignatureBytes, signatureBytes, HashAlgorithmName.FromOid(oid), RSASignaturePadding.Pkcs1);

        }
    }
}
