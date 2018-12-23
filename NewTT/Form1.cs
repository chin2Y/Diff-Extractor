using DiffMatchPatch;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var dmp = new diff_match_patch();
            string text1 = richTextBox1.Text;
            string text2 = richTextBox2.Text;
            var diff = dmp.diff_main(text1, text2);
            dmp.patch_make(text1, text2);
            
            richTextBox2.Text = "";
            foreach (var d in diff)
            {
                int length = richTextBox2.Text.Length;
                if (d.operation == Operation.INSERT)
                {
                    Console.WriteLine("+ : " + d.text);
                    richTextBox2.Text += d.text;
                    richTextBox2.Select(length, d.text.Length);
                    richTextBox2.SelectionBackColor = Color.Blue;                    
                }
                else
                {
                    if (d.operation == Operation.DELETE)
                    {
                        Console.WriteLine("- : " + d.text);
                        richTextBox2.Text += d.text;
                        richTextBox2.Select(length, d.text.Length);
                        richTextBox2.SelectionBackColor = Color.Red;
                    }
                    else
                    {
                        Console.WriteLine("= : " + d.text);
                        richTextBox2.Text += d.text;
                    }
                }
            }
        }
    }    
}
