using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CMS.Commons
{
    public class Encryptor
    {
        #region Mã hóa
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        //public static string MaHoa(string key, string toEn)
        //{
        //    byte[] keyArray;
        //    byte[] toEndcry = UTF8Encoding.UTF8.GetBytes(toEn);
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    keyArray = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(key));
        //    TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider();
        //    trip.Key = keyArray;
        //    trip.Mode = CipherMode.ECB;
        //    trip.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform tranform = trip.CreateEncryptor();
        //    byte[] resualArray = tranform.TransformFinalBlock(toEndcry, 0, toEndcry.Length);
        //    return Convert.ToBase64String(resualArray, 0, resualArray.Length);
        //}
        //public static string GiaiMa(string key, string toDe)
        //{
        //    byte[] keyArray = null;
        //    byte[] toEndArray = Convert.FromBase64String(toDe);
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //    TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider();
        //    trip.Key = keyArray;
        //    trip.Mode = CipherMode.ECB;
        //    trip.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform tranfrom = trip.CreateDecryptor();
        //    byte[] resualArray = tranfrom.TransformFinalBlock(toEndArray, 0, toEndArray.Length);
        //    return UTF32Encoding.UTF8.GetString(resualArray);

        //}
        #endregion
    }
}