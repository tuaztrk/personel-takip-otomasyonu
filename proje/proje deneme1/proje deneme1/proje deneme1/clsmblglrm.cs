using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace proje_deneme1
{
    public partial class clsmblglrm : Form
    {

        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");

 
        private string kullaniciTcNo;

     
        public clsmblglrm(string tcNo)
        {
            InitializeComponent();
            this.kullaniciTcNo = tcNo; 
        }

     
        private void clsmblglrm_Load(object sender, EventArgs e)
        {
           
            LoadIzinBilgileri(kullaniciTcNo);
            LoadPersonellerBilgileri(kullaniciTcNo);
        }

       
        private void LoadIzinBilgileri(string tcNo)
        {
            try
            {
             
                baglantim.Open();

                string query = "SELECT ID FROM Personel WHERE tcno = ?";
                OleDbCommand cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("?", tcNo);

          
                int personelID = Convert.ToInt32(cmd.ExecuteScalar());

                query = "SELECT ID, PersonelID, IzinTarihi, IzinSebebi, Durum FROM Izinler WHERE PersonelID = ?";
                cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("?", personelID);

           
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

         
                dataGridViewIzinler.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
         
                if (baglantim.State == ConnectionState.Open)
                    baglantim.Close();
            }
        }
        private void LoadPersonellerBilgileri(string tcNo)
        {
            try
            {
            
                baglantim.Open();

           
                string query = "SELECT * FROM Personeller WHERE tcno = ?";
                OleDbCommand cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("?", tcNo);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                if (baglantim.State == ConnectionState.Open)
                    baglantim.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            perskart perskartForm = new perskart();
            perskartForm.Show(); 

           
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
