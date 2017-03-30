using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    /// <summary>
    /// Класс обработчик
    /// </summary>
    class StringHandler
    {
        public StringHandler(string initialStr)
        {
            currentString = initialStr;
            wordsInString = CountWords();

            char[] oddSymbols = initialStr.Where((ch) => { return !char.IsLetterOrDigit(ch); }).ToArray();
            strForPalindrome = initialStr.RemoveSigns(oddSymbols);     // Для строки, по которой определяется является ли строка палиндромом, удалить знаки препинания, пробелы и прочие лишние символы
            strForPalindrome = strForPalindrome.ToLower();             // и привести все буквы к нижнему регистру
        }

        #region Fields
        /// <summary>
        /// Текущая строка
        /// </summary>
        private string currentString;

        /// <summary>
        /// Число слов в строке
        /// </summary>
        private uint wordsInString;

        /// <summary>
        /// Строка для определения, является ли исходная палиндромом
        /// </summary>
        private string strForPalindrome;
        #endregion

        /// <summary>
        /// Свойство, которое возвращает число слов в строке
        /// </summary>
        public uint NumberOfWords
        {
            get { return wordsInString; }
        }

        #region Methods

        /// <summary>
        /// Метод определения, является ли строка палиндромом
        /// </summary>
        /// <returns> Признак, является ли строка палиндромом </returns>
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

        /// <summary>
        /// Перевернуть строку задом на перед
        /// </summary>
        /// <returns></returns>
        public string GetReversedString()
        {
            var charArray = currentString.ToCharArray();
            for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
            {
                char tempChar = charArray[i];
                charArray[i] = charArray[j];
                charArray[j] = tempChar;
            }
            return new string(charArray);
        }
        
        /// <summary>
        /// Метод считает слова в исходной строке
        /// </summary>
        /// <returns></returns>
        private uint CountWords()
        {
            List<char> separators = new List<char>();

            foreach (char symb in currentString)
            {
                if (!char.IsLetterOrDigit(symb))
                    separators.Add(symb);
            }

            return (uint)currentString.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries).Length;
        }
        #endregion
    }

    /// <summary>
    /// Методы расширения для работы со строками
    /// </summary>
    static class HomeWork3Extention
    {
        /// <summary>
        /// Удалить указанный символ
        /// </summary>
        /// <param name="str"> Исходная строка </param>
        /// <param name="sign"> Удаляемый символ </param>
        /// <returns> Строка без указанного символа </returns>
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

        /// <summary>
        /// Удалить несколько знаков из строки
        /// </summary>
        /// <param name="str"> Исходная строка </param>
        /// <param name="signs"> Удаляемые символы </param>
        /// <returns> Строка без указанных символов </returns>
        public static string RemoveSigns(this string str, params char[] signs)
        {
            string tempStr = string.Copy(str);
            foreach (var sign in signs)
                tempStr = tempStr.RemoveSign(sign);
            return tempStr;
        }
    }
}
