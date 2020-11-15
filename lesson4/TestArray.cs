using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace lesson4
{
    class TestArray
    {
        public int[] arr;
        public int sum;
        public int length;
        public int maxCount;
        public TestArray(int lenght, int step)
        {
            this.arr = new int[lenght];
            this.sum = 0;
            this.length = lenght;
            for(int i = 0; i < lenght; i++)
            {
                this.arr[i] = i * step;
                this.sum += this.arr[i];
            }

            this.CountMax();
        }

        public TestArray(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            int n = int.Parse(sr.ReadLine());
            arr = new int[n];
        }

        public void Inverse()
        {
            for (int i = 0; i < this.length; i++)
            {
                this.arr[i] = -1 * this.arr[i];
            }

            this.CountMax();
        }
        public void Multi(int multiplier)
        {
            for (int i = 0; i < this.length; i++)
            {
                this.arr[i] = multiplier * this.arr[i];
            }

            this.CountMax();
        }

        public void CountMax()
        {
            int max = arr[0];
            for (int i = 1; i < this.length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    this.maxCount = 1;
                }

                if (max == arr[i])
                {
                    this.maxCount++;
                }
            }
        }
    }
}
