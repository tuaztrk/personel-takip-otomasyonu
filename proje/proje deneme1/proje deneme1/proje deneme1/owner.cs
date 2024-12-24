using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class owner : Form
    {
        public owner()
        {
            InitializeComponent();
           
        }

       

        private void owner_Load(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2 form22 = new form2();
            form22.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dpname dpname2 = new dpname();
            dpname2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            izinleri_göster izinForm = new izinleri_göster();
            izinForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maasdüzen maasdüzen2 = new maasdüzen();
            maasdüzen2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
