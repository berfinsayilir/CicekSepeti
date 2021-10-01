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
    public partial class Users : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); // veri tabanına bağlanma komutu
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        public Users()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            baglanti.Open();
            string kod = "Select *From Tbl_Kullanicilar"; // ürünleri listeleme
            SqlDataAdapter da = new SqlDataAdapter(kod, baglanti);
            DataTable df = new DataTable();
            da.Fill(df);
            dataGridView1.DataSource = df; // Datagridviewe verileri çekme
            baglanti.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cicekSepetiDataSet.Tbl_Kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            // this.tbl_KullanicilarTableAdapter.Fill(this.cicekSepetiDataSet.Tbl_Kullanicilar);
            Listele();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
            string adSoyad = dataGridView1.Rows[seciliUrun].Cells["AdSoyad"].Value.ToString();

            DialogResult result;
            result = MessageBox.Show(adSoyad + " Kişisi Silinecek Onaylıyor Musunuz ? ", "Çiçek Sepeti", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                baglanti.Open();
                string silmeKodu2 = "Delete From Tbl_Sepetim where KullaniciId = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["KullaniciId"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                SqlCommand komut2 = new SqlCommand(silmeKodu2, baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                string silmeKodu3 = "Delete From Tbl_Siparis where KullaniciId = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["KullaniciId"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                SqlCommand komut3 = new SqlCommand(silmeKodu3, baglanti);
                komut3.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                string silmeKodu1 = "Delete From Tbl_Kullanicilar where KullaniciId = " + Convert.ToInt32(dataGridView1.Rows[seciliUrun].Cells["KullaniciId"].Value) + ""; // silinecek ürün aranıyor ve varsa siliniyor
                SqlCommand komut1 = new SqlCommand(silmeKodu1, baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show(adSoyad + " Kullanıcısı Sistemden Silindi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            else
            {
                MessageBox.Show("Kullanıcı Silme İşlemi İptal Edildi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == "" || txtMail.Text == "" || txtSifre.Text == "" || comboBox1.Text == "") //Textboxlar boş mu diye kontrol ediliyor
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();

                string kod2 = "Update Tbl_Kullanicilar Set AdSoyad = @a1, Email = @a2, Sifre = @a3, KullaniciTuru = @a4, KurumAdi = @a5, TelefonNo = @a6 where KullaniciId = '" + txtKullaniciId.Text + "'"; // Ürün güncelleme kodu
                SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu
                komut2.Parameters.AddWithValue("@a1", txtAdSoyad.Text); // Value değerleri atanıyor
                komut2.Parameters.AddWithValue("@a2", txtMail.Text);// Value değerleri atanıyor
                komut2.Parameters.AddWithValue("@a3", txtSifre.Text);// Value değerleri atanıyor
                komut2.Parameters.AddWithValue("@a4", comboBox1.Text);// Value değerleri atanıyor
                komut2.Parameters.AddWithValue("@a5", txtKurumAdi.Text);// Value değerleri atanıyor
                komut2.Parameters.AddWithValue("@a6", txtTelefon.Text); // Value değerleri atanıyor
                komut2.ExecuteNonQuery();

                MessageBox.Show(txtAdSoyad.Text + " Kullanıcısı Başarıyla Güncellendi.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglanti.Close();
                Listele();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliUrun = dataGridView1.SelectedCells[0].RowIndex;
            string durum = "";

            txtAdSoyad.Text = dataGridView1.Rows[seciliUrun].Cells["AdSoyad"].Value.ToString();
            txtMail.Text = dataGridView1.Rows[seciliUrun].Cells["Email"].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[seciliUrun].Cells["Sifre"].Value.ToString();
            txtKurumAdi.Text = dataGridView1.Rows[seciliUrun].Cells["KurumAdi"].Value.ToString();
            txtTelefon.Text = dataGridView1.Rows[seciliUrun].Cells["TelefonNo"].Value.ToString();
            txtKullaniciId.Text = dataGridView1.Rows[seciliUrun].Cells["KullaniciId"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[seciliUrun].Cells["KullaniciTuru"].Value.ToString();
            durum = dataGridView1.Rows[seciliUrun].Cells["OnayDurumu"].Value.ToString();
            
            if(durum == "Onaysız Hesap       ")
            {
                button3.Visible = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string kod2 = "Update Tbl_Kullanicilar Set OnayDurumu = 'Onaylı Hesap' where Email = '" + txtMail.Text + "' "; // Ürün güncelleme kodu
            SqlCommand komut2 = new SqlCommand(kod2, baglanti); // komut oluşturuldu

            komut2.ExecuteNonQuery();

            MessageBox.Show(txtAdSoyad.Text + " Kullanıcısının Hesabı Onaylandı", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);

            baglanti.Close();
            button3.Visible = false;
            Listele();
        }
    }
}
