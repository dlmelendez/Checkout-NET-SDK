﻿using System;
using System.Runtime.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class AccessToken
    {
        [DataMember(Name = "access_token")]
        public string? Token { get; set; }

        [DataMember(Name = "token_type")]
        public string? TokenType { get; set; }

        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        private readonly DateTime _createDate;

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
