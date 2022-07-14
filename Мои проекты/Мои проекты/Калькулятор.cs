using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мои_проекты
{
    public partial class Калькулятор : Form
    {
        public Калькулятор()
        {
            InitializeComponent();
        }

        private bool isNumber = false;


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            isNumber =
                e.KeyCode >= Keys.D0 && e.KeyCode >= Keys.D9
                || e.KeyCode >= Keys.NumPad0 && e.KeyCode >= Keys.NumPad9
                || e.KeyCode >= Keys.Back; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender;

            switch(e.KeyChar)
            {
                case '-':
                    if (box.Text.Length == 0)
                        isNumber = true;
                    break;
                case '.':
                    if (box.Text.Length == 0)
                        break;
                    if (box.Text[0] == '-' && box.Text.Length == 1)
                        break;
                    if (box.Text.IndexOf('.') == -1)
                        isNumber = true;
                    break;
            }
            if (!isNumber)
                e.Handled = true;
        }

        private double numFirst, numSecond, numRes;

        private void btn_click(object sender, EventArgs e)
        {
            string strFirst = string.Copy(textBox1.Text);
            string strSecond = string.Copy(textBox2.Text);

            int pos = strFirst.IndexOf('.');
            if (pos!=-1)
            {
                strFirst = strFirst.Substring(0, pos)
                    + ',' + strFirst.Substring(pos + 1);
            }
            pos = strSecond.IndexOf('.');
            if (pos != -1)
            {
                strSecond = strSecond.Substring(0, pos)
                    + ',' + strSecond.Substring(pos + 1);
            }

            if (textBox1.Text.Length > 0)
                numFirst = Convert.ToDouble(strFirst);
            else
                numFirst = 0.0D;
            if (textBox2.Text.Length > 0)
                numSecond = Convert.ToDouble(strSecond);
            else
                numSecond = 0.0D;

            string btnText = "";
            bool divideFlag = false;
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "Increment":
                    btnText = "\" + \"";
                    numRes = numFirst + numSecond;
                    label1.Text = numRes.ToString();
                    break;
                case "Decrement":
                    btnText = "\" - \"";
                    numRes = numFirst - numSecond;
                    label4.Text = numRes.ToString();
                    break;
                case "Incremase":
                    btnText = "\" * \"";
                    numRes = numFirst * numSecond;
                    label4.Text = numRes.ToString();
                    break;
                case "Divide":
                    btnText = "\" : \"";
                    numRes = numFirst / numSecond;
                    label4.Text = numRes.ToString();
                    break;
            }

            System.Diagnostics.Debug.WriteLine("Нажата кнопка" + btnText);
        }
    }
}
