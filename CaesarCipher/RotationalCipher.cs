using System.Linq;
using System.Text;

namespace CaesarCipher
{
    public class RotationalCipher
    {
        public string EncryptText(string text, int shiftKey)
        {
            var sb = new StringBuilder();
            foreach (var ch in text)
            {
                sb.Append(EncryptChar(ch, shiftKey));
            }

            return sb.ToString();
        }
        
        public char EncryptChar(char character, int shiftKey)
        {
            if (!char.IsLetter(character))
            {
                return character;
            }
            
            int unicodeBase = character < 91 ? 65 : 97;
            int difference = character - unicodeBase;
            char result = (char) (unicodeBase + Mod(difference + shiftKey, 26));

            return result;
        }

        private int Mod(int divident, int divisor)
        {
            int tmpResult = divident % divisor;
            int result = tmpResult < 0 ? tmpResult + divisor : tmpResult;
            
            return result;
        }
    }
}