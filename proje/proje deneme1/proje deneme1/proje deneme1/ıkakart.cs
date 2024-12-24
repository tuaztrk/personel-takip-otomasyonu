using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class ıkakart : Form
    {
        public ıkakart()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            ika ıkaForm = new ika();
            ıkaForm.Show();
            this.Hide();
        }

        private void ıkakart_Load(object sender, EventArgs e)
        {
            label5.Text = Form1.tcno;
            label4.Text = Form1.adi;
            label6.Text = Form1.soyadi;
            label7.Text = Form1.departmani;

            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg.jpg");
            }
            catch
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            izinleri_göster izinForm = new izinleri_göster();
            izinForm.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
