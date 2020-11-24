using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using lesson4;

//Напишите программу сохранение результатов вычисления заданной функции в файл для дальнейшей обработки
//файла. Разбейте программу на две функции, одна записывает данные функции в файл на промежутке от
//a до b с шагом h, а другая считывает данные и находит минимум функции
namespace lesson6_2
{
    //a.Модифицировать программу нахождения минимума функции так,
    //чтобы можно было передавать функцию в виде делегата. 
    public delegate double D(double x);
    class DoubleBinary
    {
        /*б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
         * Пусть она возвращает минимум через параметр (с использованием модификатора out). 
        */
        private static double min;

        public static List<D> ds = new List<D>()
        {
            new D(Sin),
            new D(Square),
            new D(Cube),
        };
        public static double F(double x)
        {
            return x * x-50*x+10;
        }

        public static void SaveFunc(D Del,string fileName, double a,double b,double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;
            double min = 0;
            while (x<=b)
            {
                if (min < x)
                bw.Write(Del(x));
                x += h;//x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName, out double a)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            a = double.MaxValue;
            double d;
            for(int i=0;i<fs.Length/sizeof(double);i++)
            {
                
                d = bw.ReadDouble();
                if (d < a) a = d;
            }
            bw.Close();
            fs.Close();
            
            return a;

        }
     
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }

        public static double Square(double x)
        {
            return x * x;
        }

        public static double Cube(double x)
        {
            return x * x * x;
        }

        /*а) Сделать меню с различными функциями и представить пользователю выбор, 
          * для какой функции и на каком отрезке находить минимум. 
          * Использовать массив (или список) делегатов, в котором хранятся различные функции.
        */
        public static void PrintMenu()
        {            
            string[] menu = new string[] { "sin(x)", "x^2", "x^3" };
            Regex menuRegex = new Regex(@"^[1-" + menu.Length + "]$");
            string pointA;
            string pointB;
            Console.WriteLine("Выберите функцию");

            //печает массив menu
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }

            //ввод со стороны пользователя
            string selectMenu = Console.ReadLine();

            // проверка на правильно выбор из меню
            if (!menuRegex.IsMatch(selectMenu))
            {
                Console.WriteLine("Неверный выбор\n");
                PrintMenu();
            }

            //проверка выбора точки А
            while (true)
            {
                Regex regexPointA = new Regex(@"\d+");
                Console.WriteLine("Выберите начальную точку");
                pointA = Console.ReadLine();

                if (regexPointA.IsMatch(pointA)) break;
                else Console.WriteLine("Неверный ввод");
            }

            //проверка выбора точки Б
            while (true)
            {
                Regex regexPointB = new Regex(@"\d+");
                Console.WriteLine("Выберите конечную точку");
                pointB = Console.ReadLine();

                if (regexPointB.IsMatch(pointB)) break;
                else Console.WriteLine("Неверный ввод");
            }

            SaveFunc(new D(ds[int.Parse(selectMenu)]), "data.bin", double.Parse(pointA), double.Parse(pointB), 0.5);
            Console.WriteLine(Load("data.bin",out min));

        }
    }
}
