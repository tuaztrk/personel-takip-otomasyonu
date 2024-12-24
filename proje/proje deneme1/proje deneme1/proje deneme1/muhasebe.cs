using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class muhasebe : Form
    {
      

        public muhasebe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3 form3Form = new form3();
            form3Form.Show();
            this.Hide();
        }

        private void muhasebe_Load(object sender, EventArgs e)
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
            maasdüzen maasdüzen = new maasdüzen();
            maasdüzen.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
