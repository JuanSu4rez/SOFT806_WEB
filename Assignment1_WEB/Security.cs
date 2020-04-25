using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/**
 * Author: Sebastian Suarez
 * Date: 18/04/2020
 * Class used to generate the hash values to validate the login or register a new user
 **/
namespace Assignment1_WEB {
    public class Security {
        public static string getHash(string email, string password) {
            string hashPassword = computeHash(email + password);
            return hashPassword;
        }

        //Method to get the hash value, using SHA512, of a given String
        private static string computeHash(string param) {
            byte[] bytePassword = ASCIIEncoding.ASCII.GetBytes(param);
            HashAlgorithm hashAlgorithm = SHA512.Create();
            byte[] hashBytePassword = hashAlgorithm.ComputeHash(bytePassword);
            return Convert.ToBase64String(hashBytePassword);
        }
    }
}