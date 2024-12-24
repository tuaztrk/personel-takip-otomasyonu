using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class form3 : Form
    {
        public form3()
        {
            InitializeComponent();
        }


        private OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");

      
        private void PersonelleriGoster()
        {
            try
            {
                baglantim.Open();
                string query = "SELECT * FROM personeller"; 
                OleDbDataAdapter personelleriListele = new OleDbDataAdapter(query, baglantim);
                DataSet dsHafiza = new DataSet();
                personelleriListele.Fill(dsHafiza);
                dataGridView2.DataSource = dsHafiza.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglantim.Close();
            }
        }

       
        private void form3_Load(object sender, EventArgs e)
        {
        
            PersonelleriGoster();
            this.Text = "KULLANICI İŞLEMLERİ";
            label7.Text = $"{Form1.adi} {Form1.soyadi}";


            try
            {
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg.jpg");
            }
            catch
            {
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg.jpg");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            muhasebe muhasebeForm = new muhasebe();
            muhasebeForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            string tcno = textBox1.Text.Trim(); 

         
            if (tcno.Length == 11)
            {
                try
                {
                    baglantim.Open();

                   
                    string query = "SELECT * FROM personeller WHERE tcno = ?";
                    OleDbCommand selectsorgu = new OleDbCommand(query, baglantim);
                    selectsorgu.Parameters.AddWithValue("?", tcno);  

                    OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                    while (kayitokuma.Read())
                    {
                        kayit_arama_durumu = true;

                        textBox2.Text = kayitokuma["ad"].ToString();  
                        textBox3.Text = kayitokuma["soyad"].ToString();  
                        textBox4.Text = kayitokuma["cinsiyet"].ToString();  
                        textBox5.Text = kayitokuma["mezuniyet"].ToString();  
                        textBox6.Text = kayitokuma["dogumtarihi"].ToString();  
                        textBox7.Text = kayitokuma["departman"].ToString();  
                        textBox8.Text = kayitokuma["gorevyeri"].ToString();  
                        textBox9.Text = kayitokuma["islemi_yapan"].ToString(); 

                        break; 
                    }

                    if (kayit_arama_durumu == false)
                    {
                        MessageBox.Show("Girilen TC'ye ait bir kayıt bulunamadı.", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    kayitokuma.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir 11 haneli TC Kimlik No giriniz!", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tcno = textBox1.Text.Trim(); 

        
            if (string.IsNullOrWhiteSpace(tcno))
            {
                MessageBox.Show("Lütfen geçerli bir TC Kimlik No giriniz.", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");
            try
            {
                connection.Open();

                // Güncelleme sorgusunu yazıyoruz.
                string query = "UPDATE personeller SET ad = ?, soyad = ?, cinsiyet = ?, mezuniyet = ?, dogumtarihi = ?, departman = ?, gorevyeri = ?, islemi_yapan = ? WHERE tcno = ?";

                OleDbCommand command = new OleDbCommand(query, connection);

                // Parametreleri ekliyoruz
                command.Parameters.AddWithValue("?", textBox2.Text); // Ad
                command.Parameters.AddWithValue("?", textBox3.Text); // Soyad
                command.Parameters.AddWithValue("?", textBox4.Text); // Cinsiyet
                command.Parameters.AddWithValue("?", textBox5.Text); // Mezuniyet
                command.Parameters.AddWithValue("?", textBox6.Text); // Doğum Tarihi
                command.Parameters.AddWithValue("?", textBox7.Text); // Departman
                command.Parameters.AddWithValue("?", textBox8.Text); // Görev Yeri
                command.Parameters.AddWithValue("?", textBox9.Text); // İşlemi Yapan
                command.Parameters.AddWithValue("?", tcno); // TC No (WHERE şartı)

            
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kayıt başarıyla güncellendi.", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    PersonelleriGoster(); 

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu. Lütfen tekrar deneyin.", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  
                }
            }
        }
    }
}
