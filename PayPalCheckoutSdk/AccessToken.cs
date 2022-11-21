using System;
using System.Runtime.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class AccessToken
    {
        [DataMember(Name = "access_token")]
        public string Token;

        [DataMember(Name = "token_type")]
        public string TokenType;

        [DataMember(Name = "expires_in")]
        public int ExpiresIn;

        private DateTime createDate;

        public AccessToken()
        {
            createDate = DateTime.Now;
        }

        public bool IsExpired()
        {
            DateTime expireDate = createDate.Add(TimeSpan.FromSeconds(ExpiresIn));
            return DateTime.Now.CompareTo(expireDate) > 0;
        }
    }
}
