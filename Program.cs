using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class Data
    {
        public static int count { get; set; }
        public static string pass { get; set; }
        public static char[] mass;
        public static string temp_out { get; set; }
        public static int key { get; set; }
        public static string disc = "I:";
        public static int g_count = 0;
    }
}
