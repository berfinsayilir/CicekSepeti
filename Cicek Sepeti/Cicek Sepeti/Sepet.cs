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

namespace Cicek_Sepeti
{
    public partial class Sepet : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); // veri tabanına bağlanma komutu

        public Sepet()
        {
            InitializeComponent();
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        public int kullaniciId { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                button2.Text = "Sepeti Boşalt";
            }
            else
            {
                button2.Text = "Seçili Ürünü Sepetten Sil";

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                button1.Text = "Tüm Ürünleri Sipariş Et";
            }
            else
            {
                button1.Text = "Seçili Ürünü Sipariş Et";
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void Listele()
        {
            baglanti.Open();
            string kod = "Select *From Tbl_Sepetim where KullaniciId = " + kullaniciId + "";
            SqlDataAdapter da = new SqlDataAdapter(kod, baglanti);
            DataTable df = new DataTable();
            da.Fill(df);
            dataGridView1.DataSource = df; // Datagridviewe verileri çekme
            baglanti.Close();
        }

        bool sepetKontrol = false;
        private void Sepet_Load(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            string islem = "Select *From Tbl_Sepetim where KullaniciId ='" + kullaniciId + "' "; // İd Çekme
            SqlCommand comand = new SqlCommand(islem, baglanti);
            SqlDataReader oku = comand.ExecuteReader();
            while (oku.Read())
            {
                sepetKontrol = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == "Seçili Ürünü Sepetten Sil")
            {
                if(sepetKontrol)
                {
                    baglanti.Close();
                    baglanti.Open();
                    int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
                    string adi = dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString();
                    string silmeKodu = "Delete From Tbl_Sepetim where UrunKodu = '" + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + "'"; // silinecek ürün aranıyor ve varsa siliniyor
                    SqlCommand komut9 = new SqlCommand(silmeKodu, baglanti);
                    komut9.ExecuteNonQuery();

                    MessageBox.Show(adi + "  Ürünü Başarıyla Sepetten Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    Listele();
                }
                else
                {
                    MessageBox.Show("Lütfen Önce Bir Ürün Seçin", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Tüm Sepetinizde ki Ürünler Silinecek Onaylıyor Musunuz ? ", "Çiçek Sepeti",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    baglanti.Close();
                    baglanti.Open();
                    string silmeKodu = "Delete From Tbl_Sepetim where KullaniciId = " + kullaniciId + ""; // silinecek ürün aranıyor ve varsa siliniyor
                    SqlCommand komut9 = new SqlCommand(silmeKodu, baglanti);
                    komut9.ExecuteNonQuery();

                    MessageBox.Show("Sepetiniz Boşaltıldı", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    Listele();
                }
                else
                {
                    MessageBox.Show("İşlem İptal Edildi", "Çiçek Sepeti", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private string AdCek()
        {
            baglanti.Close();
            baglanti.Open();
            string islem = "Select AdSoyad From Tbl_Kullanicilar where KullaniciId ='" + kullaniciId + "'"; // İd Çekme
            SqlCommand comand = new SqlCommand(islem, baglanti);
            SqlDataReader oku = comand.ExecuteReader();
            string dd = "";
            while (oku.Read())
            {
                dd = oku[0].ToString(); // İd'yi Stringe dönüştürme
                break;
            }
            baglanti.Close();

            return dd; 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(txtAdres.Text == "Adres" || txtAdres.Text == "" || txtTelNo.Text == "Tel No" || txtTelNo.Text == "")
            {
                MessageBox.Show("Lütfen Adres ve Tel No Verisini Eksiksiz Giriniz.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (button1.Text == "Seçili Ürünü Sipariş Et")
                {
                    if(sepetKontrol)
                    { 
                        int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
                        string kodu = dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value.ToString();
                        string Urunadi = dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString();
                        string Miktar = dataGridView1.Rows[seciliUrun].Cells["Miktar"].Value.ToString();
                        string gg = dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value.ToString();
                        string adsoyad = AdCek();
                        baglanti.Open();
                        string kod2 = "Insert Into Tbl_Siparis (KullaniciId, UrunKodu, UrunAdi, SiparisMikari, [Ad-Soyad], Adres, TelefonNo) Values(@a1,@a2,@a3,@a4,@a5,@a6,@a7)"; // Ürün ekleme kodu
                        SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu
                        komut2.Parameters.AddWithValue("@a1", kullaniciId); // Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a2", Convert.ToInt32(kodu));// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a3", Urunadi);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a4", Convert.ToInt32(Miktar));// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a5", adsoyad);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a6", txtAdres.Text); // Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a7", Convert.ToInt32(txtTelNo.Text)); // Value değerleri atanıyor
                        komut2.ExecuteNonQuery();

                        MessageBox.Show(Urunadi + " Ürününü Sipariş Ettiniz. Sipariş Takipten Kargonuzu Takip Edebilirsiniz.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        baglanti.Close();
                        Listele();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir ürün Seçiniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    int sayac = 0;
                    while (true)
                    {
                        bool kontrolDD = true;
                        string adsoyad = AdCek();
                        baglanti.Open();
                        string islem = "Select *From Tbl_Sepetim where KullaniciId ='" + kullaniciId + "' "; // İd Çekme
                        SqlCommand comand = new SqlCommand(islem, baglanti);
                        SqlDataReader oku = comand.ExecuteReader();

                        int urun_Kodu = 0;
                        string urun_Adi = "";
                        int miktar = 0;
                        string icerik = "";

                        while (oku.Read())
                        {
                            kontrolDD = false;
                            urun_Kodu = Convert.ToInt32(oku[1]);
                            urun_Adi = oku[2].ToString();
                            miktar = Convert.ToInt32(oku[3]);
                            icerik = oku[4].ToString();
                            break;
                        }
                        baglanti.Close();

                        if (kontrolDD)
                        {
                            break;
                        }
                        sayac++;
                        baglanti.Open();
                        string kod2 = "Insert Into Tbl_Siparis (KullaniciId, UrunKodu, UrunAdi, SiparisMikari, [Ad-Soyad], Adres, TelefonNo) Values(@a1,@a2,@a3,@a4,@a5,@a6,@a7)"; // Ürün ekleme kodu
                        SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu
                        komut2.Parameters.AddWithValue("@a1", kullaniciId); // Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a2", urun_Kodu);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a3", urun_Adi);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a4", miktar);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a5", adsoyad);// Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a6", txtAdres.Text); // Value değerleri atanıyor
                        komut2.Parameters.AddWithValue("@a7", Convert.ToInt32(txtTelNo.Text)); // Value değerleri atanıyor
                        komut2.ExecuteNonQuery();

                        MessageBox.Show(urun_Adi + " Ürününü Sipariş Ettiniz. Sipariş Takipten Kargonuzu Takip Edebilirsiniz.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        baglanti.Close();


                    }
                    Listele();
                    if (sayac == 0)
                    {
                        MessageBox.Show("Sepetinizde Ürün Yok !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

           
        }
    }
}
