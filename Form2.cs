using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int count = 0;
                int i = 0;
                int value_int = 0;
                bool control = true;
                string temp;
                count = textBox1.Text.Length;
                if (count > 3)
                {
                    temp = textBox1.Text + '\0';
                    while (temp[i] != '\0')
                    {
                        if (((int)temp[i] > 57) || ((int)temp[i] < 48))
                        {
                            control = false;
                        }
                        i++;
                    }
                    if (control == true)
                    {
                        int j = 0;
                        while (temp[j] != '\0')
                        {
                            value_int = value_int + ((int)temp[j] - 48);
                            j++;
                        }
                        Data.key = value_int;
                    }
                    else
                        MessageBox.Show("ВВЕДИТЕ ЦИФРОВЫЕ ЗНАЧЕНИЯ !!!");
                    Console.Beep();
                    Close();
                }
                else
                    MessageBox.Show("                  ВВЕДИТЕ КЛЮЧ !!! \n (минимальная длинна 4 символа)");
            }
            else
            {
                MessageBox.Show("                  ВВЕДИТЕ КЛЮЧ !!! \n (минимальная длинна 4 символа)");
            }
        }
    }
}
