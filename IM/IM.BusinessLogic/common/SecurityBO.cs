using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace IM.BusinessLogic.common
{
    public class SecurityBO
    {
        string _err = string.Empty;
        private byte[] key = {};
        private byte[] IV = {38, 55, 206, 48, 28, 64, 20, 16};
        private string stringKey = "!5663a#KN";

        #region Security encryptions
        public string EncrypText(string Txt)
        {
            string encystr = string.Empty;
            try
            {
               
                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Encoding.UTF8.GetBytes(Txt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                encystr =  Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                encystr = "";
            }
            return encystr;
        }

        public string decTxt(string txt)
        {
            string decstr = string.Empty;
            try
            {
                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Convert.FromBase64String(txt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                decstr =  Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                _err = ex.ToString();
                decstr = "";
            }
            return decstr;
        }
        #endregion
    }
}
