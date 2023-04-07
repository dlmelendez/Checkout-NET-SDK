﻿
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The name of the party.
    /// </summary>
    [DataContract]
    public class Name
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Name() {}

        /// <summary>
        /// DEPRECATED. The party's alternate name. Can be a business name, nickname, or any other name that cannot be split into first, last name. Required when the party is a business.
        /// </summary>
        [DataMember(Name="alternate_full_name", EmitDefaultValue = false)]
        public string? AlternateFullName;

        /// <summary>
        /// When the party is a person, the party's full name.
        /// </summary>
        [DataMember(Name="full_name", EmitDefaultValue = false)]
        public string? FullName;

        /// <summary>
        /// When the party is a person, the party's given, or first, name.
        /// </summary>
        [DataMember(Name="given_name", EmitDefaultValue = false)]
        public string? GivenName;

        /// <summary>
        /// When the party is a person, the party's middle name. Use also to store multiple middle names including the patronymic, or father's, middle name.
        /// </summary>
        [DataMember(Name="middle_name", EmitDefaultValue = false)]
        public string? MiddleName;

        /// <summary>
        /// The prefix, or title, to the party's name.
        /// </summary>
        [DataMember(Name="prefix", EmitDefaultValue = false)]
        public string? Prefix;

        /// <summary>
        /// The suffix for the party's name.
        /// </summary>
        [DataMember(Name="suffix", EmitDefaultValue = false)]
        public string? Suffix;

        /// <summary>
        /// When the party is a person, the party's surname or family name. Also known as the last name. Required when the party is a person. Use also to store multiple surnames including the matronymic, or mother's, surname.
        /// </summary>
        [DataMember(Name="surname", EmitDefaultValue = false)]
        public string? Surname;
    }
}

