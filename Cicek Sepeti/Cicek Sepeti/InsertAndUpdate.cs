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
    public partial class InsertAndUpdate : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); //Veri Tabanı bağlantısı

        public InsertAndUpdate()
        {
            InitializeComponent();
        }
        public string deger { get; set; } // Formlar arası veri gönderi değişkenleri
        public int urunkodu { get; set; }
        public string urunadi { get; set; }
        public int stokmiktari { get; set; }
        public int alisfiyati { get; set; }
        public int satisfiyati { get; set; }
        public string icerik { get; set; }
        public int kategorino { get; set; }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form anaSayfa = new Form1();  //Form açma
            anaSayfa.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Ürünü Ekle") // ürün ekleme
            {
                if(txtUrunAdi.Text == "" || txtUrunAdi.Text == "Urun Adi" || txtStokMiktari.Text == "" || txtStokMiktari.Text == "Stok Miktari" ||
                    txtAlisFiyati.Text == "" || txtAlisFiyati.Text == "Alis Fiyati" || txtSatisFiyati.Text == "" ||
                    txtSatisFiyati.Text == "Satis Fiyati" || txtIcerik.Text == "" || txtIcerik.Text == "İçerik" ||
                    txtKategoriNo.Text == "" || txtKategoriNo.Text == "Kategori No")  //Textboxlar boş mu diye kontrol ediliyor
                {
                    MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    baglanti.Open();
                    string kod = "Tbl_Urun_VeriEkle @a1, @a2, @a3, @a4, @a5, @a6"; // Veri tabanına ürün ekleme kodu Stored Procedure Kullanıldı
                    
                    SqlCommand komut = new SqlCommand(kod, baglanti); // komut oluşturuldu
                    komut.Parameters.AddWithValue("@a1", txtUrunAdi.Text); // value değerleri atanıyor.
                    komut.Parameters.AddWithValue("@a2", txtStokMiktari.Text);
                    komut.Parameters.AddWithValue("@a3", txtAlisFiyati.Text);
                    komut.Parameters.AddWithValue("@a4", txtSatisFiyati.Text);
                    komut.Parameters.AddWithValue("@a5", txtIcerik.Text);
                    komut.Parameters.AddWithValue("@a6", txtKategoriNo.Text);

                    MessageBox.Show(txtUrunAdi.Text + " Ürünü Başarıyla Veri Tabanına Eklenmiştir.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            else // ürün güncelleme
            {
                if (txtUrunAdi.Text == "" || txtStokMiktari.Text == "" ||
                   txtAlisFiyati.Text == "" || txtSatisFiyati.Text == "" ||
                   txtIcerik.Text == "" || txtKategoriNo.Text == "") //Textboxlar boş mu diye kontrol ediliyor
                {
                    MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    baglanti.Open();

                    string kod2 = "Update Tbl_Urun Set UrunAdi = @a1, StokMiktari = @a2, AlisFiyati = @a3, SatisFiyati = @a4, Icerik = @a5, KategoriNo = @a6 where UrunKodu = '" + txtUrunKodu.Text + "'"; // Ürün güncelleme kodu
                    SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu
                    komut2.Parameters.AddWithValue("@a1", txtUrunAdi.Text); // Value değerleri atanıyor
                    komut2.Parameters.AddWithValue("@a2", txtStokMiktari.Text);// Value değerleri atanıyor
                    komut2.Parameters.AddWithValue("@a3", txtAlisFiyati.Text);// Value değerleri atanıyor
                    komut2.Parameters.AddWithValue("@a4", txtSatisFiyati.Text);// Value değerleri atanıyor
                    komut2.Parameters.AddWithValue("@a5", txtIcerik.Text);// Value değerleri atanıyor
                    komut2.Parameters.AddWithValue("@a6", txtKategoriNo.Text); // Value değerleri atanıyor
                    komut2.ExecuteNonQuery();

                    MessageBox.Show(txtUrunAdi.Text + " Ürünü Başarıyla Güncellendi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();
                }
            }
        }

        private void InsertAndUpdate_Load(object sender, EventArgs e)
        {
            if(deger == "Ekle") // ürün ekleme mi yoksa güncelleme mi diye kontrol ediliyor
            {
                
            }
            else // ürün ekleme mi yoksa güncelleme mi diye kontrol ediliyor
            {
                label1.Text = "Ürün Güncelle"; // ürün güncelleme ekranı bilgileri giriliyor
                button1.Text = "Ürünü Güncelle";
                txtUrunKodu.Text = urunkodu.ToString(); // ana formdan değerler çekiliyor
                txtUrunAdi.Text = urunadi.ToString(); // ana formdan değerler çekiliyor
                txtStokMiktari.Text = stokmiktari.ToString(); // ana formdan değerler çekiliyor
                txtAlisFiyati.Text = alisfiyati.ToString(); // ana formdan değerler çekiliyor
                txtSatisFiyati.Text = satisfiyati.ToString(); // ana formdan değerler çekiliyor
                txtIcerik.Text = icerik.ToString(); // ana formdan değerler çekiliyor
                txtKategoriNo.Text = kategorino.ToString(); // ana formdan değerler çekiliyor
            }
        }
        bool formTasiniyor = false; // Mause ile form taşıyabilme kodu
        Point baslangicNoktasi = new Point(0, 0); // Mause ile form taşıyabilme kodu
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor) // Mause ile form taşıyabilme kodu
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = false;
        }
    }
}
