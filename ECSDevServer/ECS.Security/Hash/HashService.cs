using System;
using System.Security.Cryptography;
using System.Text;

namespace ECS.Security.Hash
{
    /// <summary>
    /// Static service class to hash a salted password using SHA 256
    /// </summary>
    public class HashService : IHashService
    {
        // Purpose of writing a Singleton: If we want other Hash services that perform
        // hashing with different algorithms, we need an Interface that controls that
        // allows for multiple objects to have "hashing" capabilities.
        private static HashService _instance;
        private HashService()
        {
        }

        public static HashService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new HashService();
                }
                return _instance;
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
        /// <param name="isPrependSalt"></param>
        public string HashPasswordWithSalt(string salt, string password, bool isPrependSalt)
        {
            string saltedPassword = isPrependSalt ? string.Concat(salt, password) : string.Concat(password, salt);

            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed hasher = new SHA256Managed();
            byte[] hashedBytes = hasher.ComputeHash(encoder.GetBytes(saltedPassword));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}