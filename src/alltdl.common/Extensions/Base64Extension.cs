/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Text;

namespace alltdl.Extensions
{
    /// <summary>
    /// Base64 extension
    /// </summary>
    public static class Base64Extension
    {
        /// <summary>
        /// Decode and convert the string from Base64 text.
        /// </summary>
        /// <param name="base64EncodedData">Base64 text.</param>
        /// <returns>A plain text string.</returns>
        public static string DecodeFromBase64String(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);

            return Encoding.UTF8.GetString(base64EncodedBytes, 0, base64EncodedBytes.Length);
        }

        /// <summary>
        /// Encode and covert the string to Base64 text.
        /// </summary>
        /// <param name="plainText">Plain text.</param>
        /// <returns>An encoded base64 string.</returns>
        public static string EncodeToBase64String(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}