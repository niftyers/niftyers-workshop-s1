using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.BuildersAPI
{
    public static class Extensions
    {

       
        #region  " To Null String "

        public static string ToNullString(this object obj, string Default = "")
        {
            return obj == null ? Default : obj.ToString();
        }

        #endregion

        #region " To Military Time "

        public static string ToMilitaryTime(this DateTime Obj)
        {
            var RetVal = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                if (Obj == null) return RetVal;
                if (Obj.ToString() == "") return RetVal;
                return Obj.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return RetVal;
            }
        }

        #endregion

        #region " To String Base64 Image "

        public static string ToStringBase64Image(this string ImgPath)
        {
            try
            {
                return Convert.ToBase64String(File.ReadAllBytes(ImgPath));
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region " To JsonFormat "

        public static string DynamicToJson(this object obj, string DefaultValue = "{}")
        {
            var Word = obj.ToString();

            if (Word == null) return DefaultValue;

            var Word1 = Word.Substring(1, 1);
            var Word2 = Word1.Remove(Word1.Length, 1);

            return Word2;
        }

        #endregion

        #region " To Int "

        public static int ToInt(this object Obj, int Default = 0)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToInt32(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Long "

        public static long ToLong(this object Obj, long Default = 0)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToInt64(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Decimal "

        public static decimal ToDecimal(this object Obj, decimal Default = 0.00m)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToDecimal(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Double "

        public static double ToDouble(this object Obj, double Default = 0.00)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToDouble(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Date "

        public static DateTime ToDate(this object Obj)
        {
            try
            {
                if (Obj == null) return DateTime.UtcNow;
                if (Obj.ToString() == "") return DateTime.UtcNow;
                return Convert.ToDateTime(Obj);
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        public static DateTime ToDate(this object Obj, TimeZoneInfo TzServer, TimeZoneInfo TzLocal)
        {
            try
            {
                if (Obj == null) return DateTime.UtcNow;

                var Tym = Convert.ToDateTime(Obj);
                var TymLocal = new DateTime(Tym.Year, Tym.Month, Tym.Day, Tym.Hour, Tym.Minute, Tym.Second);
                var NewTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(TymLocal, TzLocal.Id, TzServer.Id);

                return NewTime;
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        #endregion

        #region " To Boolean "

        public static bool ToBoolean(this object Obj, bool Default = false)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToBoolean(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Mobile Standard "

        public static string ToMobileStandard(this object Obj)
        {
            try
            {
                if (Obj == null) return "";

                var StrNo = Obj.ToString().Replace("+63", "").Replace(" ", "").Replace("-", "");

                if (StrNo.Length.Equals(11))
                {
                    StrNo = StrNo.Substring(1, 10);
                }

                if (!StrNo.Length.Equals(10)) return "";

                return StrNo;
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region " To Max String "

        public static string MaxPhrase(this string Word, int Length)
        {
            if (Word == "") return Word;
            return Word.Substring(0, (Word.Length >= Length ? Length - 1 : Word.Length));
        }

        #endregion

        #region " To CSV "

        public static string ToCSV(this string[] Word, char Delimiter = ',')
        {
            if (Word == null) return "";
            if (Word.AsEnumerable().Count() == 0) return "";
            return string.Join(Delimiter, Word);
        }

        public static string ToCSV(this IEnumerable<string> Word, char Delimiter = ',')
        {
            if (Word == null) return "";
            if (Word.Count() == 0) return "";
            return string.Join(Delimiter, Word);
        }
        public static string ToCSV(this List<string> Word, char Delimiter = ',')
        {
            if (Word == null) return "";
            if (Word.Count() == 0) return "";
            return string.Join(Delimiter, Word);
        }

        #endregion

        #region " To UTC String "

        public static string ToUTCFormat(this DateTime obj)
        {
            return obj.ToString("yyyy-MM-dd T HH:mm:ss");
        }

        #endregion

    }
}