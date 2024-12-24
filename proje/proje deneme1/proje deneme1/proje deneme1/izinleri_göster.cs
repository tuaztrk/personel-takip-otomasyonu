using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using static proje_deneme1.Form1;

namespace proje_deneme1
{
    public partial class izinleri_göster : Form
    {
        public izinleri_göster()
        {
            InitializeComponent();
        }


        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");


        private void izinleri_göster_Load(object sender, EventArgs e)
        {
            ListeleIzinler();
        }

      
        private void ListeleIzinler()
        {
            try
            {
                if (baglantim.State != ConnectionState.Open) 
                    baglantim.Open();

                string query = "SELECT ID, PersonelID, IzinTarihi, IzinSebebi, Durum FROM Izinler";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, baglantim);
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                dgvIzinler.DataSource = tablo; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglantim.State == ConnectionState.Open) 
                    baglantim.Close();
            }
        }

       
        private void btnKabul_Click(object sender, EventArgs e)
        {
            GuncelleDurum("Kabul Edildi");
        }


        private void btnRed_Click(object sender, EventArgs e)
        {
            GuncelleDurum("Reddedildi");
        }

     
        private void GuncelleDurum(string yeniDurum)
        {
            if (dgvIzinler.SelectedRows.Count > 0)
            {
                try
                {
                    int izinID = Convert.ToInt32(dgvIzinler.SelectedRows[0].Cells["ID"].Value);

                    if (baglantim.State != ConnectionState.Open) 
                        baglantim.Open();

                    string query = "UPDATE Izinler SET Durum = @Durum WHERE ID = @ID";
                    OleDbCommand komut = new OleDbCommand(query, baglantim);
                    komut.Parameters.AddWithValue("@Durum", yeniDurum);
                    komut.Parameters.AddWithValue("@ID", izinID);
                    komut.ExecuteNonQuery(); 

                    MessageBox.Show("İzin durumu başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeleIzinler(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Durum güncellenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (baglantim.State == ConnectionState.Open) 
                        baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir izin talebi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = GlobalData.kullaniciAdi; 
            string departmani = ""; 

            try
            {
              
                if (baglantim.State != ConnectionState.Open)
                    baglantim.Open();

           
                OleDbCommand selectCommand = new OleDbCommand("SELECT departmani FROM kullanicilar WHERE kullaniciadi = ?", baglantim);
                selectCommand.Parameters.AddWithValue("?", kullaniciAdi);  

           
                OleDbDataReader kayitOkuma = selectCommand.ExecuteReader();

           
                if (kayitOkuma.Read())
                {
                    departmani = kayitOkuma["departmani"].ToString(); 

               
                    if (departmani == "Yönetici")
                    {
                        owner ownerForm = new owner();
                        ownerForm.Show(); 
                        this.Close(); 
                    }               
                    else if (departmani == "ik")
                    {
                        ıkakart ıkkartForm = new ıkakart();  
                           ıkkartForm.Show(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Yönetici, veya İK departmanına ait kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
       
                if (baglantim.State == ConnectionState.Open)
                    baglantim.Close();
            }




        }
    }
}
