using System.Security.Cryptography;
using System.Text;
using System.Reflection;

namespace Pos_API.GlobalAndCommon
{
    public static class Global
    {
        public static readonly string ImagePreURL = "";

		public static void InsertImagePreURL<T>(T item)
		{
			PropertyInfo? imageProperty = typeof(T).GetProperty("Image");
			ChangeImageURL(imageProperty, item);
		}

		public static void InsertImagePreURL<T>(List<T> itemsGroup)
		{
			PropertyInfo? imageProperty = typeof(T).GetProperty("Image");
			foreach (T item in itemsGroup)
			{
				ChangeImageURL(imageProperty, item);
			}
		}

		private static void ChangeImageURL<T>(PropertyInfo? imageProperty, T item)
		{
			if (imageProperty != null && imageProperty.GetValue(item) is string imageValue)
			{
				string modifiedImageUrl = string.Format("{0}{1}", ImagePreURL, imageValue);
				imageProperty.SetValue(item, modifiedImageUrl);
			}
		}

		public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decrypt = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        
    }
}
