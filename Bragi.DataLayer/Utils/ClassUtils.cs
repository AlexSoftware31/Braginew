using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Bragi.DataLayer.Models.Enums;
using QRCoder;

namespace Bragi.DataLayer.Utils
{
    public static class ClassUtils
    {
        public static string GetFromJson(string route)
        {
            try
            {
                using var stream = new StreamReader(route);
                var countriesStream = stream.ReadToEnd();
                return countriesStream;
            }
            catch
            {
                return string.Empty;
            }

        }

        public static LanguageEnum DefineCookieEnum(string culture)
        {
            if (culture == "en-US")
            {
                return LanguageEnum.English;
            }
            if (culture == "ru-RU")
            {
                return LanguageEnum.Russian;
            }
            if (culture == "it-IT")
            {
                return LanguageEnum.Italian;
            }
            if (culture == "pt-PT")
            {
                return LanguageEnum.Portuguese;
            }
            if (culture == "de-DE")
            {
                return LanguageEnum.German;
            }

            if (culture == "fr-FR")
            {
                return LanguageEnum.French;
            }
            return LanguageEnum.Spanish;
        }

        public static LanguageEnum GetLangEnum(string name)
        {
            try
            {
                return (LanguageEnum)Enum.Parse(typeof(LanguageEnum), name);
            }
            catch (Exception)
            {

                return LanguageEnum.Spanish;
            }
        }

        public static Byte[] Generate(string txtToQr)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtToQr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytesCode(qrCodeImage);
        }


        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static T CreateDeepCopy<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
