using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    public partial class Form1 : Form
    {
        int _comandCount;
        int _receivedNum = 15;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Удвоитель";
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            btnStart.Text = "старт";
            lblNumber.Text = "0";
            lblComandCount.Text = "";
            btnComandCount.Text = "Количество команд";
            btnComandCount.Width = btnComandCount.Text.Length * 10;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            _comandCount++;

            if(_comandCount > MinSteps())
            {
                MessageBox.Show($"минимальное колчество шагов {MinSteps().ToString()}");
            }
            
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            _comandCount++;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
        }


        /*а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
        */
        private void btnComandCount_Click(object sender, EventArgs e)
        {
            lblComandCount.Text = _comandCount.ToString();
        }



        /*б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
         * Игрок должен получить это число за минимальное количество ходов.
        */
        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Получаемое число - {_receivedNum}");
        }

        private int MinSteps()
        {
            int step = 0;
            int i = _receivedNum;
            while(i > 0)
            {
                if (i % 2 == 0) i /= 2;
                else i--;

                step++;
            }

            return step;
        }

    }
}
