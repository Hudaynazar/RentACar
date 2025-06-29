namespace repo1
{
    partial class vehicleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vehicleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textSearchBrand = new System.Windows.Forms.TextBox();
            this.textSearchPlaka = new System.Windows.Forms.TextBox();
            this.dataGridAllVehicle = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteVehicle = new System.Windows.Forms.Button();
            this.btnEditVehicle = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.btnStatusForm = new System.Windows.Forms.Button();
            this.btnRentForm = new System.Windows.Forms.Button();
            this.btnCustomerForm = new System.Windows.Forms.Button();
            this.btnVehicleForm = new System.Windows.Forms.Button();
            this.btnVehicleExcel = new System.Windows.Forms.Button();
            this.btnVehiclePDF = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAllVehicle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textSearchBrand);
            this.groupBox1.Controls.Add(this.textSearchPlaka);
            this.groupBox1.Controls.Add(this.dataGridAllVehicle);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 516);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tüm Araçlar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(474, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Markaya Göre Ara:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Plakaya Göre ara:";
            // 
            // textSearchBrand
            // 
            this.textSearchBrand.Location = new System.Drawing.Point(576, 27);
            this.textSearchBrand.Name = "textSearchBrand";
            this.textSearchBrand.Size = new System.Drawing.Size(300, 20);
            this.textSearchBrand.TabIndex = 26;
            this.textSearchBrand.TextChanged += new System.EventHandler(this.textSearchBrand_TextChanged);
            // 
            // textSearchPlaka
            // 
            this.textSearchPlaka.Location = new System.Drawing.Point(104, 27);
            this.textSearchPlaka.Name = "textSearchPlaka";
            this.textSearchPlaka.Size = new System.Drawing.Size(300, 20);
            this.textSearchPlaka.TabIndex = 25;
            this.textSearchPlaka.TextChanged += new System.EventHandler(this.textSearchPlaka_TextChanged);
            // 
            // dataGridAllVehicle
            // 
            this.dataGridAllVehicle.AllowUserToAddRows = false;
            this.dataGridAllVehicle.AllowUserToDeleteRows = false;
            this.dataGridAllVehicle.AllowUserToResizeColumns = false;
            this.dataGridAllVehicle.AllowUserToResizeRows = false;
            this.dataGridAllVehicle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAllVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAllVehicle.Location = new System.Drawing.Point(9, 61);
            this.dataGridAllVehicle.MultiSelect = false;
            this.dataGridAllVehicle.Name = "dataGridAllVehicle";
            this.dataGridAllVehicle.ReadOnly = true;
            this.dataGridAllVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAllVehicle.Size = new System.Drawing.Size(945, 449);
            this.dataGridAllVehicle.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVehiclePDF);
            this.groupBox2.Controls.Add(this.btnVehicleExcel);
            this.groupBox2.Controls.Add(this.btnDeleteVehicle);
            this.groupBox2.Controls.Add(this.btnEditVehicle);
            this.groupBox2.Controls.Add(this.btnAddVehicle);
            this.groupBox2.Location = new System.Drawing.Point(12, 578);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 80);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlem Menüsü";
            // 
            // btnDeleteVehicle
            // 
            this.btnDeleteVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteVehicle.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteVehicle.Image")));
            this.btnDeleteVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteVehicle.Location = new System.Drawing.Point(813, 18);
            this.btnDeleteVehicle.Name = "btnDeleteVehicle";
            this.btnDeleteVehicle.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.btnDeleteVehicle.Size = new System.Drawing.Size(141, 53);
            this.btnDeleteVehicle.TabIndex = 9;
            this.btnDeleteVehicle.Text = "Sil";
            this.btnDeleteVehicle.UseVisualStyleBackColor = true;
            this.btnDeleteVehicle.Click += new System.EventHandler(this.btnDeleteVehicle_Click);
            // 
            // btnEditVehicle
            // 
            this.btnEditVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditVehicle.Image = ((System.Drawing.Image)(resources.GetObject("btnEditVehicle.Image")));
            this.btnEditVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditVehicle.Location = new System.Drawing.Point(666, 18);
            this.btnEditVehicle.Name = "btnEditVehicle";
            this.btnEditVehicle.Padding = new System.Windows.Forms.Padding(12, 0, 7, 0);
            this.btnEditVehicle.Size = new System.Drawing.Size(141, 53);
            this.btnEditVehicle.TabIndex = 8;
            this.btnEditVehicle.Text = "Düzenle";
            this.btnEditVehicle.UseVisualStyleBackColor = true;
            this.btnEditVehicle.Click += new System.EventHandler(this.btnEditVehicle_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVehicle.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVehicle.Image")));
            this.btnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVehicle.Location = new System.Drawing.Point(9, 19);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Padding = new System.Windows.Forms.Padding(12, 0, 5, 0);
            this.btnAddVehicle.Size = new System.Drawing.Size(141, 53);
            this.btnAddVehicle.TabIndex = 7;
            this.btnAddVehicle.Text = "Araç Ekle";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
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
            this.panelMenuBar.TabIndex = 11;
            // 
            // btnStatusForm
            // 
            this.btnStatusForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusForm.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.btnStatusForm.Image = ((System.Drawing.Image)(resources.GetObject("btnStatusForm.Image")));
            this.btnStatusForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatusForm.Location = new System.Drawing.Point(480, 3);
            this.btnStatusForm.Name = "btnStatusForm";
            this.btnStatusForm.Size = new System.Drawing.Size(150, 44);
            this.btnStatusForm.TabIndex = 3;
            this.btnStatusForm.Text = "Araç Durumu";
            this.btnStatusForm.UseVisualStyleBackColor = true;
            this.btnStatusForm.Click += new System.EventHandler(this.btnStatusForm_Click);
            // 
            // btnRentForm
            // 
            this.btnRentForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRentForm.Font = new System.Drawing.Font("Times New Roman", 9.75F);
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
            this.btnCustomerForm.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.btnCustomerForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerForm.Image")));
            this.btnCustomerForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerForm.Location = new System.Drawing.Point(12, 3);
            this.btnCustomerForm.Name = "btnCustomerForm";
            this.btnCustomerForm.Size = new System.Drawing.Size(150, 44);
            this.btnCustomerForm.TabIndex = 1;
            this.btnCustomerForm.Text = "Müşteri İşlemleri";
            this.btnCustomerForm.UseVisualStyleBackColor = true;
            this.btnCustomerForm.Click += new System.EventHandler(this.btnCustomerForm_Click);
            // 
            // btnVehicleForm
            // 
            this.btnVehicleForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehicleForm.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.btnVehicleForm.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleForm.Image")));
            this.btnVehicleForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleForm.Location = new System.Drawing.Point(168, 3);
            this.btnVehicleForm.Name = "btnVehicleForm";
            this.btnVehicleForm.Size = new System.Drawing.Size(150, 44);
            this.btnVehicleForm.TabIndex = 2;
            this.btnVehicleForm.Text = "Araç İşlemleri";
            this.btnVehicleForm.UseVisualStyleBackColor = true;
            // 
            // btnVehicleExcel
            // 
            this.btnVehicleExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehicleExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleExcel.Image")));
            this.btnVehicleExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleExcel.Location = new System.Drawing.Point(321, 19);
            this.btnVehicleExcel.Name = "btnVehicleExcel";
            this.btnVehicleExcel.Padding = new System.Windows.Forms.Padding(15, 0, 8, 0);
            this.btnVehicleExcel.Size = new System.Drawing.Size(141, 53);
            this.btnVehicleExcel.TabIndex = 23;
            this.btnVehicleExcel.Text = "Excel";
            this.btnVehicleExcel.UseVisualStyleBackColor = true;
            this.btnVehicleExcel.Click += new System.EventHandler(this.btnVehicleExcel_Click);
            // 
            // btnVehiclePDF
            // 
            this.btnVehiclePDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehiclePDF.Image = ((System.Drawing.Image)(resources.GetObject("btnVehiclePDF.Image")));
            this.btnVehiclePDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehiclePDF.Location = new System.Drawing.Point(174, 19);
            this.btnVehiclePDF.Name = "btnVehiclePDF";
            this.btnVehiclePDF.Padding = new System.Windows.Forms.Padding(15, 0, 8, 0);
            this.btnVehiclePDF.Size = new System.Drawing.Size(141, 53);
            this.btnVehiclePDF.TabIndex = 24;
            this.btnVehiclePDF.Text = "PDF";
            this.btnVehiclePDF.UseVisualStyleBackColor = true;
            this.btnVehiclePDF.Click += new System.EventHandler(this.btnVehiclePDF_Click);
            // 
            // vehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelMenuBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "vehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Kiralama Otomasyonu ";
            this.Load += new System.EventHandler(this.vehicleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAllVehicle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelMenuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dataGridAllVehicle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteVehicle;
        private System.Windows.Forms.Button btnEditVehicle;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Panel panelMenuBar;
        private System.Windows.Forms.Button btnStatusForm;
        private System.Windows.Forms.Button btnRentForm;
        private System.Windows.Forms.Button btnCustomerForm;
        private System.Windows.Forms.Button btnVehicleForm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textSearchBrand;
        private System.Windows.Forms.TextBox textSearchPlaka;
        private System.Windows.Forms.Button btnVehicleExcel;
        private System.Windows.Forms.Button btnVehiclePDF;
    }
}