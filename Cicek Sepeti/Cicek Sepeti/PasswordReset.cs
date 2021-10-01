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
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Cicek_Sepeti
{
    public partial class PasswordReset : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I3RRSTI;Initial Catalog=CicekSepeti;Integrated Security=True");
        public PasswordReset()
        {
            InitializeComponent();
        }
        int sayi1, sayi2;


        

        public bool MailGonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("ahmethasan4747@gmail.com");
            ePosta.To.Add(txtMail.Text); //göndereceğimiz mail adresi

            ePosta.Subject = konu; //mail konusu
            ePosta.Body = icerik; //mail içeriği 

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            
            client.Credentials = new System.Net.NetworkCredential("ahmethasan4747@gmail.com", "Gosfas0068.");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Send(ePosta);
            object userState = true;
            bool kontrol = true;
            try
            {
                client.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                MessageBox.Show(ex.Message);
            }
            return kontrol;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCevap.Text == Convert.ToString(sayi1 + sayi2))
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Tbl_Kullanicilar where Email='" + txtMail.Text + "'");
                komut.Connection = baglanti;
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    Random rnd = new Random();
                    int sayi = rnd.Next(100000,999999);
                    MailGonder("Şifre Sıfırlama", "Şifre Sıfırlama Kodunuz : " + sayi );
                    MessageBox.Show("Mail Adresinize Bir Kod Gönderilmiştir Lütfen O Kodu Giriniz.");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("İşlem Sonucu Yanlış Lütfen Tekrar Giriniz !", "Çiçek Sepeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PasswordReset_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            sayi1 = rnd.Next(50);
            sayi2 = rnd.Next(50);

            label1.Text = Convert.ToString(sayi1);
            label3.Text = Convert.ToString(sayi2);
        }
    }
}
