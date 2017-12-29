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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string last_pass = "";
            string new_pass = "";
            int i = 0;
            if (Directory.Exists(Data.disc))
            {
                sektor_raed();
                int j = 54;
                if (Data.mass[j] != (char)254)
                {
                    while (Data.mass[j] != (char)254)
                    {
                        last_pass = last_pass + Data.mass[j];
                        j++;
                    }
                    last_pass = last_pass + '\0';
                    if (last_pass == coding(lastpass.Text + '\0'))
                    {
                        new_pass = coding(newpass.Text + '\0');
                        j = 54;
                        while (new_pass[i] != '\0')
                        {
                            Data.mass[j] = new_pass[i];
                            i++;
                            j++;
                        }
                        Data.mass[j] = (char)254;

                        write_pass();
                        Console.Beep();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("  ПАРОЛИ НЕ СОВПАДАЮТ !!!\n   ПОВТОРИТЕ ВВОД");
                        Data.g_count++;
                        if (Data.g_count > 2)
                        {
                            Data.g_count = 0;
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("НЕТ ПАРОЛЯ НА ДИСКЕ !!!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("ОТСУТСТВУЕТ НОСИТЕЛЬ ДИСКА!!!");
                Close();
            }
        }
        
        private void loginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
