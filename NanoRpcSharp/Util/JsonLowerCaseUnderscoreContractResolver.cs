﻿namespace NanoRpcSharp.Util
{
    using System;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Thanks to http://stackoverflow.com/questions/18051395/custom-json-net-contract-resolver-for-lowercase-underscore-to-camelcase
    /// </summary>
    public class JsonLowerCaseUnderscoreContractResolver : DefaultContractResolver
    {
        private readonly Regex regex = new Regex("(?!(^[A-Z]))([A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            return regex.Replace(propertyName, "_$2").ToLower();
        }
    }
}
