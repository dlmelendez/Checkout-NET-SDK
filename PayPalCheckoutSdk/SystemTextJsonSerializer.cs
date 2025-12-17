using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PayPalHttp;

namespace PayPalCheckoutSdk
{
    public partial class SystemTextJsonSerializer : ISerializer
    {
        private static readonly JsonSerializerOptions _jsonWebOptions = new(JsonSerializerDefaults.Web);
        public static JsonSerializerOptions JsonWebOptions => _jsonWebOptions;

        private const string RegExPattern = MimeTypeConstants.ApplicationJson;
        private static readonly JsonSourceGenerator _jsonWebSourceGenerator = new(_jsonWebOptions);
        public static JsonSourceGenerator JsonWebSourceGenerator => _jsonWebSourceGenerator;

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
