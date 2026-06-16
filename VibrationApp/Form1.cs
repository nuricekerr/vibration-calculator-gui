using System;
using System.Drawing;
using System.Windows.Forms;

namespace VibrationApp
{
    public partial class Form1 : Form
    {
        // Arayüz Elemanları (Kutular, Butonlar ve Etiketler)
        private TextBox txtMass;
        private TextBox txtSpring;
        private TextBox txtDamping;
        private Button btnCalculate;
        private Label lblResult;

        public Form1()
        {
            // Pencere Boyutları ve Başlığı
            this.Text = "Mechanical Vibration & Damping GUI";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248);

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Başlık Etiketi
            Label lblTitle = new Label() { Text = "SDOF VIBRATION CALCULATOR", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.FromArgb(26, 54, 93), Location = new Point(30, 20), Size = new Size(400, 30) };
            this.Controls.Add(lblTitle);

            // Kütle Girişi (m)
            Label lblMass = new Label() { Text = "Mass (m - kg):", Font = new Font("Arial", 10, FontStyle.Regular), Location = new Point(30, 70), Size = new Size(150, 20) };
            txtMass = new TextBox() { Location = new Point(200, 68), Size = new Size(100, 25), Text = "15" };
            this.Controls.Add(lblMass);
            this.Controls.Add(txtMass);

            // Yay Sabiti Girişi (k)
            Label lblSpring = new Label() { Text = "Spring Constant (k - N/m):", Font = new Font("Arial", 10, FontStyle.Regular), Location = new Point(30, 110), Size = new Size(170, 20) };
            txtSpring = new TextBox() { Location = new Point(200, 108), Size = new Size(100, 25), Text = "3500" };
            this.Controls.Add(lblSpring);
            this.Controls.Add(txtSpring);

            // Sönümleme Katsayısı Girişi (c)
            Label lblDamping = new Label() { Text = "Damping Coeff. (c - Ns/m):", Font = new Font("Arial", 10, FontStyle.Regular), Location = new Point(30, 150), Size = new Size(170, 20) };
            txtDamping = new TextBox() { Location = new Point(200, 148), Size = new Size(100, 25), Text = "120" };
            this.Controls.Add(lblDamping);
            this.Controls.Add(txtDamping);

            // Hesapla Butonu
            btnCalculate = new Button() { Text = "CALCULATE SYSTEM DYNAMICS", Font = new Font("Arial", 10, FontStyle.Bold), BackColor = Color.FromArgb(43, 108, 176), ForeColor = Color.White, Location = new Point(30, 200), Size = new Size(270, 40), FlatStyle = FlatStyle.Flat };
            btnCalculate.Click += BtnCalculate_Click; // Butona tıklanınca çalışacak fonksiyon
            this.Controls.Add(btnCalculate);

            // Sonuç Paneli (Görsel çerçeve içi)
            lblResult = new Label() { Text = "Enter values and click Calculate...", Font = new Font("Consolas", 10, FontStyle.Regular), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Location = new Point(30, 260), Size = new Size(420, 130), Padding = new Padding(10) };
            this.Controls.Add(lblResult);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Girdileri Kutulardan Çekme ve Ondalık Dönüşümü
                double m = Convert.ToDouble(txtMass.Text);
                double k = Convert.ToDouble(txtSpring.Text);
                double c = Convert.ToDouble(txtDamping.Text);

                if (m <= 0 || k <= 0)
                {
                    MessageBox.Show("Mass and Spring Constant must be greater than zero!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mühendislik Formülleri (Çekirdek Matematik Mantığı)
                double wn = Math.Sqrt(k / m);              // Doğal Frekans
                double cc = 2 * Math.Sqrt(k * m);          // Kritik Sönümleme
                double zeta = c / cc;                      // Sönümleme Oranı

                // Sönümleme Durumu Kararı
                string status = "";
                if (zeta < 1.0) status = "Underdamped (Az Sönümlü - Salınım Yapar)";
                else if (Math.Abs(zeta - 1.0) < 0.001) status = "Critically Damped (Kritik Sönümlü)";
                else status = "Overdamped (Aşırı Sönümlü - Yavaş Kapanış)";

                // Sonuçları Şık Bir Formatla Ekrana Basma
                lblResult.Text = $"--- ANALYSIS RESULTS ---\n\n" +
                                 $"Natural Freq (w_n) : {wn:F4} rad/s\n" +
                                 $"Critical Damp (c_c): {cc:F4} Ns/m\n" +
                                 $"Damping Ratio (ζ)  : {zeta:F4}\n" +
                                 $"System Status      : {status}";
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid numeric variables!", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}