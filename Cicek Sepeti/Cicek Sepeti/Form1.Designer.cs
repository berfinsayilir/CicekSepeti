
namespace Cicek_Sepeti
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTur = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblInsert = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAdet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.uyelikTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sepetSayi = new System.Windows.Forms.Timer(this.components);
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcbUsers = new System.Windows.Forms.PictureBox();
            this.pcbGiris = new System.Windows.Forms.PictureBox();
            this.pcbDelete = new System.Windows.Forms.PictureBox();
            this.pcbUpdate = new System.Windows.Forms.PictureBox();
            this.pcbInsert = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.signUpPicture = new System.Windows.Forms.PictureBox();
            this.loginPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGiris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signUpPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(163)))));
            this.panel1.Controls.Add(this.lblUsers);
            this.panel1.Controls.Add(this.pcbUsers);
            this.panel1.Controls.Add(this.lblMail);
            this.panel1.Controls.Add(this.lblTur);
            this.panel1.Controls.Add(this.pcbGiris);
            this.panel1.Controls.Add(this.lblDelete);
            this.panel1.Controls.Add(this.pcbDelete);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.pcbUpdate);
            this.panel1.Controls.Add(this.lblInsert);
            this.panel1.Controls.Add(this.pcbInsert);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.signUpPicture);
            this.panel1.Controls.Add(this.loginPicture);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Location = new System.Drawing.Point(-10, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 85);
            this.panel1.TabIndex = 0;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(417, 52);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(83, 17);
            this.lblUsers.TabIndex = 27;
            this.lblUsers.Text = "Kullanıcılar";
            this.lblUsers.Visible = false;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMail.ForeColor = System.Drawing.Color.White;
            this.lblMail.Location = new System.Drawing.Point(955, 30);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(38, 17);
            this.lblMail.TabIndex = 24;
            this.lblMail.Text = "Mail";
            this.lblMail.Visible = false;
            // 
            // lblTur
            // 
            this.lblTur.AutoSize = true;
            this.lblTur.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTur.ForeColor = System.Drawing.Color.White;
            this.lblTur.Location = new System.Drawing.Point(955, 7);
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(32, 17);
            this.lblTur.TabIndex = 25;
            this.lblTur.Text = "Tür";
            this.lblTur.Visible = false;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDelete.ForeColor = System.Drawing.Color.White;
            this.lblDelete.Location = new System.Drawing.Point(352, 52);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(61, 17);
            this.lblDelete.TabIndex = 22;
            this.lblDelete.Text = "Ürün Sil";
            this.lblDelete.Visible = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUpdate.ForeColor = System.Drawing.Color.White;
            this.lblUpdate.Location = new System.Drawing.Point(251, 52);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(103, 17);
            this.lblUpdate.TabIndex = 20;
            this.lblUpdate.Text = "Ürün Güncelle";
            this.lblUpdate.Visible = false;
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInsert.ForeColor = System.Drawing.Color.White;
            this.lblInsert.Location = new System.Drawing.Point(175, 52);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(76, 17);
            this.lblInsert.TabIndex = 18;
            this.lblInsert.Text = "Ürün Ekle";
            this.lblInsert.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(107, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ürünler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sepete Ekle";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblAdet);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtAra);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 76);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblAdet.Location = new System.Drawing.Point(1037, -1);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(16, 17);
            this.lblAdet.TabIndex = 23;
            this.lblAdet.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(997, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sepetim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(933, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Üyelik";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(835, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sipariş Takibi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(181)))), ((int)(((byte)(73)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(521, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "ARA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtAra
            // 
            this.txtAra.BackColor = System.Drawing.SystemColors.Window;
            this.txtAra.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(224, 19);
            this.txtAra.Multiline = true;
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(297, 38);
            this.txtAra.TabIndex = 1;
            this.txtAra.Text = "Aramak İstediğiniz Ürünü Giriniz...";
            this.txtAra.Click += new System.EventHandler(this.textBox1_Click);
            this.txtAra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(163)))));
            this.loginLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginLabel.ForeColor = System.Drawing.Color.White;
            this.loginLabel.Location = new System.Drawing.Point(937, 132);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(66, 17);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Giriş Yap";
            this.loginLabel.Visible = false;
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(90)))), ((int)(((byte)(163)))));
            this.signUpLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.signUpLabel.ForeColor = System.Drawing.Color.White;
            this.signUpLabel.Location = new System.Drawing.Point(1023, 131);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(54, 17);
            this.signUpLabel.TabIndex = 9;
            this.signUpLabel.Text = "Üye Ol";
            this.signUpLabel.Visible = false;
            // 
            // uyelikTimer
            // 
            this.uyelikTimer.Interval = 2000;
            this.uyelikTimer.Tick += new System.EventHandler(this.uyelikTimer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1114, 588);
            this.dataGridView1.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sepetSayi
            // 
            this.sepetSayi.Tick += new System.EventHandler(this.sepetSayi_Tick);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::Cicek_Sepeti.Properties.Resources.icons8_macos_minimize_32;
            this.pictureBox6.Location = new System.Drawing.Point(1075, 39);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(39, 37);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::Cicek_Sepeti.Properties.Resources.icons8_macos_close_32;
            this.pictureBox5.Location = new System.Drawing.Point(1075, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Cicek_Sepeti.Properties.Resources.icon1;
            this.pictureBox4.Location = new System.Drawing.Point(999, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Cicek_Sepeti.Properties.Resources.icons8_customer_48;
            this.pictureBox3.Location = new System.Drawing.Point(932, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Cicek_Sepeti.Properties.Resources.icons8_tracking_50;
            this.pictureBox2.Location = new System.Drawing.Point(853, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 50);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cicek_Sepeti.Properties.Resources.logo_new_ciceksepeti;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pcbUsers
            // 
            this.pcbUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbUsers.Image = global::Cicek_Sepeti.Properties.Resources.icons8_customer_48;
            this.pcbUsers.Location = new System.Drawing.Point(428, 2);
            this.pcbUsers.Name = "pcbUsers";
            this.pcbUsers.Size = new System.Drawing.Size(51, 50);
            this.pcbUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbUsers.TabIndex = 26;
            this.pcbUsers.TabStop = false;
            this.pcbUsers.Visible = false;
            this.pcbUsers.Click += new System.EventHandler(this.pcbUsers_Click);
            // 
            // pcbGiris
            // 
            this.pcbGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbGiris.Image = global::Cicek_Sepeti.Properties.Resources.icons8_customer_48;
            this.pcbGiris.Location = new System.Drawing.Point(898, 1);
            this.pcbGiris.Name = "pcbGiris";
            this.pcbGiris.Size = new System.Drawing.Size(51, 50);
            this.pcbGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbGiris.TabIndex = 23;
            this.pcbGiris.TabStop = false;
            this.pcbGiris.Visible = false;
            // 
            // pcbDelete
            // 
            this.pcbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbDelete.Image = global::Cicek_Sepeti.Properties.Resources.icons8_delete_bin_100;
            this.pcbDelete.Location = new System.Drawing.Point(354, 1);
            this.pcbDelete.Name = "pcbDelete";
            this.pcbDelete.Size = new System.Drawing.Size(51, 50);
            this.pcbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDelete.TabIndex = 21;
            this.pcbDelete.TabStop = false;
            this.pcbDelete.Visible = false;
            this.pcbDelete.Click += new System.EventHandler(this.pcbDelete_Click);
            // 
            // pcbUpdate
            // 
            this.pcbUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbUpdate.Image = global::Cicek_Sepeti.Properties.Resources.icons8_available_updates_100;
            this.pcbUpdate.Location = new System.Drawing.Point(266, 1);
            this.pcbUpdate.Name = "pcbUpdate";
            this.pcbUpdate.Size = new System.Drawing.Size(51, 50);
            this.pcbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbUpdate.TabIndex = 19;
            this.pcbUpdate.TabStop = false;
            this.pcbUpdate.Visible = false;
            this.pcbUpdate.Click += new System.EventHandler(this.pcbUpdate_Click);
            // 
            // pcbInsert
            // 
            this.pcbInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbInsert.Image = global::Cicek_Sepeti.Properties.Resources.icons8_shopping_basket_add_100;
            this.pcbInsert.Location = new System.Drawing.Point(181, 1);
            this.pcbInsert.Name = "pcbInsert";
            this.pcbInsert.Size = new System.Drawing.Size(51, 50);
            this.pcbInsert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbInsert.TabIndex = 17;
            this.pcbInsert.TabStop = false;
            this.pcbInsert.Visible = false;
            this.pcbInsert.Click += new System.EventHandler(this.pcbInsert_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::Cicek_Sepeti.Properties.Resources.icons8_used_product_100;
            this.pictureBox7.Location = new System.Drawing.Point(107, 1);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(51, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click_1);
            // 
            // signUpPicture
            // 
            this.signUpPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUpPicture.Image = global::Cicek_Sepeti.Properties.Resources.icons8_add_user_male_48__1_;
            this.signUpPicture.Location = new System.Drawing.Point(1028, 1);
            this.signUpPicture.Name = "signUpPicture";
            this.signUpPicture.Size = new System.Drawing.Size(51, 50);
            this.signUpPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.signUpPicture.TabIndex = 10;
            this.signUpPicture.TabStop = false;
            this.signUpPicture.Visible = false;
            this.signUpPicture.Click += new System.EventHandler(this.signUpPicture_Click);
            // 
            // loginPicture
            // 
            this.loginPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginPicture.Image = global::Cicek_Sepeti.Properties.Resources.icons8_checked_user_male_48;
            this.loginPicture.Location = new System.Drawing.Point(949, 1);
            this.loginPicture.Name = "loginPicture";
            this.loginPicture.Size = new System.Drawing.Size(51, 50);
            this.loginPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loginPicture.TabIndex = 8;
            this.loginPicture.TabStop = false;
            this.loginPicture.Visible = false;
            this.loginPicture.Click += new System.EventHandler(this.loginPicture_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::Cicek_Sepeti.Properties.Resources.icons8_buy_50;
            this.pictureBox8.Location = new System.Drawing.Point(25, 1);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(51, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox8.TabIndex = 14;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1114, 751);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Çicek Sepeti";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signUpPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox loginPicture;
        private System.Windows.Forms.PictureBox signUpPicture;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label signUpLabel;
        private System.Windows.Forms.Timer uyelikTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.PictureBox pcbDelete;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.PictureBox pcbUpdate;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.PictureBox pcbInsert;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblTur;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.PictureBox pcbGiris;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.PictureBox pcbUsers;
        private System.Windows.Forms.Timer sepetSayi;
    }
}

