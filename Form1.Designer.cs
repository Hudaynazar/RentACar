using System.Windows.Forms;

namespace repo1
{
    partial class customerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerForm));
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.btnStatusForm = new System.Windows.Forms.Button();
            this.btnRentForm = new System.Windows.Forms.Button();
            this.btnCustomerForm = new System.Windows.Forms.Button();
            this.btnVehicleForm = new System.Windows.Forms.Button();
            this.textBoxLicence = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridCustomer = new System.Windows.Forms.DataGridView();
            this.textSearchMail = new System.Windows.Forms.TextBox();
            this.textSearchName = new System.Windows.Forms.TextBox();
            this.textSearchTc = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxCustomerJob = new System.Windows.Forms.TextBox();
            this.pictureBoxCustomer = new System.Windows.Forms.PictureBox();
            this.textBoxCustomerLastName = new System.Windows.Forms.TextBox();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.btnCustomerPic = new System.Windows.Forms.Button();
            this.textBoxTc = new System.Windows.Forms.TextBox();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.textBoxNots = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelMenuBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomer)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuBar
            // 
            this.panelMenuBar.BackColor = System.Drawing.Color.Silver;
            this.panelMenuBar.Controls.Add(this.btnStatusForm);
            this.panelMenuBar.Controls.Add(this.btnRentForm);
            this.panelMenuBar.Controls.Add(this.btnCustomerForm);
            this.panelMenuBar.Controls.Add(this.btnVehicleForm);
            this.panelMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelMenuBar.Name = "panelMenuBar";
            this.panelMenuBar.Size = new System.Drawing.Size(984, 50);
            this.panelMenuBar.TabIndex = 0;
            // 
            // btnStatusForm
            // 
            this.btnStatusForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusForm.Image = ((System.Drawing.Image)(resources.GetObject("btnStatusForm.Image")));
            this.btnStatusForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatusForm.Location = new System.Drawing.Point(480, 3);
            this.btnStatusForm.Name = "btnStatusForm";
            this.btnStatusForm.Size = new System.Drawing.Size(150, 44);
            this.btnStatusForm.TabIndex = 4;
            this.btnStatusForm.Text = "Araç Durumu";
            this.btnStatusForm.UseVisualStyleBackColor = true;
            this.btnStatusForm.Click += new System.EventHandler(this.btnStatusForm_Click);
            // 
            // btnRentForm
            // 
            this.btnRentForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRentForm.Image = ((System.Drawing.Image)(resources.GetObject("btnRentForm.Image")));
            this.btnRentForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentForm.Location = new System.Drawing.Point(324, 3);
            this.btnRentForm.Name = "btnRentForm";
            this.btnRentForm.Size = new System.Drawing.Size(150, 44);
            this.btnRentForm.TabIndex = 3;
            this.btnRentForm.Text = "Kiralama İşlemleri";
            this.btnRentForm.UseVisualStyleBackColor = true;
            this.btnRentForm.Click += new System.EventHandler(this.btnRentForm_Click);
            // 
            // btnCustomerForm
            // 
            this.btnCustomerForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerForm.Image")));
            this.btnCustomerForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerForm.Location = new System.Drawing.Point(12, 3);
            this.btnCustomerForm.Name = "btnCustomerForm";
            this.btnCustomerForm.Size = new System.Drawing.Size(150, 44);
            this.btnCustomerForm.TabIndex = 1;
            this.btnCustomerForm.Text = "Müşteri İşlemleri";
            this.btnCustomerForm.UseVisualStyleBackColor = true;
            // 
            // btnVehicleForm
            // 
            this.btnVehicleForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehicleForm.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleForm.Image")));
            this.btnVehicleForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleForm.Location = new System.Drawing.Point(168, 3);
            this.btnVehicleForm.Name = "btnVehicleForm";
            this.btnVehicleForm.Size = new System.Drawing.Size(150, 44);
            this.btnVehicleForm.TabIndex = 2;
            this.btnVehicleForm.Text = "Araç İşlemleri";
            this.btnVehicleForm.UseVisualStyleBackColor = true;
            this.btnVehicleForm.Click += new System.EventHandler(this.btnVehicleForm_Click);
            // 
            // textBoxLicence
            // 
            this.textBoxLicence.Location = new System.Drawing.Point(152, 182);
            this.textBoxLicence.Name = "textBoxLicence";
            this.textBoxLicence.Size = new System.Drawing.Size(247, 22);
            this.textBoxLicence.TabIndex = 14;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(152, 55);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(247, 22);
            this.textBoxMail.TabIndex = 12;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(152, 20);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(247, 22);
            this.textBoxPhone.TabIndex = 11;
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAdress.Location = new System.Drawing.Point(152, 98);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(247, 74);
            this.textBoxAdress.TabIndex = 13;
            this.textBoxAdress.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(84, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ehliyet:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Adres:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cep Telefonu:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPDF);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnEditCustomer);
            this.groupBox1.Controls.Add(this.btnDeleteCustomer);
            this.groupBox1.Controls.Add(this.btnAddCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlem Menüsü";
            // 
            // btnPDF
            // 
            this.btnPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(338, 21);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Padding = new System.Windows.Forms.Padding(15, 0, 8, 0);
            this.btnPDF.Size = new System.Drawing.Size(124, 44);
            this.btnPDF.TabIndex = 23;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(182, 21);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(15, 0, 8, 0);
            this.btnExcel.Size = new System.Drawing.Size(124, 44);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(494, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(15, 0, 8, 0);
            this.btnClear.Size = new System.Drawing.Size(124, 44);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCustomer.Image")));
            this.btnEditCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCustomer.Location = new System.Drawing.Point(649, 21);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Padding = new System.Windows.Forms.Padding(12, 0, 7, 0);
            this.btnEditCustomer.Size = new System.Drawing.Size(124, 44);
            this.btnEditCustomer.TabIndex = 19;
            this.btnEditCustomer.Text = "Düzenle";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click_1);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCustomer.Image")));
            this.btnDeleteCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(796, 21);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.btnDeleteCustomer.Size = new System.Drawing.Size(132, 44);
            this.btnDeleteCustomer.TabIndex = 20;
            this.btnDeleteCustomer.Text = "Sil";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click_1);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCustomer.Image")));
            this.btnAddCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCustomer.Location = new System.Drawing.Point(12, 21);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.btnAddCustomer.Size = new System.Drawing.Size(124, 44);
            this.btnAddCustomer.TabIndex = 18;
            this.btnAddCustomer.Text = "Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dataGridCustomer);
            this.groupBox2.Controls.Add(this.textSearchMail);
            this.groupBox2.Controls.Add(this.textSearchName);
            this.groupBox2.Controls.Add(this.textSearchTc);
            this.groupBox2.Location = new System.Drawing.Point(12, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 268);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Müşteri Listesi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(695, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Email Ara:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(364, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "İsim Ara:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "T.C. No ara:";
            // 
            // dataGridCustomer
            // 
            this.dataGridCustomer.AllowUserToAddRows = false;
            this.dataGridCustomer.AllowUserToDeleteRows = false;
            this.dataGridCustomer.AllowUserToResizeColumns = false;
            this.dataGridCustomer.AllowUserToResizeRows = false;
            this.dataGridCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomer.Location = new System.Drawing.Point(12, 66);
            this.dataGridCustomer.MultiSelect = false;
            this.dataGridCustomer.Name = "dataGridCustomer";
            this.dataGridCustomer.ReadOnly = true;
            this.dataGridCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCustomer.Size = new System.Drawing.Size(916, 193);
            this.dataGridCustomer.TabIndex = 2;
            this.dataGridCustomer.SelectionChanged += new System.EventHandler(this.dataGridCustomer_SelectionChanged);
            // 
            // textSearchMail
            // 
            this.textSearchMail.Location = new System.Drawing.Point(761, 38);
            this.textSearchMail.Name = "textSearchMail";
            this.textSearchMail.Size = new System.Drawing.Size(167, 22);
            this.textSearchMail.TabIndex = 23;
            this.textSearchMail.TextChanged += new System.EventHandler(this.textSearchMail_TextChanged);
            // 
            // textSearchName
            // 
            this.textSearchName.Location = new System.Drawing.Point(424, 38);
            this.textSearchName.Name = "textSearchName";
            this.textSearchName.Size = new System.Drawing.Size(167, 22);
            this.textSearchName.TabIndex = 22;
            this.textSearchName.TextChanged += new System.EventHandler(this.textSearchName_TextChanged);
            // 
            // textSearchTc
            // 
            this.textSearchTc.Location = new System.Drawing.Point(84, 38);
            this.textSearchTc.Name = "textSearchTc";
            this.textSearchTc.Size = new System.Drawing.Size(167, 22);
            this.textSearchTc.TabIndex = 21;
            this.textSearchTc.TextChanged += new System.EventHandler(this.textSearchTc_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxCustomerJob);
            this.groupBox4.Controls.Add(this.pictureBoxCustomer);
            this.groupBox4.Controls.Add(this.textBoxCustomerLastName);
            this.groupBox4.Controls.Add(this.textBoxCustomerName);
            this.groupBox4.Controls.Add(this.btnCustomerPic);
            this.groupBox4.Controls.Add(this.textBoxTc);
            this.groupBox4.Controls.Add(this.dateTimeBirth);
            this.groupBox4.Controls.Add(this.textBoxNots);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 241);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kişisel Bilgiler";
            // 
            // textBoxCustomerJob
            // 
            this.textBoxCustomerJob.Location = new System.Drawing.Point(240, 139);
            this.textBoxCustomerJob.Name = "textBoxCustomerJob";
            this.textBoxCustomerJob.Size = new System.Drawing.Size(222, 22);
            this.textBoxCustomerJob.TabIndex = 9;
            // 
            // pictureBoxCustomer
            // 
            this.pictureBoxCustomer.ErrorImage = null;
            this.pictureBoxCustomer.Location = new System.Drawing.Point(12, 31);
            this.pictureBoxCustomer.Name = "pictureBoxCustomer";
            this.pictureBoxCustomer.Size = new System.Drawing.Size(100, 120);
            this.pictureBoxCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCustomer.TabIndex = 0;
            this.pictureBoxCustomer.TabStop = false;
            // 
            // textBoxCustomerLastName
            // 
            this.textBoxCustomerLastName.Location = new System.Drawing.Point(240, 80);
            this.textBoxCustomerLastName.Name = "textBoxCustomerLastName";
            this.textBoxCustomerLastName.Size = new System.Drawing.Size(222, 22);
            this.textBoxCustomerLastName.TabIndex = 7;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(240, 52);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(222, 22);
            this.textBoxCustomerName.TabIndex = 6;
            // 
            // btnCustomerPic
            // 
            this.btnCustomerPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerPic.Location = new System.Drawing.Point(24, 172);
            this.btnCustomerPic.Name = "btnCustomerPic";
            this.btnCustomerPic.Size = new System.Drawing.Size(73, 32);
            this.btnCustomerPic.TabIndex = 16;
            this.btnCustomerPic.Text = "Resim Seç";
            this.btnCustomerPic.UseVisualStyleBackColor = true;
            this.btnCustomerPic.Click += new System.EventHandler(this.btnCustomerPic_Click);
            // 
            // textBoxTc
            // 
            this.textBoxTc.Location = new System.Drawing.Point(240, 24);
            this.textBoxTc.Name = "textBoxTc";
            this.textBoxTc.Size = new System.Drawing.Size(222, 22);
            this.textBoxTc.TabIndex = 5;
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.Location = new System.Drawing.Point(240, 109);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(221, 22);
            this.dateTimeBirth.TabIndex = 8;
            // 
            // textBoxNots
            // 
            this.textBoxNots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNots.Location = new System.Drawing.Point(240, 174);
            this.textBoxNots.Name = "textBoxNots";
            this.textBoxNots.Size = new System.Drawing.Size(222, 52);
            this.textBoxNots.TabIndex = 10;
            this.textBoxNots.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(169, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Notlar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "T.C. No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "İsim:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Meslek:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Soyisim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Doğum tarihi:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxPhone);
            this.groupBox3.Controls.Add(this.textBoxLicence);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxMail);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxAdress);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(541, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 241);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İletişim / Ehliyet";
            // 
            // customerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelMenuBar);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "customerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Kiralama Otomasyonu ";
            this.Load += new System.EventHandler(this.customerForm_Load);
            this.panelMenuBar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCustomer)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuBar;
        private System.Windows.Forms.Button btnRentForm;
        private System.Windows.Forms.Button btnVehicleForm;
        private System.Windows.Forms.Button btnCustomerForm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLicence;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.RichTextBox textBoxAdress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Button btnEditCustomer;
        private Button btnDeleteCustomer;
        private Button btnAddCustomer;
        private GroupBox groupBox2;
        private DataGridView dataGridCustomer;
        private GroupBox groupBox4;
        private PictureBox pictureBoxCustomer;
        private TextBox textBoxCustomerJob;
        private TextBox textBoxCustomerLastName;
        private TextBox textBoxCustomerName;
        private TextBox textBoxTc;
        private DateTimePicker dateTimeBirth;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCustomerPic;
        private Label label7;
        private TextBox textSearchTc;
        private GroupBox groupBox3;
        private Label label13;
        private Label label12;
        private RichTextBox textBoxNots;
        private Label label14;
        private TextBox textSearchMail;
        private TextBox textSearchName;
        private Button btnStatusForm;
        private BindingSource bindingSource1;
        private Button btnClear;
        private Button btnPDF;
        private Button btnExcel;
    }
}

