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
    public partial class SiparisTakibi : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True"); //Veri Tabanı bağlantısı

        public SiparisTakibi()
        {
            InitializeComponent();
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSiparisNo.Text == "" || txtSiparisNo.Text == "Sipariş Numaranız")
            {
                MessageBox.Show("Lütfen Sipariş Numarasını Giriniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();
                string aramaKodu = "Select *From Tbl_SiparisTakibi where SiparisNumarasi = " + txtSiparisNo.Text + " "; // ürün arama
                SqlCommand comand = new SqlCommand(aramaKodu, baglanti);
                SqlDataReader oku = comand.ExecuteReader();
                string siparisNo = "";
                string gonderenKisi = "";
                string aliciKisi = "";
                string adres = "";
                bool kontrol = false;
                while (oku.Read())
                {
                    kontrol = true;
                    siparisNo = oku[0].ToString(); // İd'yi Stringe dönüştürme
                    aliciKisi = oku[1].ToString(); // İd'yi Stringe dönüştürme
                    gonderenKisi = oku[2].ToString(); // İd'yi Stringe dönüştürme
                    adres = oku[3].ToString(); // İd'yi Stringe dönüştürme
                    break;
                }

                baglanti.Close();

                if (kontrol)
                {
                    MessageBox.Show("Ürününüze Ait Sipariş Bilgileri : \n" +
                  "Sipariş Numarası : " + siparisNo +
                  "\nGönderen Kişi : " + gonderenKisi +
                  "\nAlıcı Kişi : " + aliciKisi +
                  "\nMevcut Konumu : " + adres, "Kargo Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(siparisNo + " Numarasına Sahip Sipariş Bulunumadı.", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
