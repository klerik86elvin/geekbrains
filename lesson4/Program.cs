using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Message.text = new StringBuilder("Вывести все слова сообщения, которые начинаются и заканчиваются на одну и ту же букву.");
            //Message.ContainsWordsOfLength(4);

            string s = "Приве Фарид, как дела Фарид";
            string[] arr = new string[] { "Фарид", "как" };

            Console.WriteLine(Message.IsRevers("qaz", "zaqa"));
        }


        /*Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        а) без использования регулярных выражений;
        */
        public static bool ValidLogin(string login)
        {
            if (Char.IsNumber(login[0])) return false;

            else if (login.Length < 2 || login.Length > 10) return false;

            for(int i = 0; i < login.Length; i++)
            {
                if (!Char.IsNumber(login[i]) && !Char.IsLetter(login[i])) return false;
            }

            return true;
        }


        /*б) **с использованием регулярных выражений.*/
        public static bool ValidLoginByRegular(string str)
        {
            Regex regex = new Regex(@"^[^0-9].{2,9}$");
            return regex.IsMatch(str);
        }

    }
}
