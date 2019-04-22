using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cucr.CucrSaas.App.Service {

    /// <summary>
    /// 加密和解密
    /// </summary>
    public class DESEncrypt {

        /// <summary>
        /// 加密解密的key
        /// </summary>
        public const string KEY = "8cd53f117fe2442c91669e06cea53236";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt (string text, string key = KEY) {
            var _key = Encoding.UTF8.GetBytes (key);

            using (var aes = Aes.Create ()) {
                using (var encryptor = aes.CreateEncryptor (_key, aes.IV)) {
                    using (var ms = new MemoryStream ()) {
                        using (var cs = new CryptoStream (ms, encryptor, CryptoStreamMode.Write)) {
                            using (var sw = new StreamWriter (cs)) {
                                sw.Write (text);
                            }
                        }
                        var iv = aes.IV;
                        var encrypted = ms.ToArray ();
                        var result = new byte[iv.Length + encrypted.Length];
                        Buffer.BlockCopy (iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy (encrypted, 0, result, iv.Length, encrypted.Length);

                        return Convert.ToBase64String (result);
                    }
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="keyString"></param>
        /// <returns></returns>
        public static string DecryptString (string cipherText, string keyString = KEY) {
            var fullCipher = Convert.FromBase64String (cipherText);
            var iv = new byte[16];
            var cipher = new byte[16];
            Buffer.BlockCopy (fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy (fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes (keyString);

            using (var aesAlg = Aes.Create ()) {
                using (var decryptor = aesAlg.CreateDecryptor (key, iv)) {
                    string result;
                    using (var msDecrypt = new MemoryStream (cipher)) {
                        using (var csDecrypt = new CryptoStream (msDecrypt, decryptor, CryptoStreamMode.Read)) {
                            using (var srDecrypt = new StreamReader (csDecrypt)) {
                                result = srDecrypt.ReadToEnd ();
                            }
                        }
                    }
                    return result;
                }
            }
        }
    }
}