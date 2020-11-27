using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsForms1
{
    class Program: Form
    {

        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            Application.Run(form);
        }

        



    }
}
