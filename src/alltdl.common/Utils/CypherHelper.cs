using System.Security.Cryptography;
using System.Text;

namespace alltdl.Utils
{
    public static class CypherHelper
    {
        /// <summary>Decrypts</summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="key">          The key.</param>
        /// <returns>A string.</returns>
        /// <exception cref="ObjectDisposedException">Ignore.</exception>
        public static string Decrypt(this string encryptedText, string key = "OvxXxfHnykhDn/wYe2/VJW0am9KOADXIO5WuZVDZZG8kQuC5ltiTPgOan/hcHAAC")
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentException("The encrypted text must have valid value.", nameof(encryptedText));

            var combined = Convert.FromBase64String(encryptedText);
            var buffer = new byte[combined.Length];
            using var hash = SHA512.Create();
            var aesKey = new byte[24];

            Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

            using var aes = Aes.Create();
            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));
            try
            {
                aes.Key = aesKey;

                var iv = new byte[aes.IV.Length];
                var ciphertext = new byte[buffer.Length - iv.Length];

                Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
                Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);

                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using var resultStream = new MemoryStream();
                using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                using (var plainStream = new MemoryStream(ciphertext))
                {
                    plainStream.CopyTo(aesStream);
                }

                return Encoding.UTF8.GetString(resultStream.ToArray());
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Error {0}", e);
                return string.Empty;
            }
        }

        /// <summary>Encrypts the.</summary>
        /// <param name="text">The text.</param>
        /// <param name="key"> The key.</param>
        /// <returns>A string.</returns>
        /// <exception cref="RankException">Ignore.</exception>
        /// <exception cref="ArrayTypeMismatchException">Ignore.</exception>
        /// <exception cref="InvalidCastException">Ignore.</exception>
        /// <exception cref="ObjectDisposedException">Ignore.</exception>
        /// <exception cref="IOException">Ignore.</exception>
        public static string Encrypt(this string text, string key = "OvxXxfHnykhDn/wYe2/VJW0am9KOADXIO5WuZVDZZG8kQuC5ltiTPgOan/hcHAAC")
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key must have valid value.", nameof(key));
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("The text must have valid value.", nameof(text));

            var buffer = Encoding.UTF8.GetBytes(text);
            using (var hash = SHA512.Create())
            {
                var aesKey = new byte[24];
                Buffer.BlockCopy(hash.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, aesKey, 0, 24);

                using (var aes = Aes.Create())
                {
                    if (aes == null)
                        throw new ArgumentException("Parameter must not be null.", nameof(aes));

                    aes.Key = aesKey;

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var resultStream = new MemoryStream())
                    {
                        using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                        using (var plainStream = new MemoryStream(buffer))
                        {
                            plainStream.CopyTo(aesStream);
                        }

                        var result = resultStream.ToArray();
                        var combined = new byte[aes.IV.Length + result.Length];
                        Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                        Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);

                        return Convert.ToBase64String(combined);
                    }
                }
            }
        }
    }
}