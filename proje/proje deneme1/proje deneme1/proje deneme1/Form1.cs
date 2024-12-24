using System.Data.OleDb;
using System.Windows.Forms;
using System;



namespace proje_deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb");

       
        public static string tcno, adi, soyadi, departmani, yetki;
        public string Departman { get; set; }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '*'; button3.Text = "Göster"; } else { textBox2.PasswordChar = '\0'; button3.Text = "Gizle"; }
            }

        public static class GlobalData
        {
            public static string kullaniciAdi { get; set; }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;
            GlobalData.kullaniciAdi = textBox1.Text;


            if (hak == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş Hakkı Kalmadı !", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                baglantim.Open();

                // Kullanıcıyı veritabanında kontrol et
                OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM kullanicilar WHERE kullaniciadi = ? AND parola = ?", baglantim);
                selectCommand.Parameters.AddWithValue("?", kullaniciAdi);
                selectCommand.Parameters.AddWithValue("?", sifre);

                OleDbDataReader kayitOkuma = selectCommand.ExecuteReader();

                if (kayitOkuma.Read())
                { 
                  
                    tcno = kayitOkuma["tcno"].ToString();
                    adi = kayitOkuma["ad"].ToString();
                    soyadi = kayitOkuma["soyad"].ToString();
                    departmani = kayitOkuma["departmani"].ToString(); 
                    yetki = kayitOkuma["yetki"].ToString(); 

                 
                    switch (departmani)
                    {
                        case "Yönetici":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (Yönetici)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            owner ownerForm = new owner();
                            this.Hide();
                            ownerForm.Show();
                            break;

                        case "Kullanıcı":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (Kullanıcı)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Kullanıcının izinlerini kontrol et
                            OleDbCommand izinlerCommand = new OleDbCommand("SELECT * FROM Izinler WHERE tcno = ?", baglantim);
                            izinlerCommand.Parameters.AddWithValue("?", tcno);
                            OleDbDataReader izinlerOkuma = izinlerCommand.ExecuteReader();

                            if (izinlerOkuma.HasRows)
                            {
                                perskart perskartForm = new perskart();
                                this.Hide();
                                perskartForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("İzinler verisi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;

                        case "Manager":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (Manager)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mudur mudurForm = new mudur();
                            this.Hide();
                            mudurForm.Show();
                            break;

                        case "ik":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (İnsan Kaynakları)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ıkakart ıkakartForm = new ıkakart();
                            this.Hide();
                            ıkakartForm.Show();
                            break;

                        case "Muhasebe":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (Muhasebe)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            muhasebe muhasebeForm = new muhasebe();
                            this.Hide();
                            muhasebeForm.Show();
                            break;

                        case "Departman Sorumlusu":
                            MessageBox.Show($"Hoşgeldiniz, {adi} {soyadi} (Departman Sorumlusu)", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dpsorumlu dpSorumlusuForm = new dpsorumlu();
                            this.Hide();
                            dpSorumlusuForm.Show();
                            break;

                        default:
                            MessageBox.Show("Tanımlanamayan departman türü!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    hak--;
                    label5.Text = hak.ToString();
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (hak == 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show("Giriş Hakkı Kalmadı !", "Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglantim.Close();
            }
        }

     

        
        int hak = 3;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi...";
            this.AcceptButton = button1;
            this.CancelButton = button2;
            label5.Text = Convert.ToString(hak);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}