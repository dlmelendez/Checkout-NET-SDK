#if NET7_0_OR_GREATER

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
        public static JsonSerializerOptions JsonWebOptions => new JsonSerializerOptions(JsonSerializerDefaults.Web);

        private const string RegExPattern = MimeTypeConstants.ApplicationJson;
        public static JsonSourceGenerator JsonWebSourceGenerator = new JsonSourceGenerator(JsonWebOptions);

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

#endif
