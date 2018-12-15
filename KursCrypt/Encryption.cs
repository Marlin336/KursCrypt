using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KursCrypt
{
    public static class Encryption
    {
        public static byte[] Key { get; private set; }
        public static byte[] IV { get; private set; }
        public static byte[] EncDES(string intext, byte[] key, byte[] IV)
        {
            if (intext == null || intext.Length == 0)
                throw new ArgumentNullException("intext");
            if (key == null || key.Length == 0)
                throw new ArgumentNullException("key");
            if (IV == null || IV.Length == 0)
                throw new ArgumentNullException("IV");
            byte[] outtext;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ICryptoTransform encryptor = des.CreateEncryptor(key, IV);
                using (MemoryStream mem = new MemoryStream())
                {
                    using (CryptoStream crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(crypto))
                        {
                            writer.Write(intext);
                        }
                        outtext = mem.ToArray();
                    }
                }
            }
            return outtext;
        }
        public static string DecDES(byte[] intext, byte[] key, byte[] IV)
        {
            if (intext == null || intext.Length == 0)
                throw new ArgumentNullException("intext");
            if (key == null || key.Length == 0)
                throw new ArgumentNullException("key");
            if (IV == null || IV.Length == 0)
                throw new ArgumentNullException("IV");
            string outtext;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = IV;
                ICryptoTransform encryptor = des.CreateDecryptor(des.Key, des.IV);
                using (MemoryStream mem = new MemoryStream(intext))
                {
                    using (CryptoStream crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(crypto))
                        {
                            outtext = reader.ReadToEnd();
                        }
                    }
                }
            }
            return outtext;
        }
        public static byte[] EncRSA(byte[] intext, RSAParameters RSAKeyInfo, bool OAEPPadding)
        {
            try
            {
                byte[] outtext;
                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.ImportParameters(RSAKeyInfo);
                    outtext = rsaAlg.Encrypt(intext, OAEPPadding);
                }
                return outtext;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static byte[] DecRSA(byte[] intext, RSAParameters RSAKeyInfo, bool OAEPPadding)
        {
            try
            {
                byte[] outtext;
                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.ImportParameters(RSAKeyInfo);
                    outtext = rsaAlg.Decrypt(intext, OAEPPadding);
                }
                return outtext;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
