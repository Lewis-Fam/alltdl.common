using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace alltdl.Utils
{
    public static class HashHelper
    {
        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public static string ConvertToMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(
                Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString(); // Return the hexadecimal string.
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = ConvertToMd5Hash(input); // Hash the input.

            //Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetHash(string fileName)
        {
            //https://stackoverflow.com/questions/16318087/calculate-the-hash-of-the-contents-of-a-file-in-c
            
            using FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 16 * 1024 * 1024);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        #region Hash
        //https://www.iditect.com/faq/csharp/get-a-file-sha256-hash-code-and-checksum-in-c.html

        //This code reads the contents of a file, computes its SHA256 hash using the SHA256 class, and then converts the hash bytes to a hexadecimal string representation.
        public static string CalculateFileHash(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 16 * 1024 * 1024))
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    Console.WriteLine($"SHA256 hash of the file: {hash}");
                    return hash;
                }
            }

        }

        //This snippet calculates the SHA256 checksum for a file and converts the resulting hash bytes to a Base64 string representation.
        public static string CalculateFileCheckSum(string filePath)
        {
            byte[] hashBytes;
            using (var sha256 = SHA256.Create())
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 16 * 1024 * 1024))
                {
                    hashBytes = sha256.ComputeHash(stream);
                }
            }

            string checksum = Convert.ToBase64String(hashBytes);

            return checksum;
        }

        //This code calculates the SHA256 hash of a file and converts it to a hexadecimal string representation.
        public static string CalculateHashAndConvertToHexadecimalString(string filePath)
        {
            string hash;
            using (var sha256 = SHA256.Create())
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 16 * 1024 * 1024))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    return hash;
                }
            }
        }


        //This code computes the SHA256 hash of a file and compares it with an expected hash to verify the file's integrity.
        public static bool CompareHash(string filePath, string expectedHash)
        {
            //string expectedHash = "your_expected_hash";
            using (var sha256 = SHA256.Create())
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 16 * 1024 * 1024))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    string actualHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    bool isIntegrityVerified = string.Equals(actualHash, expectedHash, StringComparison.OrdinalIgnoreCase);
                    Console.WriteLine($"File integrity verified: {isIntegrityVerified}");
                    return isIntegrityVerified;
                }
            }
        }

        #endregion
    }
}