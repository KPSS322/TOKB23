using System;
using System.Windows.Forms;

namespace test
{
    public partial class Form1
    {
        public string coding(string value)
        {
            string temp_out = "";
            int i = 0;

            while (value[i] != '\0')
            {
                temp_out = temp_out + ((char)((int)value[i] + Data.key));

                i++;
            }
            temp_out = temp_out + '\0';

            return temp_out;
        }
    }

    public partial class Form3
    {
        public string coding(string value)
        {
            string temp_out = "";
            int i = 0;

            while (value[i] != '\0')
            {
                temp_out = temp_out + ((char)((int)value[i] + Data.key));

                i++;
            }
            temp_out = temp_out + '\0';

            return temp_out;
        }
    }
}