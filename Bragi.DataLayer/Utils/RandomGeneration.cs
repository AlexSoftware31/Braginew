using System;
using System.Linq;
using System.Text;
using Bragi.DataLayer.ViewModels.Auth;

namespace Bragi.DataLayer.Utils
{
    public static class RandomGeneration
    {
        private static Random random = new Random();
        public static string GenerateApplicationNumber(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string ApplicationMd5Gen(AuthViewModel auth)
        {
            if (string.IsNullOrEmpty(auth.ApplicationCode))
                return string.Empty;
            return CreateMD5($"{auth.ApplicationCode.ToLower()}");
        }
    }
}