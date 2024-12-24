using System;
using System.Windows.Forms;

namespace proje_deneme1
{
    public partial class loading : Form
    {
        private Timer timer;
        private int progressValue = 0;

        public loading()
        {
            InitializeComponent();

            // ProgressBar ayarları
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Timer oluşturma ve ayarları
            timer = new Timer();
            timer.Interval = 1; // 50 milisaniye (5 saniye için uygun)
            timer.Tick += Timer_Tick; // Timer_Tick metodu ile bağlama
            timer.Start(); // Timer'ı başlat
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue += 1; // ProgressBar değerini artır
            progressBar1.Value = progressValue; // ProgressBar'ı güncelle

            if (progressValue >= progressBar1.Maximum)
            {
                timer.Stop(); // Timer'ı durdur
                this.Hide(); // Loading formunu gizle

                // Form1'i göster
                Form1 form1 = new Form1(); // Form1'i başlat
                form1.Show(); // Form1'i göster
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
