using System;
using System.IO;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            TestArray t = new TestArray("C:\\Users\\User\\Desktop\\lesson4-main\\lesson4\\lesson4\\data.txt");


            
        }


        //показывает результат
        public void result(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (isValid(arr[i]) || isValid(arr[i + 1]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        //создает массив из 20ти элементов
        public static int[] createArray()
        {
            int[] arr = new int[20];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                int val = random.Next(-10000, 10000);
                arr[i] = val;
            }

            return arr;
        }


        //выводит в консоле массив
        public static void print(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }


        //проверяет на деление на 3
        public static bool isValid(int i)
        {
            return i % 3 == 0;
        }
    }
}
