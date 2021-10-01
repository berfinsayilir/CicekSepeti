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
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); // veri tabanına bağlanma komutu
        public Form1()
        {
            InitializeComponent();
        }
        bool formTasiniyor = false; /// Mause ile form taşıyabilme kodu
        Point baslangicNoktasi = new Point(0, 0); // Mause ile form taşıyabilme kodu
        public string mailAdress { get; set; } // Formlar arasaı veri aktarımı değişkeni
        public string kullaniciRutbe { get; set; } // Formlar arasaı veri aktarımı değişkeni
        public bool girisKontrol { get; set; } // Formlar arasaı veri aktarımı değişkeni
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseHover(object sender, EventArgs e) //giris butonuna gelince gizli bölmeleri aktif etme
        {
            loginPicture.Visible = true;
            loginLabel.Visible = true;
            signUpPicture.Visible = true;
            signUpLabel.Visible = true;
            uyelikTimer.Enabled = true;

        }

        private void uyelikTimer_Tick(object sender, EventArgs e) // gizli bölmeleri tekrar gizleme
        {
            loginPicture.Visible = false;
            loginLabel.Visible = false;
            signUpPicture.Visible = false;
            signUpLabel.Visible = false;
            uyelikTimer.Enabled = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Projeyi sonladırma
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // pencereyi simge durumuna getirme
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            formTasiniyor = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e) // Mause ile form taşıyabilme kodu
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) 
        {
            Form siparis = new SiparisTakibi();
            siparis.Show(); // Başka Forma Geçiş
        }

        private void loginPicture_Click(object sender, EventArgs e)
        {
            Form login = new Giris();
            login.Show(); // Başka Forma Geçiş
            this.Hide();
        }

        private void signUpPicture_Click(object sender, EventArgs e)
        {
            Form signup = new Kaydol();
            signup.Show(); // Başka Forma Geçiş
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(girisKontrol)
            {
                Sepet sepetim = new Sepet();
                sepetim.kullaniciId = idCek();
                sepetim.Show(); // Başka Forma Geçiş
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
           //Favori Ürünleri Listeleme (satılan ürünler)

            baglanti.Open();
            string kod = "Favori_Listele"; // ürünleri listeleme Stored Procedure
            SqlDataAdapter da = new SqlDataAdapter(kod, baglanti);
            DataTable df = new DataTable();
            da.Fill(df);
            dataGridView1.DataSource = df; // Datagridviewe verileri çekme
            baglanti.Close();

            baglanti.Open();
            string aramaKodu = "Select OnayDurumu From Tbl_Kullanicilar where Email = '" + mailAdress  + "' "; // ürün arama
            SqlCommand comand = new SqlCommand(aramaKodu, baglanti);
            SqlDataReader oku = comand.ExecuteReader();
            string durum = "";
            while (oku.Read())
            {
                durum = oku[0].ToString(); // durumu Stringe dönüştürme
                break;
            }

            baglanti.Close();

            if(durum == "Onaysız Hesap       ")
            {
                MessageBox.Show("Hesabınız Henüz Onaylanmamış Bir Yöneticinin Hesabınızı Onaylaması Lazım.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTur.Text = durum;
                lblTur.ForeColor = Color.Black;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (girisKontrol) // Program açıldığında kullanıcı türünü belirleme (Yönetici, Satıcı, Müşteri)
            {
                
                pcbGiris.Visible = true;
                lblTur.Visible = true;
                lblMail.Visible = true;
                lblMail.Text = mailAdress;
                lblTur.Text = kullaniciRutbe;

                if(lblTur.Text[0] == 'Y') // Yönetici Alanı
                {
                    lblTur.ForeColor = Color.Red;
                    pcbUsers.Visible = true;
                    lblUsers.Visible = true;
                    pcbInsert.Visible = true;
                    lblInsert.Visible = true;
                    pcbUpdate.Visible = true;
                    lblUpdate.Visible = true;
                    pcbDelete.Visible = true;
                    lblDelete.Visible = true;
                }
                else if (lblTur.Text[0] == 'S') // Satıcı Alanı
                {
                    lblTur.ForeColor = Color.Orange;
                    pcbInsert.Visible = true;
                    lblInsert.Visible = true;
                    pcbUpdate.Visible = true;
                    lblUpdate.Visible = true;
                    pcbDelete.Visible = true;
                    lblDelete.Visible = true;

                }
                else if(lblTur.Text[0] == 'M') // Müşteri Alanı
                {
                    lblTur.ForeColor = Color.Yellow;                
                }

                sepetSayi.Enabled = true;
                pictureBox3.Enabled = false;
                timer1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private int idCek()
        {
            baglanti.Close();
            baglanti.Open();
            string islem = "Select KullaniciId From Tbl_Kullanicilar where Email ='" + lblMail.Text + "'"; // İd Çekme
            SqlCommand comand = new SqlCommand(islem, baglanti);
            SqlDataReader oku = comand.ExecuteReader();
            string dd = "";
            while (oku.Read())
            {
                dd = oku[0].ToString(); // İd'yi Stringe dönüştürme
                break;
            }
            baglanti.Close();

            return Convert.ToInt32(dd); // İd yi İntegera dönüştürme
        }

        private bool sepeteEkle() // Sepete ekleme bölümü
        {
            int seciliUrun = dataGridView1.SelectedCells[0].RowIndex; // Datagridview de seçili ürün
            
            string islem3 = "Select UrunAdi From Tbl_Sepetim where KullaniciId = " + idCek() + " AND UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; //Ürün arama
            baglanti.Open();
            SqlCommand comand = new SqlCommand(islem3, baglanti);
            SqlDataReader oku = comand.ExecuteReader();
            string dd = "";
            while (oku.Read())
            {
                dd = oku[0].ToString();
                break;
            }
            if (dd.Length <= 0)
            {
                baglanti.Close();
                return true; //Sepette yok ekle anlamında
            }
            else
            {
                baglanti.Close();
                return false; // sepette var sayısını bir arttır
            }

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

            if(lblMail.Text == "" || lblMail.Text == "Mail") // giriş yapma zorunluluğu
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız !","Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int seciliUrun = dataGridView1.SelectedCells[0].RowIndex; // Datagridview de seçili ürün

                int stokKontrol = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["StokMiktari"].Value); // Datagridview de seçili ürün

                if (stokKontrol <= 0) // stok bitti mi ?
                {
                    MessageBox.Show("Ürün Stokta Yok", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (sepeteEkle()) // ürün sepette varmı yok mu kontrol ediliyor
                    {
                        baglanti.Open();
                        String islem = "insert into TBL_Sepetim(KullaniciId,UrunKodu,UrunAdi,Miktar,Icerik) values(@a1,@a2,@a3,@a4,@a5)"; // Sepete Ürün Ekleme
                        SqlCommand komut = new SqlCommand(islem, baglanti);

                        baglanti.Close();

                        komut.Parameters.AddWithValue("@a1", idCek()); // Value değerleri giriliyor
                        baglanti.Open();
                        komut.Parameters.AddWithValue("@a2", dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value); // Value değerleri giriliyor
                        komut.Parameters.AddWithValue("@a3", dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString()); // Value değerleri giriliyor
                        komut.Parameters.AddWithValue("@a4", 1); // 1 adet sepete eklendi
                        komut.Parameters.AddWithValue("@a5", dataGridView1.Rows[seciliUrun].Cells["Icerik"].Value.ToString()); // Value değerleri giriliyor

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Ürün Sepete Eklenmiştir.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int miktar = 0;


                        string islem3 = "Select Miktar From Tbl_Sepetim where KullaniciId = " + idCek() + " AND UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // ürün arama
                        baglanti.Open();
                        SqlCommand comand = new SqlCommand(islem3, baglanti);
                        SqlDataReader readd = comand.ExecuteReader();
                        string dd = "";
                        while (readd.Read())
                        {
                            dd = readd[0].ToString();
                            break;
                        }
                        //MessageBox.Show(dd);

                        miktar = Convert.ToInt32(dd); // sepetteki adet sayısını öğrendik şimdi bir arttıracağız

                        baglanti.Close();


                        string islem5 = "Update Tbl_Sepetim Set Miktar = @a1 where KullaniciId = " + idCek() + " AND UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // ürün arama
                        baglanti.Open();
                        SqlCommand komut5 = new SqlCommand(islem5, baglanti);
                        komut5.Parameters.AddWithValue("@a1", miktar + 1); // ürün sepette mevcur olduğu için sepetteki sayısı 1 arttırıldı
                        komut5.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Ürün Sepete Eklenmiştir.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }

        }
        string kod = "";

        private void Listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter(kod, baglanti);
            DataTable df = new DataTable();
            da.Fill(df);
            dataGridView1.DataSource = df; // datagridviewe ürünler listelendi
            baglanti.Close();
        }
        bool kontrol = false;

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
                if (lblTur.Text[0] == 'Y' || lblTur.Text[0] == 'S') // Yönetici ve satıcıya tüm tablo bilgilerini getirme
                {
                    kod = "Tbl_Urun_Listele"; // Stored Procedure
                }
                else
                {
                    kod = "Select UrunKodu, UrunAdi, StokMiktari, SatisFiyati, Icerik, KategoriNo From Tbl_Urun"; // Satıcıya ise istenilen bilgileri getirme
                }
            Listele();
            kontrol = true;
        }

        private void pcbInsert_Click(object sender, EventArgs e) 
        {
            InsertAndUpdate insert = new InsertAndUpdate();
            insert.deger = "Ekle"; // Formlar arası veri gönderimi
            insert.Show();

        }

        private void pcbUpdate_Click(object sender, EventArgs e)
        {
            InsertAndUpdate update = new InsertAndUpdate();
            update.deger = "Güncelle"; // Formlar arası veri gönderimi
            try
            {
                int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
                update.urunkodu = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value); // Formlar arası veri gönderimi
                update.urunadi = dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString(); // Formlar arası veri gönderimi
                update.stokmiktari = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["StokMiktari"].Value); // Formlar arası veri gönderimi
                update.alisfiyati = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["AlisFiyati"].Value); // Formlar arası veri gönderimi
                update.satisfiyati = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["SatisFiyati"].Value); // Formlar arası veri gönderimi
                update.icerik = dataGridView1.Rows[seciliUrun].Cells["Icerik"].Value.ToString(); // Formlar arası veri gönderimi
                update.kategorino = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["KategoriNo"].Value); // Formlar arası veri gönderimi
                update.Show();
            }
            catch
            {
                MessageBox.Show("Lütfen Önce Bir Ürün Seçin", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void pcbDelete_Click(object sender, EventArgs e) // Ürün Silme
        {

            try
            {
                int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
                int urunKodu = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value);
                string adi = dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString();
                if (lblTur.Text[0] == 'S' && kontrol == false) // Yönetici Alanı
                {
                    MessageBox.Show("Yetki Kısıtlaması Nedeniyle Favori Bölümünden Veri Silemezsiniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(lblTur.Text[0] == 'Y' && kontrol == false)
                {
                    baglanti.Open();
                    string silmeKodu5 = "Delete From Tbl_UrunSatis Where UrunKodu = " + urunKodu + ""; // Ürün Silme
                    SqlCommand komut5 = new SqlCommand(silmeKodu5, baglanti);
                    komut5.Parameters.AddWithValue("@urunKodu", urunKodu);
                    komut5.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show(adi + "  Ürünü Başarıyla Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Open();
                    string kod = "Favori_Listele"; // ürünleri listeleme Stored Procedure
                    SqlDataAdapter da = new SqlDataAdapter(kod, baglanti);
                    DataTable df = new DataTable();
                    da.Fill(df);
                    dataGridView1.DataSource = df; // Datagridviewe verileri çekme
                    baglanti.Close();
                }
                else
                {
                    /*

                    baglanti.Open();
                    string silmeKodu3 = "Delete From Tbl_Sepetim where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                    SqlCommand komut7 = new SqlCommand(silmeKodu3, baglanti);
                    komut7.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    string silmeKodu4 = "Delete From Tbl_Siparis where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                    SqlCommand komut6 = new SqlCommand(silmeKodu4, baglanti);
                    komut6.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    string silmeKodu2 = "Delete From Tbl_UrunSatis where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                    SqlCommand komut8 = new SqlCommand(silmeKodu2, baglanti);
                    komut8.ExecuteNonQuery();
                    baglanti.Close();

                    string silmeKodu = "Delete From Tbl_Urun where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                    baglanti.Open();
                    SqlCommand komut9 = new SqlCommand(silmeKodu, baglanti);
                    komut9.ExecuteNonQuery();

                    MessageBox.Show(adi + "  Ürünü Başarıyla Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();
                    Listele();

                    */



                    int urunKodu2 = Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value);

                    baglanti.Open();
                    string silmeKodu4 = "Tbl_Urun_VeriSil"; // Stored Procedure Kullanarak Ürün Silme
                    SqlCommand komut6 = new SqlCommand(silmeKodu4, baglanti);
                    komut6.CommandType = CommandType.StoredProcedure;
                    komut6.Parameters.Add("@urunKodu", SqlDbType.Int, 50);
                    komut6.Parameters["@urunKodu"].Value = urunKodu2;
                    komut6.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(adi + "  Ürünü Başarıyla Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                    
                }
                
            }
            catch
            {
                MessageBox.Show("Lütfen Önce Bir Ürün Seçin", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*
            int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
                string adi = dataGridView1.Rows[seciliUrun].Cells["UrunAdi"].Value.ToString();

            baglanti.Open();
            string silmeKodu3 = "Delete From Tbl_Sepetim where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
            SqlCommand komut7 = new SqlCommand(silmeKodu3, baglanti);
            komut7.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            string silmeKodu4 = "Delete From Tbl_Siparis where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
            SqlCommand komut6 = new SqlCommand(silmeKodu4, baglanti);
            komut6.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
                string silmeKodu2 = "Delete From Tbl_UrunSatis where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                SqlCommand komut8 = new SqlCommand(silmeKodu2, baglanti);
                komut8.ExecuteNonQuery();
                baglanti.Close();

                string silmeKodu = "Delete From Tbl_Urun where UrunKodu = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["UrunKodu"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                baglanti.Open();
                SqlCommand komut9 = new SqlCommand(silmeKodu, baglanti);
                komut9.ExecuteNonQuery();

                MessageBox.Show(adi + "  Ürünü Başarıyla Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglanti.Close();
         
             */

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(txtAra.Text == "" || txtAra.Text == "Aramak İstediğiniz Ürünü Giriniz...")
            {
                MessageBox.Show("Lütfen Aramak İstediğiniz Ürünün Adını Giriniz.","Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();
                string aramaKodu = "Select *From Tbl_Urun where UrunAdi = '" + txtAra.Text + "' "; // ürün arama
                SqlDataAdapter da = new SqlDataAdapter(aramaKodu, baglanti);
                DataTable df = new DataTable();
                da.Fill(df);
                dataGridView1.DataSource = df; // datagridviewe ürünler listelendi
                baglanti.Close();
            }
        }

        private void sepetSayi_Tick(object sender, EventArgs e)
        {
            if(girisKontrol)
            {
                string kod2 = "SELECT COUNT(*) FROM Tbl_Sepetim where KullaniciId =" + idCek() + "";
                baglanti.Open();
                SqlCommand comand = new SqlCommand(kod2, baglanti);
                SqlDataReader oku = comand.ExecuteReader();
                string deger = "";
                while (oku.Read())
                {
                    deger = oku[0].ToString(); // İd'yi Stringe dönüştürme
                    break;
                }
                baglanti.Close();

                lblAdet.Text = deger.ToString();
            }
        }

        private void pcbUsers_Click(object sender, EventArgs e)
        {
            Users kullanici = new Users();
            kullanici.Show();
        }
    }
}
