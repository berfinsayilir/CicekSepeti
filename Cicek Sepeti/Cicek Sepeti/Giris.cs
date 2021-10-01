using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace Cicek_Sepeti
{
    public partial class Giris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); // Veri tabanı bağlantısı
        public Giris()
        {
            InitializeComponent();
        }
        bool formTasiniyor = false; // Formu mause ile taşıma kodları
        Point baslangicNoktasi = new Point(0, 0);  // Formu mause ile taşıma kodları

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // Formu mause ile taşıma kodları
        {
            if (formTasiniyor)  // Formu mause ile taşıma kodları
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Formu mause ile taşıma kodları
        {
            formTasiniyor = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Formu mause ile taşıma kodları
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // simge durumuna taşıma
        }
        int sayi1, sayi2;
        private void Giris_Load(object sender, EventArgs e)
        {
            Random rnd = new Random(); // recapte örneği rastgele sayı oluşturma
            sayi1 = rnd.Next(50);
            sayi2 = rnd.Next(50);

            label1.Text = Convert.ToString(sayi1);
            label3.Text = Convert.ToString(sayi2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form anaSayfa = new Form1();
            anaSayfa.Show(); // ana sayfaya geçiş
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Sifirla = new PasswordReset(); // şifre sıfırlama
            Sifirla.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCevap.Text == Convert.ToString(sayi2 + sayi1)) // recaphta kontrol
            {
                string tur = "";
                baglanti.Open();

                string komut = "Select *From Tbl_Kullanicilar where (Email = '" + txtMail.Text + "') AND Sifre = '" + txtPass.Text + "'"; // giriş kontrolü
                SqlCommand islem = new SqlCommand(komut, baglanti);

                SqlDataReader oku = islem.ExecuteReader();

                if (oku.Read())
                {
                    baglanti.Close();

                    //
                    string islemm = "Select AdSoyad From Tbl_Kullanicilar where Email = '" + txtMail.Text + "'"; // ürün arama
                    baglanti.Open();
                    SqlCommand comand = new SqlCommand(islemm, baglanti);
                    SqlDataReader okuu = comand.ExecuteReader();
                    string dd = "";
                    while (okuu.Read())
                    {
                        dd = okuu[0].ToString();
                        break;
                    }
                    baglanti.Close();
                    ///
                    MessageBox.Show("Giriş Başarılı Hoşgeldiniz Sayın " + dd, "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 anaSayfa = new Form1();


                    baglanti.Open();
                    string kod = "Select KullaniciTuru From Tbl_Kullanicilar where Email='" + txtMail.Text + "'"; // Email çekme
                    SqlCommand komut2 = new SqlCommand(kod, baglanti);
                    SqlDataReader reading = komut2.ExecuteReader();
                    while (reading.Read())
                    {
                        tur = reading[0].ToString();
                        break;
                    }

                    baglanti.Close();
                    anaSayfa.girisKontrol = true; // Formlar arası veri aktarımı
                    anaSayfa.mailAdress = txtMail.Text;
                    anaSayfa.kullaniciRutbe = tur;
                    anaSayfa.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("E-Mail Veya Şifreniz Hatalı Lütfen Tekrar Deneyiniz.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                baglanti.Close();
            }
            else
            {
                MessageBox.Show("İşlem Sonucu Yanlış Lütfen Tekrar Giriniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
