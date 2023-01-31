using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Appusion.Core.Common.Utility
{
    public class HashHelper
    {
        public static string HashDocument(string inputFile, string algorithm)
        {
            HashAlgorithm hash = HashAlgorithm.Create("MD5");
            FileStream fileStream = File.OpenRead(inputFile);
            byte[] hashBytes = hash.ComputeHash(fileStream);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
