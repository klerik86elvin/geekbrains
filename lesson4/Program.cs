using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using lesson6_2;
using lesson6_3;
namespace lesson4
{
    
    class Program
    {
        List<Student> students = new List<Student>();

        public delegate double Fun(double x, double a);

        public static void Table(Fun F, double x, double b, double a)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }


        /*Изменить программу вывода таблицы функции так, 
         * чтобы можно было передавать функции типа double (double, double). 
         * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        */
        public static double MyFunc(double x, double a)
        {
            return a * x * x;
        }

        public static double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            //DoubleBinary.PrintMenu();
           
        }

    }
}
