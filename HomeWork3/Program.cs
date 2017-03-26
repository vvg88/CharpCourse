using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите строку: ");
                StringHandler strHandler = new StringHandler(Console.ReadLine());
                Console.WriteLine("Строка " + (strHandler.IsStrPalindrome() ? "является" : "не является") + " палиндромом.");
                Console.WriteLine("В строке " + strHandler.NumberOfWords + " слов.");
                Console.WriteLine("Перевернутая строка: " + strHandler.GetReversedString());
                Console.WriteLine("Чтобы продолжить, введите любой символ. Для выхода введите q.");
            }
            while (Console.ReadLine() != "q");
        }

        class StringHandler
        {
            public StringHandler(string initialStr)
            {
                CurrentString = RemoveExtraSpaces(initialStr);
                strForPalindrome = initialStr.RemoveSigns('.', ',', '!', '?', ' ');
                strForPalindrome = strForPalindrome.ToLower();
            }

            #region Fields
            private string CurrentString;

            private int wordsInString;

            private string strForPalindrome;
            #endregion

            public int NumberOfWords
            {
                get { return wordsInString; }
            }

            #region Methods
            
            public bool IsStrPalindrome()
            {
                bool isPalindrom = true;
                for (int i = 0, j = strForPalindrome.Length - 1; i < j; i++, j--)
                {
                    if (strForPalindrome[i] != strForPalindrome[j])
                    {
                        isPalindrom = false;
                        break;
                    }
                }
                return isPalindrom;
            }

            public string GetReversedString()
            {
                var charArray = CurrentString.ToCharArray();
                for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
                {
                    char tempChar = charArray[i];
                    charArray[i] = charArray[j];
                    charArray[j] = tempChar;
                }
                return new string(charArray);
            }

            private string RemoveExtraSpaces(string str)
            {
                var wordsArr = str.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                wordsInString = wordsArr.Length;
                
                string newStr = string.Empty;
                foreach (var word in wordsArr)
                    newStr += word + " ";
                return newStr;
            }
            #endregion
        }
    }

    static class HomeWork3Extention
    {
        public static string RemoveSign(this string str, char sign)
        {
            string temp = string.Copy(str);
            for (int i = 0; i < temp.Length;)
            {
                if (temp[i] == sign)
                {
                    temp = temp.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            return temp;
        }

        public static string RemoveSigns(this string str, params char[] signs)
        {
            string tempStr = string.Copy(str);
            foreach (var sign in signs)
                tempStr = tempStr.RemoveSign(sign);
            return tempStr;
        }
    }
}
