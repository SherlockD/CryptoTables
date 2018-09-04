using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoTables
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var passFile = File.Open(Properties.Settings.Default.documentPath, FileMode.Open, FileAccess.Read);
            var reader = new StreamReader(passFile);
            if (textBox1.Text.Encrypt().Equals(reader.ReadLine()))
            {
                var form3 = new Form3();
                form3.Show();
                passFile.Close();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный пароль! Попробуйте снова");
                passFile.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
