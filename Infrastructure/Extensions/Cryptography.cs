using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class Cryptography
    {
        /// <summary>
        /// Get md5 hash value of the given text
        /// </summary>
        /// <param name="text">Provide a string.</param>
        /// <returns>Md5 hash value of the given text</returns>
        public static string GetMD5(this string text)
        {
            byte[] result;
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            try
            {
                md5Provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                result = md5Provider.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return "";
            }
        }
    }
}
