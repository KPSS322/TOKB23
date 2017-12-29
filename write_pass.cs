using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace test
{
    public partial class Form1
    {
       [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(
            IntPtr hFile,
            byte[] bytes,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            int overlapped);
        //[DllImport("kernel32.dll")]
        //public static extern void ZeroMemory(IntPtr ptr, int size);

        static unsafe void write_pass()
        {
           //////////////////////////////

            int i = 0;
           int j = 54;
           if (Data.mass[j] == (char)254)
           {
               if (Directory.Exists(Data.disc))
               {
                   while (Data.pass[i] != '\0')
                   {
                       Data.mass[j] = Data.pass[i];
                       i++;
                       j++;

                   }
                   Data.mass[j] = (char)254;
               }
               else
                   MessageBox.Show("ОТСУТСТВУЕТ НОСИТЕЛЬ ДИСКА!!!");
           }
           else
           {
               if (Directory.Exists(Data.disc))
               {
                   MessageBox.Show("ПАРОЛЬ УЖЕ ЗАПИСАН !!!");
               }
               else
                   MessageBox.Show("ОТСУТСТВУЕТ НОСИТЕЛЬ ДИСКА!!!");
           }
           i = 0;
           j = 0;
            //////////////////////
           IntPtr hDevice = Form1.CreateFile("\\\\.\\I:",
               Form1.GENERIC_READ | Form1.GENERIC_WRITE,
               Form1.FILE_SHARE_READ | Form1.FILE_SHARE_WRITE,
               0, Form1.OPEN_EXISTING,
               0,
               0);

            /*
            IntPtr txtBuffer = IntPtr.Zero;
            uint  count = 2;
            txtBuffer = Marshal.StringToHGlobalUni("Zqwertyasds234");
           Form1.WriteFile(hDevice, txtBuffer, 512,
               out count, 0); */

            /*
           IntPtr txtBuffer = IntPtr.Zero;
           string text = "komserver";
           MessageBox.Show(text);
           txtBuffer = Marshal.StringToHGlobalUni(text);
           uint nBytes, count;
           nBytes = 512;

           WriteFile(hDevice, txtBuffer, sizeof(char) * nBytes, out count, 0);*/


           uint count = 0;
           byte[] bytes = new byte[512];
           int temp = 0;
           while (Data.mass[temp] != '\0')
           {
               bytes[temp] = Convert.ToByte(Data.mass[temp]);
               if (bytes[temp] == 254)
               {
                   bytes[temp] = Convert.ToByte('\0');
               }
               temp++;
           }
           temp = 0;
           Form1.WriteFile(hDevice, bytes, 512, out count, 0);
           Form1.CloseHandle(hDevice);




        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public partial class Form3
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(
            IntPtr hFile,
            byte[] bytes,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            int overlapped);
        //[DllImport("kernel32.dll")]

        static unsafe void write_pass()
        {
            IntPtr hDevice = Form1.CreateFile("\\\\.\\I:",
                   Form1.GENERIC_READ | Form1.GENERIC_WRITE,
                   Form1.FILE_SHARE_READ | Form1.FILE_SHARE_WRITE,
                   0, Form1.OPEN_EXISTING,
                   0,
                   0);

            uint count = 0;
            byte[] bytes = new byte[512];
            int temp = 0;
            while (Data.mass[temp] != '\0')
            {
                bytes[temp] = Convert.ToByte(Data.mass[temp]);
                if (bytes[temp] == 254)
                {
                    bytes[temp] = Convert.ToByte('\0');
                }
                temp++;
            }
            temp = 0;
            Form3.WriteFile(hDevice, bytes, 512, out count, 0);
            Form3.CloseHandle(hDevice);
        }
    }
}