using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;

namespace test
{
    public partial class Form1
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe IntPtr CreateFile(
              string FileName,
              uint DesiredAccess,
              uint ShareMode,
              uint SecurityAttributes,
              uint CreationDisposition,
              uint FlagsAndAttributes,
              int hTemplateFile
              );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe bool ReadFile(
              IntPtr hFile,
              void* pBuffer,
              int NumberOfBytesToRead,
              int* pNumberOfBytesRead,
              int Overlapped
              );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe bool CloseHandle(
              IntPtr hObject
              );

        public const UInt32 GENERIC_READ = 0x80000000;
        public const UInt32 GENERIC_WRITE = 0x40000000;
        public const UInt32 FILE_SHARE_READ = 0x00000001;
        public const UInt32 FILE_SHARE_WRITE = 0x00000002;
        public const UInt32 OPEN_EXISTING = 3;
        public const UInt32 CREATE_ALWAYS = 1;

    
        [STAThread]
        static unsafe void sektor_raed()
        {
            Data.mass = new char[1024];

            IntPtr hDevice = Form1.CreateFile("\\\\.\\I:",
                Form1.GENERIC_READ,
                Form1.FILE_SHARE_READ | Form1.FILE_SHARE_WRITE,
                0, Form1.OPEN_EXISTING, 
                0, 
                0);
            
            byte[] bytes = new byte[512];
            int BytesRead = 0;
            int i = 0;

            fixed (byte* ptr = bytes)
            {
                Form1.ReadFile(hDevice, ptr, 512, &BytesRead, 0);
                /*foreach (char ch in bytes)
                {
                    MessageBox.Show(Convert.ToString( ch));
                }*/
                foreach (char ch in bytes)
                {
                    if (ch != '\0')
                    {
                        
                        //Data.mass = Data.mass + Convert.ToString(ch);
                        Data.mass[i] = ch;
                    }
                    else
                    {
                       Data.mass[i] = (char)254;
                    }
                    i++;
                }
                i = 0;

            }
            Form1.CloseHandle(hDevice);
            //Data.mass = Convert.ToString(mass[1]);
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
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe IntPtr CreateFile(
              string FileName,
              uint DesiredAccess,
              uint ShareMode,
              uint SecurityAttributes,
              uint CreationDisposition,
              uint FlagsAndAttributes,
              int hTemplateFile
              );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe bool ReadFile(
              IntPtr hFile,
              void* pBuffer,
              int NumberOfBytesToRead,
              int* pNumberOfBytesRead,
              int Overlapped
              );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe bool CloseHandle(
              IntPtr hObject
              );

        public const UInt32 GENERIC_READ = 0x80000000;
        public const UInt32 GENERIC_WRITE = 0x40000000;
        public const UInt32 FILE_SHARE_READ = 0x00000001;
        public const UInt32 FILE_SHARE_WRITE = 0x00000002;
        public const UInt32 OPEN_EXISTING = 3;
        public const UInt32 CREATE_ALWAYS = 1;


        [STAThread]
        static unsafe void sektor_raed()
        {
            Data.mass = new char[1024];

            IntPtr hDevice = Form1.CreateFile("\\\\.\\I:",
                Form1.GENERIC_READ,
                Form1.FILE_SHARE_READ | Form1.FILE_SHARE_WRITE,
                0, Form1.OPEN_EXISTING,
                0,
                0);

            byte[] bytes = new byte[512];
            int BytesRead = 0;
            int i = 0;

            fixed (byte* ptr = bytes)
            {
                Form1.ReadFile(hDevice, ptr, 512, &BytesRead, 0);
                foreach (char ch in bytes)
                {
                    if (ch != '\0')
                    {
                        Data.mass[i] = ch;
                    }
                    else
                    {
                        Data.mass[i] = (char)254;
                    }
                    i++;
                }
                i = 0;
            }
            Form3.CloseHandle(hDevice);
        }
    }

}