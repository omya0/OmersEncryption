using System.Security.Cryptography;
using System.Text;

namespace Cryption.services
{
    public class crypticservices
    {
        
        public static string Encrypt(string plainText, int shift)
        {
            return ShiftText(plainText, shift);
        }

        
        public static string Decrypt(string cipherText, int shift)
        {
            return ShiftText(cipherText, -shift); 
        }

        private static string ShiftText(string text, int shift)
        {
            shift = shift % 26; 
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    char offset = char.IsUpper(text[i]) ? 'A' : 'a';
                    result[i] = (char)(((text[i] + shift - offset) % 26 + 26) % 26 + offset);
                }
                else
                {
                    result[i] = text[i]; 
                }
            }

            return new string(result);
        }
    }
}
