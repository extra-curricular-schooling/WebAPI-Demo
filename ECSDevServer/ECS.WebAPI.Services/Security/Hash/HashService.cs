using System;
using System.Security.Cryptography;
using System.Text;

namespace ECS.WebAPI.Services.Security.Hash
{
    /// <summary>
    /// Static service class to hash a salted password using SHA 256
    /// </summary>
    public class HashService : IHashService
    {
        private static HashService instance;
        private HashService()
        {
        }

        public static HashService Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new HashService();
                }
                return instance;
            }
        }

        /// <summary>
        /// 64-bit Salt property
        /// </summary>
        private const int SaltSize = 64; 

        /// <summary>
        /// Generates salt
        /// </summary>
        /// <returns>The salt key.</returns>
        public string CreateSaltKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rand = new byte[SaltSize];
            rng.GetBytes(rand);

            return Convert.ToBase64String(rand);
        }

        /// <summary>
        /// Hashes salted password with SHA-256 algorithm.
        /// Returns hashed password with length 44 bits to include padding.
        /// </summary>
        /// <returns>The password with salt.</returns>
        /// <param name="password">Password.</param>
        /// <param name="salt">Salt.</param>
        public string HashPasswordWithSalt(string salt, string password)
        {
            string saltedPassword = String.Concat(salt, password);

            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] hashedBytes = hasher.ComputeHash(encoder.GetBytes(saltedPassword));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}