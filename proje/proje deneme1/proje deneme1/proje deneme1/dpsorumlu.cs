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
    public partial class dpsorumlu : Form
    {
        public dpsorumlu()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");


        private void button1_Click(object sender, EventArgs e)
        {
            dpname dpnameForm = new dpname();  
            dpnameForm.Show();  
            this.Hide();  
        }

        private void dpsorumlu_Load_1(object sender, EventArgs e)
        {
            label5.Text = Form1.tcno;      
            label4.Text = Form1.adi;       
            label6.Text = Form1.soyadi;    
            label7.Text = Form1.departmani; 
            label10.Text = Form1.yetki;    


            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg.jpg");
            }
            catch
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg.jpg");
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
