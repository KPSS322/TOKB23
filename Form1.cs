using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test
{
    public partial class Form1 : Form
    {
        public Form2 form2;
        public Form3 form3;
        public Form1()
        {
            InitializeComponent();
            Data.key = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private unsafe void button1_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(Data.disc))
            {
                sektor_raed();
                string temp_out = "";
                int temp = 0;
                while (Data.mass[temp] != '\0')
                {
                    if (Data.mass[temp] == (char)254)
                    {
                        temp_out = temp_out + ' ';
                    }
                    else
                    {
                        temp_out = temp_out + Data.mass[temp];
                    }
                    temp++;
                }
                Data.temp_out = temp_out;
                MessageBox.Show(Data.temp_out); 
            }
            else
                MessageBox.Show("ОТСУТСТВУЕТ НОСИТЕЛЬ ДИСКА!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp_pass;
            if (passBox.Text != "")
            {
                if (Data.key != 0)
                {
                    sektor_raed();
                    temp_pass = passBox.Text + '\0';
                    Data.pass = coding(temp_pass);
                    write_pass();
                    Console.Beep();
                    passBox.Text = "";
                }
                else
                    MessageBox.Show("НЕ ВВЕДЕН КЛЮЧ !!!");
            }
            else
                MessageBox.Show("Введите пароль");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Data.key != 0)
            {
                form3 = new Form3();
                form3.Show();
            }
            else
                MessageBox.Show("НЕ ВВЕДЕН КЛЮЧ !!!");

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

    }
}
