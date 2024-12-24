using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using static proje_deneme1.Form1;

namespace proje_deneme1
{
    public partial class dpname : Form
    {
        public dpname()
        {
            InitializeComponent();
        }


        private readonly string connectionString = @"Provider=Microsoft.Ace.OleDb.12.0;Data Source=C:\Users\turka\OneDrive\Masaüstü\proje deneme1\proje deneme1\proje deneme1\bin\Debug\test1.accdb";

    
        private void LoadData(string department = null)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = string.IsNullOrEmpty(department)
                        ? "SELECT * FROM dpsorum"
                        : "SELECT * FROM dpsorum WHERE departmani = ?";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                    if (!string.IsNullOrEmpty(department))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("?", department);
                    }

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DISTINCT departmani FROM dpsorum";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    comboBox1.DisplayMember = "departmani";
                    comboBox1.ValueMember = "departmani";
                    comboBox1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dpname_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDepartments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO dpsorum (tcno, adi, soyadi, telno, [e-posta], yetki, departmani) VALUES (?, ?, ?, ?, ?, ?, ?)";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("?", textBox3.Text);
                    command.Parameters.AddWithValue("?", textBox4.Text);
                    command.Parameters.AddWithValue("?", textBox5.Text);
                    command.Parameters.AddWithValue("?", textBox7.Text);
                    command.Parameters.AddWithValue("?", textBox8.Text);
                    command.Parameters.AddWithValue("?", textBox9.Text);
                    command.Parameters.AddWithValue("?", textBox6.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tcno = textBox3.Text;

            if (string.IsNullOrEmpty(tcno))
            {
                MessageBox.Show("Lütfen bir TC No girin.");
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE dpsorum SET adi = ?, soyadi = ?, telno = ?, [e-posta] = ?, yetki = ?, departmani = ? WHERE tcno = ?";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("?", textBox4.Text);
                    command.Parameters.AddWithValue("?", textBox5.Text);
                    command.Parameters.AddWithValue("?", textBox7.Text);
                    command.Parameters.AddWithValue("?", textBox8.Text);
                    command.Parameters.AddWithValue("?", textBox9.Text);
                    command.Parameters.AddWithValue("?", textBox6.Text);
                    command.Parameters.AddWithValue("?", tcno);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt güncellendi!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tcno = textBox3.Text;

            if (string.IsNullOrEmpty(tcno))
            {
                MessageBox.Show("Lütfen bir TC No girin.");
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM dpsorum WHERE tcno = ?";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("?", tcno);

                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox4.Text = reader["adi"].ToString();
                        textBox5.Text = reader["soyadi"].ToString();
                        textBox7.Text = reader["telno"].ToString();
                        textBox8.Text = reader["e-posta"].ToString();
                        textBox9.Text = reader["yetki"].ToString();
                        textBox6.Text = reader["departmani"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bu TC No'ya ait bir kayıt bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tcno = textBox3.Text;

            if (string.IsNullOrEmpty(tcno))
            {
                MessageBox.Show("Lütfen bir TC No girin.");
                return;
            }

            var confirmResult = MessageBox.Show("Bu personeli silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM dpsorum WHERE tcno = ?";
                        OleDbCommand command = new OleDbCommand(query, connection);
                        command.Parameters.AddWithValue("?", tcno);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt silindi!");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDepartment = comboBox1.SelectedValue.ToString();
            LoadData(selectedDepartment);
        }


        private void label9_Click(object sender, EventArgs e)
        {
           
            OleDbConnection connection = new OleDbConnection(connectionString); 
            string kullaniciAdi = GlobalData.kullaniciAdi;  
            string departmani = ""; 

            try
            {
    
                connection.Open(); 

               
                OleDbCommand selectCommand = new OleDbCommand("SELECT departmani FROM kullanicilar WHERE kullaniciadi = ?", connection);  
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
                    else if (departmani == "Departman Sorumlusu")
                    {
                        dpsorumlu dpSorumlusuForm = new dpsorumlu();
                        dpSorumlusuForm.Show(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Yönetici veya Departman Sorumlusu departmanına ait kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                connection.Close(); 
            }


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 11)
            {
                textBox3.Text = textBox3.Text.Substring(0, 11); textBox3.SelectionStart = textBox3.Text.Length; 
            }
        }



    }
}


