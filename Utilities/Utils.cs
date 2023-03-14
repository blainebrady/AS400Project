using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Utilities;

public class Utils
{
    public static decimal dfault { get; set; }
    public static DateTime? datefault { get; set; }

    public static byte[] ByteSafe(string data)
    {
        byte[] outData = new byte[0];
        try
        {
            outData = Array.ConvertAll(data.Split('-'), s => byte.Parse(s, System.Globalization.NumberStyles.HexNumber));
        }
        catch { }
        return outData;
    }
    public static string Encrypt(string clearText)
    {
        string EncryptionKey = "DISOEN58593KDHF";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();
            clearText = System.Convert.ToBase64String(ms.ToArray());

        }
        return clearText;
    }
    public static string Scrub(string token)
    {
        string _out = token.Replace("+", "");
        _out = _out.Replace("%", "");
        _out = _out.Replace("&", "");
        _out = _out.Replace("?", "");
        _out = _out.Replace("+", "");
        _out = _out.Replace("/", "");
        _out = _out.Replace("=", "");

        return _out;
    }
    public static byte[] StreamToBytes(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }

    public static string GetIPAddress()
    {
        string strHostName = Dns.GetHostName();
        IPHostEntry sIPAddress = Dns.GetHostEntry(strHostName);
        IPAddress[] addr = sIPAddress.AddressList;
        string sRet = "";

        if (addr != null)
            if (addr.Length > 1)
                sRet = addr[1].StringSafe();
            else if (addr.Length > 0)
                sRet = addr[0].StringSafe();
            else
                sRet = "127.0.0.1";
        return sRet;
    }

    public static bool IsDate(object value)
    {
        bool bRet = false;
        if (value != null)
        {
            if (value.StringSafe().Length > 0)
            {
                try
                {
                    DateTime dDate = DateTime.MinValue;
                    if (DateTime.TryParse(value.ToString(), out dDate))
                    {
                        if (dDate > DateTime.MinValue)
                            bRet = true;
                    }

                }
                catch { }
            }
        }
        return bRet;
    }
    public static bool IsEmail(object value)
    {
        bool bRet = false;
        string sPattern = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b";
        if (value != null)
            if (Regex.IsMatch(value.StringSafe(), sPattern, RegexOptions.IgnoreCase))
                bRet = true;

        return bRet;
    }

    public static bool IsNumeric(object value)
    {
        bool bRet = false;
        decimal i = 0;
        if (value == null)
            bRet = false;
        else if (value.ToString() == "0")
            bRet = true;
        else if (decimal.TryParse(value.StringSafe(), out i))
        {
            if (i > 0 || (i * -1) > 0)
                bRet = true;
        }

        return bRet;
    }
    public static DateTime Midnight()
    {
        DateTime today = DateTime.Today;
        DateTime searchDate = Utils.ParseDateControlledReturn(today.Month.ToString() + "/" + today.Day.ToString() + "/" + today.Year.ToString() + " 00:00:00");
        return searchDate;
    }
    public static bool ParseNumSafe(object value, out decimal retVal)
    {
        if (value == null)
        {
            retVal = 0;
            return false;
        }
        else if (value.StringSafe().Contains("E+"))
        {
            //this contains scientific notation
            decimal dRet = 0;
            try
            {
                dRet = Decimal.Parse(value.StringSafe(), System.Globalization.NumberStyles.Float);
                retVal = dRet;
                return true;
            }
            catch
            {
                retVal = dRet;
                return false;
            }
        }
        else
            return decimal.TryParse(value.StringSafe(), out retVal);
    }
    public static decimal ParseNumControlledReturn(object value)                    //this returns a controlled return in a single line
    {
        decimal d = 0;
        if (ParseNumSafe(value, out d))
            return d;
        else
            return dfault;
    }
    public static bool ParseDateSafe(object value, out DateTime d)
    {
        return DateTime.TryParse(value.StringSafe(), out d);
    }
    public static bool ParseTimeSafe(object value, out DateTime d)
    {
        return DateTime.TryParse(value.StringSafe(), out d);
    }
    public static DateTime ParseDateControlledReturn(object value)
    {
        DateTime d = DateTime.Parse("01/01/1900");
        if (ParseDateSafe(value, out d))
        {
            if (d < datefault)
                return datefault.Value;
            return d;
        }
        else
        {
            if (datefault == null)
                datefault = DateTime.Parse("01/01/1900");
            return datefault.Value;
        }
    }
    public static string ParseTimeControlledReturn(object value)
    {
        DateTime d = DateTime.Now;
        if (ParseDateSafe(value, out d))
            return d.Hour + ":" + d.Minute + ":" + d.Second;
        else
        {
            if (datefault == null)
                datefault = DateTime.Parse("01/01/1900");
            return d.Hour + ":" + d.Minute + ":" + d.Second;
        }
    }
    public static string FormatNegativeValue(decimal dIn)
    {
        string sRet = string.Format("{0:###,###,###.##}", dIn);
        if (dIn < 0)
            sRet = string.Format("{0:(###,###,###.##)}", 0 - dIn);
        return sRet;
    }
    public static string FormatNegativeDollarValue(decimal dIn)
    {
        string sRet = string.Format("{0:$###,###,###.##}", dIn);
        if (dIn < 0)
            sRet = string.Format("{0:($###,###,###.##)}", 0 - dIn);
        return sRet;
    }
    public static bool ParseBoolSafe(object value)
    {
        bool bRet = false;
        int iRet = 0;
        if (value == null)
            return false;
        try
        {
            if (!bool.TryParse(value.ToString(), out bRet))
            {
                if (int.TryParse(value.ToString(), out iRet))
                {
                    if (Math.Abs(iRet) == 1)
                        bRet = true;
                }
                else                                            //the value is a string
                {
                    if (value.ToString().ToLower() == "true")
                        bRet = true;
                    else if (value.ToString().ToLower() == "t" || value.ToString().ToLower() == "y")
                        bRet = true;
                }
            }
        }
        catch { }

        return bRet;
    }
    //use this to process error results
    public static string ProcessResult(int i)
    {
        string sRet = "Success";
        switch (i)
        {
            case 1:
                sRet = "Company not recognized in the database";
                break;
            case 2:
                sRet = "User already in the database";
                break;
            case 3:
                sRet = "Password does not match";
                break;
            case 4:
                sRet = "Password does not match";
                break;
            case 5:
                sRet = "User does not exist";
                break;
            case 0:
                sRet = "Failure - reason unknown";
                break;

        }

        return sRet;
    }
    public static byte[] ReadToEnd(System.IO.Stream stream)
    {
        long originalPosition = 0;

        if (stream.CanSeek)
        {
            originalPosition = stream.Position;
            stream.Position = 0;
        }

        try
        {
            byte[] readBuffer = new byte[4096];

            int totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;

                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        byte[] temp = new byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }

            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }
        finally
        {
            if (stream.CanSeek)
            {
                stream.Position = originalPosition;
            }
        }
    }
}
