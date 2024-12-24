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
    public partial class perskart : Form
    {
        public perskart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            izinpersonel izinpersonel = new izinpersonel();
            this.Hide();
            izinpersonel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string tcNo = Form1.tcno; 

        
            clsmblglrm clsmblglrm = new clsmblglrm(tcNo); 
            this.Hide();
            clsmblglrm.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void perskart_Load(object sender, EventArgs e)
        {
            label5.Text = Form1.tcno;
            label4.Text = Form1.adi;
            label8.Text = Form1.soyadi;
            label10.Text = Form1.departmani;


            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg.jpg");
            }
            catch
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg.jpg");
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
