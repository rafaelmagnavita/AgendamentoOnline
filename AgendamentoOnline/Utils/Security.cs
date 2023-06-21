using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AgendamentoOnline.Utils
{
    public class Security
    {
        public static class PasswordEncryption
        {
            private static readonly string Key = "t^g[p|j#UO(4e.)k";

            public static string EncryptPassword(string password)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

                using (var aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = new byte[16];

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(password);
                            }

                            byte[] encryptedBytes = msEncrypt.ToArray();
                            string encryptedPassword = Convert.ToBase64String(encryptedBytes);

                            return encryptedPassword;
                        }
                    }
                }
            }

            public static string DecryptPassword(string encryptedPassword)
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

                using (var aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = new byte[16];

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new MemoryStream(encryptedBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                string decryptedPassword = srDecrypt.ReadToEnd();
                                return decryptedPassword;
                            }
                        }
                    }
                }
            }
        }
    }
}