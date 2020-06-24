using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * ClientFactory.cs - static methods relating to Client creation and hash/salt validation and generation
 * 30010353
 */

namespace SocketServer.clients
{
    class ClientFactory
    {
        // Client factory methods

        public static AdminClient NewAdmin(string user, string pass)
        {
            AdminClient returnClient;
            returnClient = new AdminClient()
            {
                Salt = Salt(),
                User = user
            };
            returnClient.Hash = Hash(pass, returnClient.Salt);

            return returnClient;
        }

        public static RegisteredClient NewUser(string user, string pass)
        {
            RegisteredClient returnClient;
            returnClient = new RegisteredClient()
            {
                Salt = Salt(),
                User = user
            };
            returnClient.Hash = Hash(pass, returnClient.Salt);

            return returnClient;
        }

        public static Guest NewGuest(string user, string pass)
        {
            Guest returnClient;
            returnClient = new Guest()
            {
                Salt = Salt(),
                User = user
            };
            returnClient.Hash = Hash(pass, returnClient.Salt);

            return returnClient;
        }

        // end factory methods


        // Hashing methods
        public static byte[] Salt()
        {
            var rnd = new RNGCryptoServiceProvider();
            var buffer = new byte[10];
            rnd.GetBytes(buffer);
            
            return buffer;
        }

        public static byte[] Hash(string pass, byte[] salt)
        {
            byte[] _pass = Encoding.ASCII.GetBytes(pass);
            byte[] passAndSalt = new byte[_pass.Length + salt.Length];

            // Copy password to first half of byte[]
            Buffer.BlockCopy(_pass, 0, passAndSalt, 0, _pass.Length);
            // Then add the salt to the remainder
            Buffer.BlockCopy(salt, 0, passAndSalt, _pass.Length, salt.Length);

            // use SHA256 hashing algorithm
            SHA256Managed _hash = new SHA256Managed();
            byte[] hash = _hash.ComputeHash(passAndSalt);

            return hash;
        }

        public static bool Matches(string pass, byte[] salt, byte[] hash)
        {
            // generate the hash from given pass and salt
            byte[] genHash = Hash(pass, salt);

            // if the lengths dont match, we can return false
            if (genHash.Length != hash.Length)
                return false;

            // loop through the hashes and check if each byte matches
            for (int i = 0; i < genHash.Length; i++)
            {
                if (genHash[i] != hash[i])
                    return false;
            }

            // if the program got to here, the hashes match
            return true;
        }
        
    }
}
