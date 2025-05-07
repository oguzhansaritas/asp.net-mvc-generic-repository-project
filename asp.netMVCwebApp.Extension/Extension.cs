using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace asp.netMVCwebApp.Extension
{
    public static class Extention
    {
        public static bool IsEmpty(this string StringBuild)
        {
            return StringBuild == null || string.IsNullOrEmpty(StringBuild);
        }

        public static string ParseToImageFileNameFormat(this string fileName)
        {
            fileName = fileName.ToLower();
            fileName = fileName.Replace(":", ""); fileName = fileName.Replace(" ", "");
            fileName = fileName.Replace("ç", "c"); fileName = fileName.Replace("ğ", "g");
            fileName = fileName.Replace("ı", "i"); fileName = fileName.Replace("ö", "o");
            fileName = fileName.Replace("ş", "s"); fileName = fileName.Replace("ü", "u");
            fileName = fileName.Replace("(", ""); fileName = fileName.Replace(")", "");
            fileName = fileName.Replace("{", ""); fileName = fileName.Replace("}", "");
            fileName = fileName.Replace("%", ""); fileName = fileName.Replace("&", "");
            fileName = fileName.Replace("+", ""); fileName = fileName.Replace(",", "");
            fileName = fileName.Replace("?", ""); fileName = fileName.Replace("'", "");
            fileName = fileName.Replace("ı", "i");
            fileName = fileName.Replace(".html", ""); fileName = fileName.Replace(".htm", "");
            fileName = fileName.Replace(".php", ""); fileName = fileName.Replace(".aspx", "");
            fileName = fileName.Replace(";", "");
            fileName = fileName.Replace(":", ""); fileName = fileName.Replace("%", "");
            fileName = fileName.Replace("\"", "");

            return fileName;

        }//End Method


        /// <summary>
        /// Kart Numarası Parse Etme
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static string ParseToCardNumber(this string cardNumber)
        {
            string newCardNumber = string.Empty;
            if (cardNumber.Length == 16)
            {
                for (int i = 0; i < cardNumber.Length; i++)
                {
                    if (i < 4 || i > 11)
                        newCardNumber += cardNumber.Substring(i, 1);
                    else
                        newCardNumber += "#";
                }
            }
            else
            {
                newCardNumber = cardNumber;
            }
            return newCardNumber;
        }


        public static string ParseToStringForPrice(this decimal price)
        {
            return price.ToString("N2", new CultureInfo("en-US")).Replace(",", "").Replace(".", ",");
        }

        public static string ParseToStringForPrice(this decimal price, string format)
        {
            return price.ToString(format, new CultureInfo("en-US")).Replace(",", "").Replace(".", ",");
        }


        /// <summary>
        /// Verilen Metni Asp.Net url formatına çevirir.
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns></returns>
        public static string ParseToAspUrlFormat(this string url)
        {
            string Adres = url.ToLower();

            Adres = Adres.Replace(" ", "-"); Adres = Adres.Replace(":", "");
            Adres = Adres.Replace("ç", "c"); Adres = Adres.Replace("ğ", "g");
            Adres = Adres.Replace("ı", "i"); Adres = Adres.Replace("ö", "o");
            Adres = Adres.Replace("ş", "s"); Adres = Adres.Replace("ü", "u");
            Adres = Adres.Replace("(", ""); Adres = Adres.Replace(")", "");
            Adres = Adres.Replace("{", ""); Adres = Adres.Replace("}", "");
            Adres = Adres.Replace("%", ""); Adres = Adres.Replace("&", "");
            Adres = Adres.Replace("+", ""); Adres = Adres.Replace(",", "");
            Adres = Adres.Replace("?", ""); Adres = Adres.Replace("'", "-");
            Adres = Adres.Replace("ı", "i"); Adres = Adres.Replace("#", "sharp");
            Adres = Adres.Replace(".html", ""); Adres = Adres.Replace(".htm", "");
            Adres = Adres.Replace(".php", "");
            Adres = Adres.Replace(".", "_");
            Adres = Adres.Replace(";", "-");
            Adres = Adres.Replace(":", "-");
            Adres = Adres.Replace("%", "");
            Adres = Adres.Replace("\"", "");
            Adres = Adres.Replace("_aspx", ".aspx");
            if (Adres.Length >= 5 && Adres.Substring(0, 1) != "/")
            {
                Adres = "/" + Adres;
            }


            return Adres;
        }//End Method




        public static string ParseToPayUFormat(this string url)
        {
            string payUValue = url.ToLower();

            payUValue = payUValue.Replace(":", "");
            payUValue = payUValue.Replace("ç", "c"); payUValue = payUValue.Replace("ğ", "g");
            payUValue = payUValue.Replace("ı", "i"); payUValue = payUValue.Replace("ö", "o");
            payUValue = payUValue.Replace("ş", "s"); payUValue = payUValue.Replace("ü", "u");
            payUValue = payUValue.Replace("(", ""); payUValue = payUValue.Replace(")", "");
            payUValue = payUValue.Replace("{", ""); payUValue = payUValue.Replace("}", "");
            payUValue = payUValue.Replace("%", ""); payUValue = payUValue.Replace("&", "");
            payUValue = payUValue.Replace("+", ""); payUValue = payUValue.Replace(",", "");
            payUValue = payUValue.Replace("?", ""); payUValue = payUValue.Replace("/", "");
            payUValue = payUValue.Replace("ı", "i"); payUValue = payUValue.Replace("\"", "");

            payUValue = payUValue.ToUpper(new CultureInfo("en-US"));

            return payUValue;

        }//End Method

        /// <summary>
        /// T.C. Kimlik Numarası Doğrulama
        /// </summary>
        /// <param name="tcKimlikNo">TC Kimlik Numarası</param>
        /// <returns></returns>
        public static bool IsTcKimlik(this string tcKimlikNo)
        {
            bool returnvalue = false;

            if (tcKimlikNo.Length == 11)
            {
                char[] charlar = tcKimlikNo.ToCharArray(0, 10);
                int sayi = 0;

                foreach (char item in charlar)
                {
                    sayi += int.Parse(item.ToString());
                }
                string sayistr = sayi.ToString();

                if (sayistr.Substring(sayistr.Length - 1) == tcKimlikNo.Substring(10))
                {
                    returnvalue = true;
                }
            }
            return returnvalue;
        }


        /// <summary>
        /// String bir ifadeyi MD5 formatına Çevirmek
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ParseToMD5(this string value)
        {
            //md5 şifrelenmesi için verimizin byte haline gelmesi gerekli. 
            //veri 8-bit şeklinde dönüştürülmesi için ilk önce UTF fonksiyonuna gönderiliyor. 
            UTF8Encoding encoder = new UTF8Encoding();

            //md5 şifrelemesi için nesnemizi oluşturuyoruz. 
            MD5 md5 = new MD5CryptoServiceProvider();

            //verimizi md5 ile çalıştırıyoruz. 
            //dikkat ederseniz UTF fonksiyonundan dönen değeri GetBytes ile alabildik. 
            byte[] donenDeger = md5.ComputeHash(encoder.GetBytes(value));

            //şifrelenmiş değerimizi geri gönderiyoruz. 
            return Convert.ToBase64String(donenDeger);
        }

        /// <summary>
        /// String bir değeri İnteger a çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "0" sayısı döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ParseToInt(this string value)
        {
            int newValue;
            if (Int32.TryParse(value, out newValue))
            {
                return newValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// String bir değeri decimal a çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "0" sayısı döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ParseToDec(this string value)
        {
            decimal newValue;
            value = value.Replace(",", ".");
            if (decimal.TryParse(value, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out newValue))
            {
                return newValue;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// String bir değeri double a çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "0" sayısı döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ParseToDouble(this string value)
        {
            double newValue;
            if (double.TryParse(value, out newValue))
            {
                return newValue;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// String bir değeri DateTime formatına çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "DateTime.Now" zaman değeri döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ParseToDateTime(this string value)
        {
            DateTime newValue;
            if (DateTime.TryParse(value, out newValue))
            {
                return newValue;
            }
            else
            {
                return DateTime.Now;
            }
        }


        /// <summary>
        /// String bir değeri integer a çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "defaultvalue" değeri döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultvalue">Eğer çevrim yapılamaz ise dönmesi istenen değer</param>
        /// <returns></returns>
        public static int ParseToInt(this string value, int defaultvalue)
        {
            if (Int32.TryParse(value, out defaultvalue))
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return defaultvalue;
            }
        }

        /// <summary>
        /// String bir değeri boolean 'e çevirir.Eğer çevrim sırasında Exception oluşur ise geriye "defaultvalue" değeri döndürülür.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultvalue">Eğer çevrim yapılamaz ise dönmesi istenen değer</param>
        /// <returns></returns>
        public static bool ParseToBoolean(this string value, bool defaultvalue)
        {
            if (Boolean.TryParse(value, out defaultvalue))
            {
                return Convert.ToBoolean(value);
            }
            else
            {
                return defaultvalue;
            }
        }

        /// <summary>
        /// String türünden bir listesi istenen ayraç ile ayırarak string e dönüştürür.
        /// </summary>
        /// <param name="stringList">String Liste</param>
        /// <param name="seperate">Kullanılacak Ayraç</param>
        /// <returns></returns>
        public static string GetStringList(this List<string> stringList, char seperate)
        {
            string valueList = "";
            foreach (string number in stringList)
            {
                if (valueList.Length > 0)//Daha önceden numara var ise
                    valueList += (seperate + number);
                else//ilk numara girişi ise
                    valueList = number;
            }//End Foreach

            return valueList;

        }//End Method

        public static T ParseEnum<T>(this string token)
        {
            return (T)Enum.Parse(typeof(T), token);
        }

    }//end class
}//end namespace