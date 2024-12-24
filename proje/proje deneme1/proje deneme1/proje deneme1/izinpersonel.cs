using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class izinpersonel : Form
    {
        public izinpersonel()
        {
            InitializeComponent();
        }

      
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");
        private void izinpersonel_Load(object sender, EventArgs e)
        {
           
        }
        private void btnGonder_Click_1(object sender, EventArgs e)
        {
       
            if (string.IsNullOrWhiteSpace(txtSebep.Text))
            {
                MessageBox.Show("Lütfen izin sebebini giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (dtpTarih.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Geçmiş bir tarih seçemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
           
                baglantim.Open();

           
                string query = "INSERT INTO Izinler (PersonelID, IzinTarihi, IzinSebebi, Durum) VALUES (@PersonelID, @IzinTarihi, @IzinSebebi, 'Bekliyor')";
                OleDbCommand komut = new OleDbCommand(query, baglantim);

             
                komut.Parameters.AddWithValue("@PersonelID", 1); 
                komut.Parameters.AddWithValue("@IzinTarihi", dtpTarih.Value.Date); 
                komut.Parameters.AddWithValue("@IzinSebebi", txtSebep.Text); 

        
                komut.ExecuteNonQuery();

            
                MessageBox.Show("İzin talebiniz başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
                txtSebep.Clear();
                dtpTarih.Value = DateTime.Now;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
