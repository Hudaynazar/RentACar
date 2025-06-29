using DocumentFormat.OpenXml.Spreadsheet;
using SixLabors.ImageSharp;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace repo1
{
    public partial class rentForm : Form
    {
        private const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb";
        private OleDbConnection con;

        public rentForm()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);

            //forma girildiginde data gridde secimi kaldir
            dataGridRent.ClearSelection();

        }

        //musteri islemleri butonu
        private void btnCustomerForm_Click(object sender, EventArgs e)
        {
            Form customerForm = new customerForm();
            customerForm.Show();
            this.Hide();
        }

        //tum araclar butonu
        private void btnVehicleForm_Click(object sender, EventArgs e)
        {
            Form vehicleForm = new vehicleForm();
            vehicleForm.Show();
            this.Hide();
        }

        //arac durumu butonu
        private void btnStatusForm_Click(object sender, EventArgs e)
        {
            Form statusForm = new statusForm();
            statusForm.Show();
            this.Hide();
        }

        //araclari datadan cekme metodu
        private void availableGet()
        {
            string query = "SELECT * FROM aracBilgi WHERE musait = 'evet'\r\nUNION ALL\r\nSELECT * FROM aracBilgi WHERE musait = 'hayir'";

            try
            {
                con.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter(query, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "aracBilgi");
                    dataGridRent.DataSource = ds.Tables["aracBilgi"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        //musait olmayan araclari kirmizi renge alma
        private void DataGridRent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Hücre geçerli bir hücre ise
            {
                DataGridView dataGridView = (DataGridView)sender;
                string musaitValue = dataGridView.Rows[e.RowIndex].Cells["musait"].Value.ToString();


                if (musaitValue == "hayir")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        //secilen arabayi text boxlara doldurma
        private void dataGridRent_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridRent.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRent.SelectedRows[0];
                textBoxRentPlaka.Text = selectedRow.Cells["plaka"].Value.ToString();
                textBoxRentBrand.Text = selectedRow.Cells["marka"].Value.ToString();
                textBoxRentModel.Text = selectedRow.Cells["model"].Value.ToString();
                textBoxRentYear.Text = selectedRow.Cells["yil"].Value.ToString();
            }
            if (dataGridRent.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRent.SelectedRows[0];
                string selectedPlaka = selectedRow.Cells["plaka"].Value.ToString();

                OleDbConnection conn = new OleDbConnection(ConnectionString);

                // Kira sözleşmesini getirme
                string contractQuery = "SELECT * FROM kiraSozlesme WHERE plaka = @plaka";
                OleDbDataAdapter daContract = new OleDbDataAdapter(contractQuery, conn);
                daContract.SelectCommand.Parameters.AddWithValue("@plaka", selectedPlaka);
                DataSet dsContract = new DataSet();

                //aracin dolu oldugu tarihleri gosterme
                try
                {
                    conn.Open();
                    daContract.Fill(dsContract);
                    if (dsContract.Tables.Count > 0 && dsContract.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsContract.Tables[0].Rows.Count; i++)
                        {
                            MessageBox.Show("Bu Aracın dolu olduğu tarihler: " + Convert.ToDateTime(dsContract.Tables[0].Rows[i]["alisTarih"]).ToString("dd.MM.yyyy") + " - " + Convert.ToDateTime(dsContract.Tables[0].Rows[i]["teslimTarih"]).ToString("dd.MM.yyyy"));
                        }
                        DateTime datevalue;
                        int lastRow = dsContract.Tables[0].Rows.Count;
                        if (DateTime.TryParse(dsContract.Tables[0].Rows[lastRow - 1]["teslimTarih"].ToString(), out datevalue))
                        {
                            dateTimePick.MinDate = datevalue;
                            dateTimeDrop.MinDate = datevalue;

                        }
                    }
                    else
                    {
                        dateTimeDrop.MinDate = DateTime.Today;
                        dateTimeDrop.Value = DateTime.Today;

                        dateTimePick.MinDate = DateTime.Today;
                        dateTimePick.Value = DateTime.Today;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Geçersiz tarih formatı: " + ex.Message);
                }
            }
        }
    
        //kirala butonu
        private void btnCall_Click(object sender, EventArgs e)
        {
            string tcNo = textBoxRentTc.Text.Trim();

            if (string.IsNullOrEmpty(tcNo))
            {
                MessageBox.Show("Lütfen TC No giriniz.");
                return;
            }

            //yazilan tc ye gore musteri bilgilerini textboxa cagirma
            string query = "SELECT * FROM musteriBilgi WHERE TcNo = @tcNo";
            try
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tcNo", tcNo);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, "musteriBilgi");

                        if (ds.Tables["musteriBilgi"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["musteriBilgi"].Rows[0];
                            textBoxRentName.Text = dr["isim"].ToString();
                            textBoxRentLastName.Text = dr["soyisim"].ToString();
                            textBoxRentPhone.Text = dr["cepTelefonu"].ToString();
                            textBoxNots.Text = dr["notlar"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Girilen TC No'ya ait müşteri bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            btnRent.Enabled = true;
        }

        //pdf cikarma butonu
        private void btnPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "PDF Dosyası Seçin",
                InitialDirectory = "C:\\",
                Filter = "PDF Dosyası (*.pdf)|*.pdf"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSozlesmePath.Text = openFileDialog1.FileName;
            }
        }

        //kirlama butonu
        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dataGridRent.SelectedRows.Count > 0)
            {

                string alisTarihi = dateTimePick.Value.ToString("yyyy-MM-dd");
                string teslimTarihi = dateTimeDrop.Value.ToString("yyyy-MM-dd");

                DateTime alisDate = DateTime.Parse(alisTarihi);
                DateTime teslimDate = DateTime.Parse(teslimTarihi);
                DataGridViewRow selectedRow = dataGridRent.SelectedRows[0];
                if (alisDate > teslimDate)
                {
                    MessageBox.Show("Alış tarihi teslim tarihinden önce olamaz!");
                    return;
                }

                if (textBoxAmount.Text.Length < 2)
                {
                    MessageBox.Show("Tutar Miktarı Girilmeden Kiralama İşlemi Gerçekleştirilemez!");
                    return;
                }

                if (string.IsNullOrEmpty(textBoxRentTc.Text))
                {
                    MessageBox.Show("TC Kimlik Numarası girilmelidir!");
                    return;
                }

                string plaka = selectedRow.Cells["plaka"].Value.ToString();
                string folderPath = @"C:\RentaCar\PDFs";
                
                string fileName = plaka + ".pdf";
                string currentDate = DateTime.Now.ToString("D");
                string sozlesmePDF = Path.Combine(folderPath, (currentDate + " " + fileName));
               string sourceFilePath =  textBoxSozlesmePath.Text;

                //sozlesmeyi kopyalama 
                if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                {
                   File.Copy(sourceFilePath, sozlesmePDF, true);
              }
                string musait = "hayir";
                try
                {
                    con.Open();
                    {
                        try
                        {
                            // Update aracBilgi table
                            using (OleDbCommand cmd = new OleDbCommand("UPDATE aracBilgi SET musait = @musait WHERE plaka = @plaka", con))
                            {
                                cmd.Parameters.AddWithValue("@musait", musait);
                                cmd.Parameters.AddWithValue("@plaka", plaka);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert into kiraSozlesme table
                            string alisTarih = dateTimePick.Value.ToString("yyyy-MM-dd");
                            string teslimTarih = dateTimeDrop.Value.ToString("yyyy-MM-dd");
                            string tutar = textBoxAmount.Text;
                            string kapora = textBoxDeposit.Text;
                            string sozlesme = textBoxSozlesmePath.Text;
                            string kiraTcNo = textBoxRentTc.Text;
                            string kiraPlaka = textBoxRentPlaka.Text.Trim();

                            using (OleDbCommand cmd = new OleDbCommand("INSERT INTO kiraSozlesme (alisTarih, teslimTarih, tutar, kapora, sozlesme, tcNo, plaka) VALUES (@alisTarih, @teslimTarih, @tutar, @kapora, @sozlesme, @tcNo, @plaka)", con))
                            {
                                cmd.Parameters.AddWithValue("@alisTarih", alisTarih);
                                cmd.Parameters.AddWithValue("@teslimTarih", teslimTarih);
                                cmd.Parameters.AddWithValue("@tutar", tutar);
                                cmd.Parameters.AddWithValue("@kapora", kapora);
                                cmd.Parameters.AddWithValue("@sozlesme", sozlesme);
                                cmd.Parameters.AddWithValue("@tcNo", kiraTcNo);
                                cmd.Parameters.AddWithValue("@plaka", kiraPlaka);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Yeni kira sözleşmesi başarıyla eklendi.");
                                }
                                else
                                {
                                    MessageBox.Show("Yeni kira sözleşmesi eklenirken bir hata oluştu.");
                                }
                            }

                            // Update musteriBilgi table
                            string notlar = textBoxNots.Text;
                            using (OleDbCommand cmd = new OleDbCommand("UPDATE musteriBilgi SET notlar = @notlar WHERE tcNo = @tcNo", con))
                            {
                                cmd.Parameters.AddWithValue("@notlar", notlar);
                                cmd.Parameters.AddWithValue("@tcNo", kiraTcNo);
                                cmd.ExecuteNonQuery();
                            }


                            MessageBox.Show("Araç başarıyla kiralandı!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bir hata oluştu: " + ex.Message);
                        }
                    }
                }
                finally
                {
                    con.Close();
                }

                availableGet();
            }
        }


        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // DataGridView'in varsayılan seçimini kaldırma
            dataGridRent.ClearSelection();
        }


        private void rentForm_Load(object sender, EventArgs e)
        {
            // DataGridView'in varsayılan seçimini kaldırma
            dataGridRent.DataBindingComplete += DataGridView1_DataBindingComplete;

            availableGet();
            CustomizeDataGridView();
        }

        //data grid sutunlarini duzenleme 
        private void CustomizeDataGridView()
        {
            // Customize DataGridView appearance
            dataGridRent.Columns["aracFoto"].Visible = false;
            dataGridRent.Columns["plaka"].HeaderText = "Plaka";
            dataGridRent.Columns["marka"].HeaderText = "Marka";
            dataGridRent.Columns["model"].HeaderText = "Model";
            dataGridRent.Columns["yil"].HeaderText = "Yıl";
            dataGridRent.Columns["yakit"].Visible = false;
            dataGridRent.Columns["vites"].Visible = false;
            dataGridRent.Columns["km"].Visible = false;
            dataGridRent.Columns["kapi"].Visible = false;
            dataGridRent.Columns["kasaTipi"].Visible = false;
            dataGridRent.Columns["renk"].Visible = false;
            dataGridRent.Columns["hasar"].Visible = false;
            dataGridRent.Columns["musait"].Visible = false;
            dataGridRent.Columns["hasarFoto"].Visible = false;
        }

        //plakaya gore arama
        private void searchBoxRent_TextChanged(object sender, EventArgs e)
        {
            string searchChar = searchBoxRent.Text.ToLower();

            string query = "SELECT * FROM aracBilgi WHERE LOWER(plaka) LIKE @searchChar";
            try
            {
                con.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@searchChar", "%" + searchChar + "%");

                    DataTable dv = new DataTable();
                    da.Fill(dv);
                    dataGridRent.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBoxSozlesmePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridRent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}