using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoTables
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var passFile = File.Open(Properties.Settings.Default.documentPath, FileMode.Open, FileAccess.Write);

            Properties.Settings.Default.arraySize = random.Next((textBox1.Text.Length / 2) + 1, ((textBox1.Text.Length / 2) + 1) + 5);
            Properties.Settings.Default.Save();
            var writer = new StreamWriter(passFile);
            writer.Write(textBox1.Text.Encrypt());
            writer.Close();
            passFile.Close();
            MessageBox.Show("Готово! Зайдите используя новый пароль.");
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
