using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MovieWiki.Custom_Classes
{
    // Source: https://support.microsoft.com/en-ca/kb/307020
    public static class PasswordHelper
    {
        public static string GetHashedPassword(string password)
        {
            var sha512 = SHA512.Create();
            var plainTextBytes = Encoding.ASCII.GetBytes(password);
            return ByteArrayToString(sha512.ComputeHash(plainTextBytes));
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}