using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class AccessToken
    {        
        private DateTime _createDate;
        private int expiresIn;

        [DataMember(Name = "access_token")]
        [JsonPropertyName("access_token")]
        public string? Token { get; set; }

        [DataMember(Name = "token_type")]
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [DataMember(Name = "expires_in")]
        [JsonPropertyName("expires_in")]
        public int ExpiresIn 
        { 
            get => expiresIn;
            set 
            { 
                expiresIn = value;
                //Fixes a bug where an implicit cast does not set the _createdDate
                if (_createDate == DateTime.MinValue)
                {
                    _createDate = DateTime.UtcNow;
                }
            }
        }

        /// <summary>
        /// This constructor sometimes does not set the _createdDate 
        /// because the HttpClient does an implicit cast for the result and does not create a new instance of this object
        /// </summary>
        public AccessToken()
        {
            _createDate = DateTime.UtcNow;
        }

        public bool IsExpired()
        {
            DateTime expireDate = _createDate.Add(TimeSpan.FromSeconds(ExpiresIn));
            return DateTime.UtcNow.CompareTo(expireDate) > 0;
        }
    }
}
