using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lesson4
{
    static class Message
    {
        public static StringBuilder text;

        //а) Вывести только те слова сообщения,  которые содержат не более n букв.
        public static void ContainsWordsOfLength(int n)
        {
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsPunctuation(text[i])) text = text.Remove(i, 1);
                }

                string str = text.ToString();
                string[] arr = str.Split(' ');
                Regex regex = new Regex(@"^.{1," + n + "}$");

                for (int i = 0; i < arr.Length; i++)
                {
                    if (regex.IsMatch(arr[i]))
                    {
                        Console.WriteLine(arr[i]);
                    }
                }

            }

            else
                 Console.WriteLine("Текст пустой");
        }

        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public static void DeleteWordsThatEndIn(char c)
        {
            if (text != null)
            {
                Regex regex = new Regex($@"\b\S+{c}\b");
                if (regex.IsMatch(text.ToString()))
                {
                    string result = "";
                    string[] arr = text.ToString().Split(' ');

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!regex.IsMatch(arr[i]))
                        {
                            result = result + arr[i] + " ";
                        }
                    }
                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine($"Не нашлось слово в тексте оканчивающее на {c}");
            }
            else
                Console.WriteLine("Пустой текст");
        }


        //в) Найти самое длинное слово сообщения.
        public static void LongWordInText()
        {
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsPunctuation(text[i])) text = text.Remove(i, 1);                                                   
                }

                string[] arr = text.ToString().Split(' ');
                int max = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (max < arr[i].Length) max = arr[i].Length;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length == max) Console.WriteLine(arr[i]);
                }

            }
        }

        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static void LongWordString()
        {
            if(text != null)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsPunctuation(text[i])) text = text.Remove(i, 1);
                }

                string[] arr = text.ToString().Split(' ');
                int max = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (max < arr[i].Length) max = arr[i].Length;
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length == max) result.Append(arr[i] + ' ');
                }

                Console.WriteLine(result);
            }
        }

        /*д) ***Создать метод, который производит частотный анализ текста.
         * В качестве параметра в него передается массив слов и текст, 
         * в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
         * Здесь требуется использовать класс Dictionary.
        */
        public static void FrequencyAnalysisOfText(string[] words, string text)
        {
            Dictionary<int, string> wordsDic = new Dictionary<int, string>();
            for (int i = 0; i < words.Length; i++)
            {
                Regex regex = new Regex($@"\b{words[i]}\b");
                if (regex.IsMatch(text))
                {
                    MatchCollection matches = regex.Matches(text);
                    wordsDic.Add(matches.Count, words[i]);
                }
            }

            foreach (KeyValuePair<int, string> value in wordsDic)
            {
                Console.WriteLine($"{value.Value} повторялось - {value.Key} Раз");
            }
        }


        /**
         * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        */
        public static bool IsRevers(string str, string reversStr)
        {
            string s = "";

            for (int i = 0; i < reversStr.Length; i++)
            {
                s += reversStr[reversStr.Length - 1 - i];
            }
           
            return str.Equals(s);
        }

    }
}
