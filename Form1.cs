using System;
using System.IO;
using System.Windows.Forms;
using CryptoTables;

namespace CryptoTables
{
    public partial class Form1 : Form
    {
        public const string fileName = "/pass.txt";

        private byte _errorsCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

#region UNUSELESS_METHODS

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            if (File.Exists(Properties.Settings.Default.documentPath))
            {
                var passFile = File.Open(Properties.Settings.Default.documentPath, FileMode.Open, FileAccess.Write);
                if (passFile.Length == 0)
                {
                    Properties.Settings.Default.arraySize = random.Next((textBox1.Text.Length / 2) + 1, ((textBox1.Text.Length / 2) + 1) + 5);
                    Properties.Settings.Default.Save();
                    var writer = new StreamWriter(passFile);
                    writer.Write(textBox1.Text.Encrypt());
                    writer.Close();
                    passFile.Close();
                    MessageBox.Show("Готово! Зайдите используя новый пароль.");
                }
                else
                {
                    passFile?.Close();
                    passFile = File.Open(Properties.Settings.Default.documentPath, FileMode.Open, FileAccess.Read);
                    var reader = new StreamReader(passFile);
                    if (textBox1.Text.Encrypt().Equals(reader.ReadLine()))
                    {
                        _errorsCount = 0;
                        var form2 = new Form2();
                        form2.Show();
                        passFile.Close();
                        Hide();
                    }
                    else
                    {                       
                        _errorsCount++;
                        if (_errorsCount >= 3)
                        {
                            MessageBox.Show("Вы ввели неверный пароль более 2 раз, закрытие программы");
                            Application.Exit();
                        }
                        MessageBox.Show($"Неверный пароль! Осталось {3 -_errorsCount} попытки(-а)! Попробуйте снова");
                        passFile.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Данного файла не существует, выберите другой");       
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();
            folderBrowserDialog1.Description = "Выберите папку с файлом пароля";
            if(dialogresult == DialogResult.OK)
            {
                Properties.Settings.Default.documentPath = folderBrowserDialog1.SelectedPath+fileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}
