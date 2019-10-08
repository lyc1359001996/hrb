using System;
using System.IO;
using System.Security.Cryptography;
public class Des3
{
    #region CBC模式**
                                public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
    {
                try
        {
                        MemoryStream mStream = new MemoryStream();
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.CBC;                         tdsp.Padding = PaddingMode.PKCS7;                                                                                                                           CryptoStream cStream = new CryptoStream(mStream,
                tdsp.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);
                        cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();
                                                byte[] ret = mStream.ToArray();
                        cStream.Close();
            mStream.Close();
                        return ret;
        }
        catch (CryptographicException e1)
        {
            Log4NetHelper.WriteErrorLog(e1.Message);
            return null;
        }
    }
                                public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
    {
        try
        {
                                    MemoryStream msDecrypt = new MemoryStream(data);
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.CBC;
            tdsp.Padding = PaddingMode.PKCS7;
                                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                tdsp.CreateDecryptor(key, iv),
                CryptoStreamMode.Read);
                        byte[] fromEncrypt = new byte[data.Length];
                                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                        return fromEncrypt;
        }
        catch (CryptographicException e1)
        {
            Log4NetHelper.WriteErrorLog(e1.Message);
            return null;
        }
    }
    #endregion
    #region ECB模式
                                public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
    {
        try
        {
                        MemoryStream mStream = new MemoryStream();
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.PKCS7;
                                    CryptoStream cStream = new CryptoStream(mStream,
                tdsp.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);
                        cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();
                                                byte[] ret = mStream.ToArray();
                        cStream.Close();
            mStream.Close();
                        return ret;
        }
        catch (CryptographicException e1)
        {
            Log4NetHelper.WriteErrorLog(e1.Message);
            return null;
        }
    }
                                public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
    {
        try
        {
                                    MemoryStream msDecrypt = new MemoryStream(data);
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.PKCS7;
                                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                tdsp.CreateDecryptor(key, iv),
                CryptoStreamMode.Read);
                        byte[] fromEncrypt = new byte[data.Length];
                                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                        return fromEncrypt;
        }
        catch (CryptographicException e1)
        {
            Log4NetHelper.WriteErrorLog(e1.Message);
            return null;
        }
    }
    #endregion
                public static void Test()
    {
        System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
        byte[] key = Convert.FromBase64String("YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4");
        byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] data = utf8.GetBytes("中国ABCabc123");
        byte[] str1 = Des3.Des3EncodeECB(key, iv, data);
        byte[] str2 = Des3.Des3DecodeECB(key, iv, str1);
        byte[] str3 = Des3.Des3EncodeCBC(key, iv, data);
        byte[] str4 = Des3.Des3DecodeCBC(key, iv, str3);
    }
}