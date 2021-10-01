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
    public partial class Kaydol : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); // Veri tabanına bağlanma

        public Kaydol()
        {
            InitializeComponent();
        }
        bool formTasiniyor = false; // Mause ile form taşıyabilme kodu
        Point baslangicNoktasi = new Point(0, 0); // Mause ile form taşıyabilme kodu
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // simge durumuna taşıma
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Kayit()
        {
            string mailAdres = "";
            if (txtMail.Text != "")
            {
                mailAdres = txtMail.Text;
            }
            else if (txtMail2.Text != "")
            {
                mailAdres = txtMail2.Text;
            }

            baglanti.Open();
            string mailKontrol = "Select Email From Tbl_Kullanicilar where Email ='" + mailAdres + "'"; // Email sorgusu
            SqlCommand comand = new SqlCommand(mailKontrol, baglanti);
            SqlDataReader oku = comand.ExecuteReader();

            if (oku.Read())
            {
                baglanti.Close();
                MessageBox.Show("Bu E-mail Adresi Başka Kullanıcı Tarafından Kullanılmakta. Lütfen Başka E-mail Adresi Giriniz ", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void kayitOnay()
        {
            baglanti.Open();

            string kod2 = "Update Tbl_Kullanicilar Set OnayDurumu = 'Onaysız Hesap' where Email = '" + txtMail.Text + "' OR Email = '" + txtMail2.Text + "'"; // Ürün güncelleme kodu
            SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu
            
            komut2.ExecuteNonQuery();


            baglanti.Close();
        }

        string mail = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if(Kayit())
            {
                baglanti.Close();

                if (txtName1.Text == "" || txtMail.Text == "" || txtPass1.Text == "") // textbox kontrolleri
                {
                    MessageBox.Show("Lütfen Tüm Verileri Eksiksiz Giriniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    baglanti.Open();
                    String islem = "insert into TBL_Kullanicilar(AdSoyad,Email,Sifre,KullaniciTuru) values(@a1,@a2,@a3,@a4)"; // Yeni kullanıcı Ekleme
                    SqlCommand komut = new SqlCommand(islem, baglanti); 

                    komut.Parameters.AddWithValue("@a1", txtName1.Text); // value değerlerini girme
                    komut.Parameters.AddWithValue("@a2", txtMail.Text);
                    komut.Parameters.AddWithValue("@a3", txtPass1.Text);
                    komut.Parameters.AddWithValue("@a4", "Müşteri");

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    mail = txtMail.Text;
                    kayitOnay();
                    MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşti", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Kayit())
            {
                baglanti.Close();

                if (txtName2.Text == "" || txtMail2.Text == "" || txtPass2.Text == "" || txtKurum.Text == "" || txtTel.Text == "") // textbox kontrol
                {
                    MessageBox.Show("Lütfen Tüm Verileri Eksiksiz Giriniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    baglanti.Open();
                    String islem = "insert into TBL_Kullanicilar(AdSoyad,Email,Sifre,KullaniciTuru,KurumAdi,TelefonNo) values(@a1,@a2,@a3,@a4,@a5,@a6)"; // yeni kayır alanı (satıcı)
                    SqlCommand komut = new SqlCommand(islem, baglanti);

                    komut.Parameters.AddWithValue("@a1", txtName2.Text); // value değerlerini girme
                    komut.Parameters.AddWithValue("@a2", txtMail2.Text);
                    komut.Parameters.AddWithValue("@a3", txtPass2.Text);
                    komut.Parameters.AddWithValue("@a4", "Satıcı");
                    komut.Parameters.AddWithValue("@a5", txtKurum.Text);
                    komut.Parameters.AddWithValue("@a6", txtTel.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    mail = txtMail2.Text;
                    kayitOnay();

                    MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşti", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
