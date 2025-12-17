
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
    /// <summary>
    /// Experimental, not all types are added into the <see cref="JsonSourceGenerator"/>
    /// There is an issue with adding <see cref="List{Core.Patch{T}}" for example/>
    /// </summary>
    public partial class SystemTextJsonWithContextSerializer : ISerializer
    {
        private static readonly JsonSerializerOptions _jsonWebOptions = new(JsonSerializerDefaults.Web);
        public static JsonSerializerOptions JsonWebOptions => _jsonWebOptions;

        private const string RegExPattern = MimeTypeConstants.ApplicationJson;
        private static readonly JsonSourceGenerator _jsonWebSourceGenerator = new(_jsonWebOptions);
        public static JsonSourceGenerator JsonWebSourceGenerator => _jsonWebSourceGenerator;

        private static readonly Regex _pattern = ContextTypeRegEx();

        public async Task<object?> DecodeAsync(HttpContent content, Type responseType)
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync(await content.ReadAsStreamAsync().ConfigureAwait(false), responseType, context: JsonWebSourceGenerator)
                .ConfigureAwait(false);
        }

        public async Task<HttpContent> EncodeAsync(HttpRequest request)
        {            
            return await Task.FromResult(new StringContent(System.Text.Json.JsonSerializer.Serialize(request.Body, request.Body.GetType(), context: JsonWebSourceGenerator), System.Text.Encoding.UTF8, RegExPattern))
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
