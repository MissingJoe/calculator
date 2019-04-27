using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static double[] shuzi = new double[100];
        public static char[] caozuofu = new char[100];
        public static double num = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private double calculate(char a, int i)
        {
            if (shuzi[i] != 0 && shuzi[i + 1] != 0)
            {
                switch (a)
                {
                    case '*':
                        num = shuzi[i] * shuzi[i + 1];
                        break;
                    case '/':                       
                        num = shuzi[i] / shuzi[i + 1];
                        break;
                    case '+':
                        num = shuzi[i] + shuzi[i + 1];
                        break;
                    case '-':
                        num = shuzi[i] - shuzi[i + 1];
                        break;
                    case '.':
                        num = shuzi[i] + shuzi[i + 1] / 10.0;
                        break;
                    default:
                        num = -1; break;
                }
                if (num == -1)
                {
                    MessageBox.Show("输入其他符号错误");
                    return -1;
                }
                else
                    return num;
            }
            else
            {
                MessageBox.Show("表达式输入错误");
                return -1;
            }
        }
        private void numin(int a)
        {
            int i;
            for (i = 0; i < 100; i++)
                if (shuzi[i] == 0)
                {
                    shuzi[i] = a;
                    break;
                }
        }

        private void charin(char a)
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                if (caozuofu[i] == '0')
                {
                    caozuofu[i] = a;
                    break;
                }
            }
        }   

        private int youxianji(char s)
        {
            if (s == '*')
                return 3;
            if (s == '/')
                return 3;
            if (s == '+')
                return 2;
            if (s == '-')
                return 2;
            if (s == ')')
                return 10;
            if (s == '.')
                return 4;
            if (s == '(')
                return 10;
            return -1;
        }

        private int zhuanhuan(char s)
        {
            int i;
            for (i = 48; i < 58; i++)
            {
                if (s == i)
                    return (s - 48);
            }
            return -1;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";

        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ")";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            string s1;
            int n1;
            s1 = textBox1.Text;
            n1 = s1.Length;
            if (n1 == 0)
                MessageBox.Show("无数字，无法删除");
            else
            {
                s1 = s1.Remove(n1 - 1, 1);
            }
            textBox1.Text = s1;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            textBox1.Text = textBox1.Text + "/";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";

        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "(";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char[] a = new char[100];
            int i, j=0, n, k, num1 = 0, start = 0, end, leftnum = 0, rightnum = 0, leftloc = 0, rightloc = 0;
            int level1 = 0;
            double chengfang;
            string s;
            s = textBox1.Text;
            n = s.Length;
            for (i = 0; i < n; i++)
                s.CopyTo(i, a, i, 1);
            for (i = 0; i < 100; i++)
            {
                shuzi[i] = 0;
                caozuofu[i] = '0';
            }
            for (i = start; i < n; i++)
                if (a[i] < '0' || a[i] > '9')
                {
                    num1 = 0;
                    end = i;
                    if (a[i] == '(')
                    {
                        charin(a[i]);
                        start = i + 1;
                        continue;
                    }
                    if (a[i] == ')')
                    {
                        charin(a[i]);
                        for (k = end - 1; k >= start; k--)
                        {
                            chengfang = Math.Pow((double)10, (double)(end - k - 1));
                            num1 = num1 + zhuanhuan(a[k]) * (int)chengfang;
                        }
                        numin(num1);
                        start = i + 1;
                        continue;
                    }
                    if (end == start && a[i - 1] != ')' && a[i + 1] != '(')
                    {
                        MessageBox.Show("表达式输入错误");
                        return;
                    }
                    for (k = end - 1; k >= start; k--)
                    {
                        chengfang = Math.Pow((double)10, (double)(end - k - 1));
                        num1 = num1 + zhuanhuan(a[k]) * (int)chengfang;
                    }
                    numin(num1);
                    charin(a[i]);
                    start = end + 1;
                }           
            num1 = 0;
            for (i = n - 1; i >= 0; i--)
                if (a[i] < '0' || a[i] > '9')
                {
                    j = i;
                    break;
                }
            for (k = j + 1; k < n; k++)
            {
                chengfang = Math.Pow((double)10, (double)(n - k - 1));
                num1 = num1 + zhuanhuan(a[k]) * (int)chengfang;
            }
            numin(num1);
            
            for (i = 0; i < 100; i++)
            {
                if (caozuofu[i] == '(')
                    leftnum++;
                if (caozuofu[i] == ')')
                    rightnum++;
            }
            if (leftnum != rightnum)
            {
                MessageBox.Show("括号数量不匹配，请重新输入");
                return;
            }

            //判断小数点错误
            for(i=0;i<100;i++)
                if(caozuofu[i]=='.')
                {
                    if(caozuofu[i+1]=='.')
                    {
                        MessageBox.Show("小数点位置错误");
                        return;
                    }
                }
            //处理括号
            while (true)
            {                
                if (leftnum == 0)
                    break;
                for (i = 0; i < 100; i++)
                    if (caozuofu[i] == '(')
                        leftloc = i;
                for (i = 99; i >= 0; i--)
                    if (caozuofu[i] == ')')
                        rightloc = i;
                if (leftloc > rightloc)
                {
                    MessageBox.Show("括号顺序错误，请重新输入");
                    return;
                }
                j = 2;
                level1 = youxianji(caozuofu[leftloc + 1]);
                while ((leftloc + j) < rightloc && youxianji(caozuofu[leftloc + j]) > level1)
                {
                    level1 = youxianji(caozuofu[leftloc + j]);
                    j++;
                }
                num = calculate(caozuofu[leftloc + j - 1], leftloc + j - 1 - leftnum);
                if (num == -1)
                    return;
                shuzi[leftloc + j - 1 - leftnum] = num;
                for (i = leftloc + j - leftnum; i < 99; i++)
                    shuzi[i] = shuzi[i + 1];
                if(rightloc-leftloc==2)
                {
                    for (i = rightloc; i < 99; i++)
                        caozuofu[i] = caozuofu[i + 1];
                    for (i = leftloc; i < 100 + leftloc - rightloc; i++)
                        caozuofu[i] = caozuofu[i + rightloc - leftloc];                   
                }
                else
                {
                    for (i = leftloc + j - 1; i < 99; i++)
                        caozuofu[i] = caozuofu[i + 1];
                    continue;
                }
                leftnum--;
            }
            //处理无括号运算
            while (true)
            {
                if (caozuofu[0] == '0')
                    break;
                j = 1;
                level1 = youxianji(caozuofu[0]);
                while (youxianji(caozuofu[j]) > level1)
                {
                    level1 = youxianji(caozuofu[j]);
                    j++;
                }
                num = calculate(caozuofu[j - 1], j - 1);
                shuzi[j - 1] = num;
                for (i = j; i < 99; i++)
                {
                    shuzi[i] = shuzi[i + 1];
                    caozuofu[i - 1] = caozuofu[i];
                }
            }
            textBox1.Text = shuzi[0].ToString();
        }
    }
}