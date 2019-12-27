using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pwnage
{
    public static class PwnedPasswords
    {
        private static readonly IReadOnlyDictionary<string, int> _emptyDictionary = new Dictionary<string, int>();
        private static readonly char[] _newLines = new[] { '\n', '\r' };
        private static readonly char[] _colon = new[] { ':' };

        /// <summary>
        /// Check the Pwned Passwords API to see if the password has been seen in any data breaches.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<(bool passwordCompromised, int breachCount)> CheckPasswordAsync(string password)
        {
            // SHA1 hash the password and return the bytes as a hex string
            var passwordHashString = SHA1HashPassword(password);

            // SHA1 hashes are 160-bits (20 bytes/40 nibbles). 1 nibble encodes a single hex digit, so the resulting 
            //   hex string is 40 characters in length. Pwned Passwords accepts the first 5 characters of the hash
            //   for identifying a range of passwords via k-anonymity, and we use the remaining 35 characters to try
            //   to positiviely identify the password entered by the user in the list of candidates returned by 
            //   Pwned Passwords.
            var hashPrefix = passwordHashString.Substring(startIndex: 0, length: 5);
            var hashSuffix = passwordHashString.Substring(startIndex: 5, length: 35);
            var candidatePasswordHashSuffixes = await GetCandidatePasswordHashSuffixesAsync(hashPrefix);

            if (candidatePasswordHashSuffixes.TryGetValue(hashSuffix, out int breachCount))
            {
                // The password has been in at least one data breach! Uh oh!
                return (true, breachCount);
            }

            // The password has not been in any data breaches tracked by Pwned Passwords.
            return (false, 0);
        }

        /// <summary>
        /// Compute the SHA1 has of the plaintext password and return the bytes as a hex string.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string SHA1HashPassword(string password)
        {
            using var sha1 = SHA1.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var passwordHashBytes = sha1.ComputeHash(passwordBytes);

            return BitConverter.ToString(passwordHashBytes).Replace("-", "");
        }

        /// <summary>
        /// Check Pwned Passwords for potentially matching passwords.
        /// </summary>
        /// <param name="hashPrefix"></param>
        /// <returns></returns>
        private static async Task<IReadOnlyDictionary<string, int>> GetCandidatePasswordHashSuffixesAsync(string hashPrefix)
        {
            var handler = new WebRequestHandler();
            handler.ReadWriteTimeout = 5000;
            using HttpClient HTTPClient = new HttpClient(handler);
            using var response = await HTTPClient.GetAsync($"https://api.pwnedpasswords.com/range/{hashPrefix}");
            if (!response.IsSuccessStatusCode)
            {
                // Request was not successful. Don't crash the calling app; act like nothing was returned.
                return _emptyDictionary;
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            // Split the response into lines. Each line contains a password hash suffix (35 characters) and
            //   the number of times that password has been seen in breaches, separated by a colon (":").
            var lines = responseBody.Split(_newLines, StringSplitOptions.RemoveEmptyEntries);

            var pwnedPasswordInfos = new Dictionary<string, int>(lines.Length);

            foreach (var line in lines)
            {
                var lineSplit = line.Split(_colon, StringSplitOptions.RemoveEmptyEntries);
                if (lineSplit.Length != 2)
                {
                    // Invalid data from API.
                    continue;
                }

                if (!int.TryParse(lineSplit[1], out int breachCount))
                {
                    // Invalid breach count from API.
                    continue;
                }

                // Key: hash suffix; value: breach count.
                pwnedPasswordInfos[lineSplit[0]] = breachCount;
            }

            return pwnedPasswordInfos;
        }
    }
}