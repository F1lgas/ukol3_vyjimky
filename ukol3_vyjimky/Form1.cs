using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ukol3_vyjimky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            try
            {
                FileStream fs = new FileStream(@"..\..\Cisla.dat", FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);

                int N = Convert.ToInt32(textBox1.Text);
                int soucet = 0;

                br.BaseStream.Position = 0;
                while (br.BaseStream.Position < N)
                {
                    int cislo = Convert.ToInt32(br.ReadString());       //zase mi nefunguje ReadString(), ale tentokrát nevím jak to spravit
                    soucet += cislo;
                    textBox2.AppendText(cislo.ToString() + Environment.NewLine);
                }

                fs.Close();
                br.Close();

                MessageBox.Show("Aritmetrický průměr prvních " + N + " čísel je " + (double)(soucet / N));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor nebyl nalezen!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Na vstupu není číslo!");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Na vstupu nemůže být 0!");
            }
            catch (EndOfStreamException)
            {
                MessageBox.Show("Čtení po konci streamu!");
            }
        }
    }
}
