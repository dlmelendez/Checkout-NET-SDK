using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PayPalHttp;
using System.Text.Json;

namespace PayPalCheckoutSdk
{
    public partial class SystemTextJsonSerializer : ISerializer
    {
        public static JsonSerializerOptions JsonWebOptions => new JsonSerializerOptions(JsonSerializerDefaults.Web);

        private const string RegExPattern = MimeTypeConstants.ApplicationJson;
        public static JsonSourceGenerator JsonWebSourceGenerator = new JsonSourceGenerator(JsonWebOptions);

        private static readonly Regex _pattern = ContextTypeRegEx();

        public async Task<object?> DecodeAsync(HttpContent content, Type responseType)
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync(await content.ReadAsStreamAsync().ConfigureAwait(false), responseType, options: JsonWebOptions).ConfigureAwait(false);
        }

        public async Task<HttpContent> EncodeAsync(HttpRequest request)
        {
            return await Task.FromResult(new StringContent(System.Text.Json.JsonSerializer.Serialize(request.Body, request.Body.GetType(), options: JsonWebOptions), System.Text.Encoding.UTF8, RegExPattern))
                .ConfigureAwait(false);
        }

        public Regex GetContentRegEx()
        {
            return _pattern;
        }

        public string GetContentTypeRegexPattern()
        {
            return RegExPattern;
        }

        [GeneratedRegex(RegExPattern, RegexOptions.Compiled)]
        private static partial Regex ContextTypeRegEx();
    }
}
