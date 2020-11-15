using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace lesson4
{
    public static class StaticClass
    {        
        public static void Print(int[] arr)
        {
            Program p = new Program();
            p.result(arr);
        }

        public static int[] AddToArr(string filename)
        {
            int[] newArr = new int[0];
            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);
                string[] ss = File.ReadAllLines(filename);
                newArr = new int[ss.Length];
                for(int i = 0; i < ss.Length; i++)
                {
                    newArr[i] = int.Parse(ss[i]);
                }
            }
                return newArr;

        }

    }
}
