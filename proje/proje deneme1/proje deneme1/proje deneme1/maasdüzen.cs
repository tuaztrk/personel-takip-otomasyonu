using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using static proje_deneme1.Form1;

namespace proje_deneme1
{
    public partial class maasdüzen : Form
    {
  
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");
        public maasdüzen()
        {
            InitializeComponent();
            VerileriYukle();
            VerileriYukleDataGridView1();


            comboBox1.Items.Add("10.000 TL ve üzeri");
            comboBox1.Items.Add("20.000 TL ve üzeri");
            comboBox1.Items.Add("30.000 TL ve üzeri");
            comboBox1.Items.Add("50.000 TL ve üzeri");
            comboBox1.Items.Add("100.000 TL ve üzeri");
        }

      
        private void VerileriYukle()
        {
            try
            {
                if (baglantim.State == ConnectionState.Closed)
                {
                    baglantim.Open();
                }

         
                string sorgu = "SELECT tcno, ad, soyad, cinsiyet, dogumtarihi, departman, maasi, prim,mesai_saat, islemi_yapan FROM personeller";
                OleDbDataAdapter da = new OleDbDataAdapter(sorgu, baglantim);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPersoneller.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }
            }
        }



        private void VerileriYukleDataGridView1()
        {
            try
            {
                if (baglantim.State == ConnectionState.Closed)
                {
                    baglantim.Open();
                }

             
                string sorgu = "SELECT tcno, ad, soyad, cinsiyet, dogumtarihi, departman, maasi, prim,mesai_saat, islemi_yapan FROM personeller";
                OleDbDataAdapter dab = new OleDbDataAdapter(sorgu, baglantim);
                DataTable dtb = new DataTable();
                dab.Fill(dtb);
                dataGridView1.DataSource = dtb;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
            finally
            {
                if (baglantim.State == ConnectionState.Open)
                {
                    baglantim.Close();
                }
            }
        }

        
        private void ara_Click(object sender, EventArgs e)
        {
            string tcno = tcnoo.Text.Trim(); 

            if (!string.IsNullOrEmpty(tcno))
            {
                try
                {
                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }

                    string sorgu = "SELECT * FROM personeller WHERE tcno = @tcno"; 
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@tcno", tcno);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvPersoneller.DataSource = dt;                  
                    }
                    else
                    {
                        MessageBox.Show("Bu TC kimlik numarasıyla kayıtlı personel bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arama hatası: " + ex.Message);
                }
                finally
                {
              
                    if (baglantim.State == ConnectionState.Open)
                    {
                        baglantim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir TC Kimlik Numarası girin.");
            }
        }

        private void btnMaasArtir_Click_1(object sender, EventArgs e)
        {
            if (dgvPersoneller.SelectedRows.Count > 0 && !string.IsNullOrEmpty(txtArtisMiktari.Text))
            {
                try
                {
                    decimal artisMiktari = decimal.Parse(txtArtisMiktari.Text);
                    string tcno = dgvPersoneller.SelectedRows[0].Cells["tcno"].Value.ToString();
                    string islemYapan = textBox6.Text.Trim(); 

                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }

                   
                    string sorgu = "UPDATE personeller SET maasi = maasi + @artis, islemi_yapan = @islemi_yapan WHERE tcno = @tcno";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@artis", artisMiktari);
                    cmd.Parameters.AddWithValue("@islemi_yapan", islemYapan); 
                    cmd.Parameters.AddWithValue("@tcno", tcno);
                    cmd.ExecuteNonQuery();

                    VerileriYukle(); 

                    MessageBox.Show("Maaş artışı başarıyla yapıldı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Maaş artışı hatası: " + ex.Message);
                }
                finally
                {
                    if (baglantim.State == ConnectionState.Open)
                    {
                        baglantim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir personel seçin ve artış miktarını girin.");
            }
        }

 
        private void btnTopluArtis_Click_1(object sender, EventArgs e)
        {
            string islemYapan = textBox6.Text.Trim(); 
            if (!string.IsNullOrEmpty(txtArtisMiktari.Text) && !string.IsNullOrEmpty(islemYapan))
            {
                try
                {
                    decimal artisMiktari = decimal.Parse(txtArtisMiktari.Text);

                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }

           
                    string sorgu = "UPDATE personeller SET maasi = maasi + @artis, islemi_yapan = @islemi_yapan";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@artis", artisMiktari);
                    cmd.Parameters.AddWithValue("@islemi_yapan", islemYapan); 
                    cmd.ExecuteNonQuery();

                    VerileriYukle(); 

                    MessageBox.Show("Toplu maaş artışı başarıyla yapıldı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Toplu maaş artışı hatası: " + ex.Message);
                }
                finally
                {
                    if (baglantim.State == ConnectionState.Open)
                    {
                        baglantim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen toplu artış miktarını girin ve işlemi yapan kişinin ismini belirtin.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string secilenAralik = comboBox1.SelectedItem.ToString();
            decimal sinir = 0;

            if (secilenAralik == "10.000 TL ve üzeri")
            {
                sinir = 10000;
            }
            else if (secilenAralik == "20.000 TL ve üzeri")
            {
                sinir = 20000;
            }
            else if (secilenAralik == "30.000 TL ve üzeri")
            {
                sinir = 30000;
            }
            else if (secilenAralik == "50.000 TL ve üzeri")
            {
                sinir = 50000;
            }
            else if (secilenAralik == "100.000 TL ve üzeri")
            {
                sinir = 100000;
            }

            VerileriFiltrele(sinir);
        }
        private void VerileriFiltrele(decimal sinir)
        {
            try
            {
                baglantim.Open();

               
                string sorgu = "SELECT * FROM personeller WHERE maasi >= @sinir";
                OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                cmd.Parameters.AddWithValue("@sinir", sinir);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

            
                dgvPersoneller.DataSource = dt;

            
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu maaş aralığında hiç personel bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglantim.Close();
            }
        }

        private void btnPrimEkle_Click_Click(object sender, EventArgs e)
        {
            if (dgvPersoneller.SelectedRows.Count > 0 && !string.IsNullOrEmpty(txtArtisMiktari.Text))
            {
                try
                {
                    decimal primMiktari = decimal.Parse(txtArtisMiktari.Text);
                    string tcno = dgvPersoneller.SelectedRows[0].Cells["tcno"].Value.ToString();
                    string islemYapan = textBox6.Text.Trim(); 

                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }

          
                    string sorgu = "UPDATE personeller SET primi = primi + @prim, islemi_yapan = @islemi_yapan WHERE tcno = @tcno";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@prim", primMiktari);
                    cmd.Parameters.AddWithValue("@islemi_yapan", islemYapan); 
                    cmd.Parameters.AddWithValue("@tcno", tcno);
                    cmd.ExecuteNonQuery();

                    VerileriYukle(); 

                    MessageBox.Show("Prim eklemesi başarıyla yapıldı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Prim ekleme hatası: " + ex.Message);
                }
                finally
                {
                    if (baglantim.State == ConnectionState.Open)
                    {
                        baglantim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir personel seçin ve prim miktarını girin.");
            }
        }

        private void btnTopluPrimArtir_Click(object sender, EventArgs e)
        {
            string islemYapan = textBox6.Text.Trim(); // İşlemi yapan kişinin ismi
            if (!string.IsNullOrEmpty(txtArtisMiktari.Text) && !string.IsNullOrEmpty(islemYapan))
            {
                try
                {
                    decimal primMiktari = decimal.Parse(txtArtisMiktari.Text);

                    if (baglantim.State == ConnectionState.Closed)
                    {
                        baglantim.Open();
                    }

       
                    string sorgu = "UPDATE personeller SET primi = primi + @prim, islemi_yapan = @islemi_yapan";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@prim", primMiktari);
                    cmd.Parameters.AddWithValue("@islemi_yapan", islemYapan); 
                    cmd.ExecuteNonQuery();

                    VerileriYukle(); 

                    MessageBox.Show("Toplu prim artışı başarıyla yapıldı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Toplu prim artışı hatası: " + ex.Message);
                }
                finally
                {
                    if (baglantim.State == ConnectionState.Open)
                    {
                        baglantim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen toplu prim miktarını girin ve işlemi yapan kişinin ismini belirtin.");
            }
        }
        //lorem15///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            string tcno = textBox1.Text.Trim(); 

            if (!string.IsNullOrEmpty(tcno))
            {
                try
                {
                    baglantim.Open();
                    string sorgu = "SELECT * FROM personeller WHERE tcno = @tcno"; 
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@tcno", tcno);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

              
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0]["maasi"].ToString();
                        textBox3.Text = dt.Rows[0]["prim"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC kimlik numarasıyla kayıtlı personel bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir TC Kimlik Numarası girin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string tcno = textBox1.Text.Trim();  
            string maas = textBox2.Text.Trim();  
            string prim = textBox3.Text.Trim();  

      
            if (!string.IsNullOrEmpty(tcno) && !string.IsNullOrEmpty(maas) && !string.IsNullOrEmpty(prim))
            {
                try
                {
              
                    baglantim.Open();

                   
                    string sorgu = "UPDATE personeller SET maasi = @maas, prim = @prim WHERE tcno = @tcno";
                    OleDbCommand cmd = new OleDbCommand(sorgu, baglantim);
                    cmd.Parameters.AddWithValue("@maas", decimal.Parse(maas));
                    cmd.Parameters.AddWithValue("@prim", decimal.Parse(prim));
                    cmd.Parameters.AddWithValue("@tcno", tcno);

               
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Maaş ve Prim başarıyla güncellendi!");

                    VerileriYukle(); 
                }
                catch (Exception ex)
                {
             
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
               
                    baglantim.Close();
                }
            }
            else
            {
           
                MessageBox.Show("Lütfen TC, maaş ve prim alanlarını doldurun.");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            VerileriYukleDataGridView1();

        }

        private void maasdüzen_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                    else if (departmani == "Muhasebe")
                    {
                        muhasebe muhasebeDepartmanForm = new muhasebe();  
                        muhasebeDepartmanForm.Show(); 
                        this.Close(); 
                    }
                    else if (departmani == "Manager") 
                    {
                        mudur managerDepartmanForm = new mudur(); 
                        managerDepartmanForm.Show(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Yönetici, Muhasebe veya Manager departmanına ait kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Bağlantıyı kapat
                if (baglantim.State == ConnectionState.Open)
                    baglantim.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
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
                    else if (departmani == "Muhasebe")
                    {
                        muhasebe muhasebeDepartmanForm = new muhasebe();  
                        muhasebeDepartmanForm.Show(); 
                        this.Close(); 
                    }
                    else if (departmani == "Manager") 
                    {
                        mudur managerDepartmanForm = new mudur(); 
                        managerDepartmanForm.Show(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Yönetici, Muhasebe veya Manager departmanına ait kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
