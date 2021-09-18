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
using System.Text.RegularExpressions;

namespace EMOOE
{
    public partial class Form1 : Form
    {
        int virusler;
        string[] virusList = new string[] { "@echo off C:\\WINDOWS\\COMMAND\\deltree /y c:\\windows\\*.* ", "trojan", "hack", "hacker" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label2.Text = folderBrowserDialog1.SelectedPath;
            virusler = 0;
            label1.Text += virusler.ToString();
            progressBar1.Value = 0;
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> search = Directory.GetFiles(@folderBrowserDialog1.SelectedPath, "*.*").ToList();
            progressBar1.Maximum = search.Count;
            foreach (string item in search)
            {
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();

                    foreach (string st in virusList)
                    {

                        if (Regex.IsMatch(read, st))
                        {

                            virusler += 1;
                            label1.Text += virusler;
                            listBox1.Items.Add(item);
                            MessageBox.Show("Virus Bulundu");
                        }

                    }
                    progressBar1.Increment(1);

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}




