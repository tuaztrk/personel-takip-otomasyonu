using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class ika : Form
    {
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");

        public ika()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }

                baglantim.Open();
                string query = "SELECT tc_no, ad, soyad, cinsiyet, departman, izin_baslangic, izin_bitis, izin_turu FROM izininfo";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, baglantim);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }

                baglantim.Open();

        
                string tcNo = maskedTextBox5.Text;
                string ad = maskedTextBox6.Text;
                string soyad = maskedTextBox7.Text;
                string cinsiyet = maskedTextBox8.Text;
                string departman = maskedTextBox9.Text;
                string izinTuru = maskedTextBox12.Text;

             
                DateTime dtIzinBaslangic = dateTimePicker1.Value;
                DateTime dtIzinBitis = dateTimePicker2.Value;

       
                string query = "INSERT INTO izininfo (tc_no, ad, soyad, cinsiyet, departman, izin_baslangic, izin_bitis, izin_turu) " +
                               "VALUES (@tcNo, @ad, @soyad, @cinsiyet, @departman, @izinBaslangic, @izinBitis, @izinTuru)";

                OleDbCommand cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("@tcNo", tcNo);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                cmd.Parameters.AddWithValue("@departman", departman);
                cmd.Parameters.AddWithValue("@izinBaslangic", dtIzinBaslangic);
                cmd.Parameters.AddWithValue("@izinBitis", dtIzinBitis);
                cmd.Parameters.AddWithValue("@izinTuru", izinTuru);

        
                cmd.ExecuteNonQuery();

                MessageBox.Show("Veri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

    
                maskedTextBox5.Clear();
                maskedTextBox6.Clear();
                maskedTextBox7.Clear();
                maskedTextBox8.Clear();
                maskedTextBox9.Clear();
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
                maskedTextBox12.Clear();

         
                LoadData();
            }
            catch (Exception ex)
            {
      
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
          
                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }
            }
        }

      

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
          
                string tcNo = maskedTextBox5.Text;

                if (string.IsNullOrEmpty(tcNo))
                {
                    MessageBox.Show("Lütfen geçerli bir TC No giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                baglantim.Open();

         
                string query = "SELECT tc_no, ad, soyad, cinsiyet, departman, izin_baslangic, izin_bitis, izin_turu " +
                "FROM izininfo WHERE tc_no = @tcNo";


                OleDbCommand cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("@tcNo", tcNo);

             
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    maskedTextBox6.Text = reader["ad"].ToString();
                    maskedTextBox7.Text = reader["soyad"].ToString();
                    maskedTextBox8.Text = reader["cinsiyet"].ToString();
                    maskedTextBox9.Text = reader["departman"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(reader["izin_baslangic"]);
                    dateTimePicker2.Value = Convert.ToDateTime(reader["izin_bitis"]);
                    maskedTextBox12.Text = reader["izin_turu"].ToString();
                }
                else
                {
                    MessageBox.Show("Bu TC No'ya ait veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        
                baglantim.Close();
            }
            catch (Exception ex)
            {
     
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ika_Load(object sender, EventArgs e)
        {

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg.jpg");
            }
            catch
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg.jpg");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string tcNo = maskedTextBox5.Text;

                if (string.IsNullOrEmpty(tcNo))
                {
                    MessageBox.Show("Lütfen geçerli bir TC No giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }
                baglantim.Open();

         
                string query = "DELETE FROM izininfo WHERE tc_no = @tcNo";

                OleDbCommand cmd = new OleDbCommand(query, baglantim);
                cmd.Parameters.AddWithValue("@tcNo", tcNo);

      
                cmd.ExecuteNonQuery();

           
                baglantim.Close();

                MessageBox.Show("Veri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
        
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            maskedTextBox5.Clear();
            maskedTextBox6.Clear();
            maskedTextBox7.Clear();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            maskedTextBox12.Clear();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ıkakart ıkkartForm = new ıkakart();  
            ıkkartForm.Show(); 
            this.Close(); 
        }
    }
}
