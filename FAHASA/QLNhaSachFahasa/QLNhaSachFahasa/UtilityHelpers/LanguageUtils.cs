using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace QLNhaSachFahasa.UtilityHelpers
{
    public static class LanguageUtils
    {
        public static void SetLanguage(LanguageCulture lang)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang.Value);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
            catch (Exception) { }
        }
    }
    public class LanguageCulture
    {
        private LanguageCulture(string value) { Value = value; }
        public string Value { get; set; }

        public static LanguageCulture VIETNAMESE { get { return new LanguageCulture("vi-VN"); } }
        public static LanguageCulture ENGLISH { get { return new LanguageCulture("en-US"); } }
    }
}