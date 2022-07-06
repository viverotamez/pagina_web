using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TiendaViverosTamez.clases
{
    public class seguridad
    {
        public static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
        public static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        public static string _key = "%D*G-KaPdSgVkYp2";

        public static string Encrypt(string stringToEncrypt)
        {
            DES.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_key));
            DES.Mode = CipherMode.ECB;
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);

            return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public static string Decrypt(string encryptedString, string key)
        {
            try
            {
                DES.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_key));
                DES.Mode = CipherMode.ECB;
                byte[] Buffer = Convert.FromBase64String(encryptedString);

                return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}