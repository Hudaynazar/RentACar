using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;
using iTextSharp.text;
using Microsoft.Office.Interop.Excel;
using System.Transactions;
using System.Security.Policy;
using System.IO;

namespace repo1
{
    public partial class statusForm : Form
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb";
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;
        private DataSet ds;

        public statusForm()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
        }

        //kiralama islemleri butonu
        private void btnRentForm_Click(object sender, EventArgs e)
        {
            OpenForm(new rentForm());
        }

        //tum araclar butonu
        private void btnVehicleForm_Click(object sender, EventArgs e)
        {
            OpenForm(new vehicleForm());
        }

        //musteri islemleri butonu
        private void btnCustomerForm_Click(object sender, EventArgs e)
        {
            OpenForm(new customerForm());
        }

        //form acma metodu
        private void OpenForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        //hassar durumunu kontol etme metodu(checkbox)
        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                string plaka = selectedRow.Cells["plaka"].Value.ToString();
                string hasarDurumu = checkBoxActive.Checked ? "Evet" : "Hayır";
                UpdateHasarDurumu(plaka, hasarDurumu);
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        //hasar durumunu guncelleme metodu
        private void UpdateHasarDurumu(string plaka, string hasarDurumu)
        {
            //checkbox activ ise hasar durumu evet
            if (checkBoxActive.Checked)
            {
                textBoxDamage.Enabled = true;
                btnDamage.Enabled = true;

                if (dataGridRented.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                    string hasar = "Evet";

                    string guncelle = "UPDATE aracBilgi SET hasar = @hasar WHERE plaka = @plaka";
                    
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand(guncelle, conn);
                    cmd.Parameters.AddWithValue("@hasar", hasar);
                    cmd.Parameters.AddWithValue("@plaka", plaka);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Araç hasarlı olarak güncellendi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme hatası: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }
            // checkbox u kapatirsa hasar durumu hayir
            else
            {
                textBoxDamage.Enabled = false;
                btnDamage.Enabled = false;

                if (dataGridRented.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                    string guncelle = "UPDATE aracBilgi SET hasar = @hasar WHERE plaka = @plaka";
                    string hasar = "Hayır";

                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand(guncelle, conn);
                    cmd.Parameters.AddWithValue("@hasar", hasar);
                    cmd.Parameters.AddWithValue("@plaka", plaka);

                    try
                    {

                        conn.Open();
                        MessageBox.Show("Araç hasarlı olarak güncellendi.");
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme hatası: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        //kiralik araclari cagirma metodu
        private void rentedGet()
        {
            string query = "SELECT * FROM kiraSozlesme";

            try
            {
                conn.Open();
                da = new OleDbDataAdapter(query, conn);
                ds = new DataSet();
                da.Fill(ds, "kiraSozlesme");
                dataGridRented.DataSource = ds.Tables["kiraSozlesme"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //dataGrid tablolosunu duzenleme 
        private void statusForm_Load(object sender, EventArgs e)
        {
            rentedGet();
            dataGridRented.Columns["plaka"].HeaderText = "Plaka";
            dataGridRented.Columns["alisTarih"].HeaderText = "Alış Tarihi";
            dataGridRented.Columns["teslimTarih"].HeaderText = "Teslim Tarihi";
            dataGridRented.Columns["tcNo"].HeaderText = "Müşteri TC";
            dataGridRented.Columns["sozlesme"].Visible = false;
            dataGridRented.Columns["kapora"].Visible = false;
            dataGridRented.Columns["tutar"].Visible = false;
            dataGridRented.Columns["id"].Visible = false;
        }

        //dataGridde secileni textboxlara doldurma
        private void dataGridRented_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                string selectedId = selectedRow.Cells["id"].Value.ToString();
                string selectedPlaka = selectedRow.Cells["plaka"].Value.ToString();

                OleDbConnection conn = new OleDbConnection(connectionString);

                // Kira sözleşmesini getirme 
                string contractQuery = "SELECT * FROM kiraSozlesme WHERE id = @id";
                OleDbDataAdapter daContract = new OleDbDataAdapter(contractQuery, conn);
                daContract.SelectCommand.Parameters.AddWithValue("@id", selectedId);
                DataSet dsContract = new DataSet();

                // Müşteri bilgilerini getirme
                string customerQuery = "SELECT * FROM musteriBilgi WHERE tcNo = @tcNo";
                OleDbDataAdapter daCustomer = new OleDbDataAdapter(customerQuery, conn);
                string selectedTcNo = "";
                DataSet dsCustomer = new DataSet();

                // Plaka ile km bilgisini getirme
                string getKmQuery = "SELECT km FROM aracBilgi WHERE plaka = @plaka";

                try
                {
                    conn.Open();

                    // Kira sözleşmesi bilgilerini getirme
                    daContract.Fill(dsContract, "kiraSozlesme");
                    DataRow drContract = dsContract.Tables["kiraSozlesme"].Rows[0];

                    labelTimePick.Text = drContract["alisTarih"].ToString();
                    labelTimeDrop.Text = drContract["teslimTarih"].ToString();
                    anlasılanTutar.Text = drContract["tutar"].ToString() + "₺";
                    labelDeposit.Text = drContract["kapora"].ToString() + "₺";

                    selectedTcNo = drContract["tcNo"].ToString();

                    // Müşteri bilgilerini getirme
                    daCustomer.SelectCommand.Parameters.AddWithValue("@tcNo", selectedTcNo);
                    daCustomer.Fill(dsCustomer, "musteriBilgi");
                    DataRow drCustomer = dsCustomer.Tables["musteriBilgi"].Rows[0];

                    labelTc.Text = drCustomer["tcNo"].ToString();
                    labelName.Text = drCustomer["isim"].ToString();
                    labelLastName.Text = drCustomer["soyisim"].ToString();
                    labelPhone.Text = drCustomer["cepTelefonu"].ToString();

                    // Plaka ile km bilgisini getirme
                    OleDbCommand getKmCmd = new OleDbCommand(getKmQuery, conn);
                    getKmCmd.Parameters.AddWithValue("@plaka", selectedPlaka);
                    object result = getKmCmd.ExecuteScalar();

                    if (result != null)
                    {
                        string currentKm = result.ToString();
                        labelKm.Text = currentKm;
                    }
                    else
                    {
                        MessageBox.Show("Araç km bilgisi bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //plakaya gore arama
        private void searchBoxRent_TextChanged(object sender, EventArgs e)
        {
            string searchChar = searchBoxRent.Text;
            string query = "SELECT * FROM kiraSozlesme WHERE plaka LIKE ?";

            try
            {
                conn.Open();
                da = new OleDbDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@plaka", "%" + searchChar + "%");
                ds = new DataSet();
                da.Fill(ds, "kiraSozlesme");
                dataGridRented.DataSource = ds.Tables["kiraSozlesme"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //pdf cikarma
        private void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                string selectedPlaka = selectedRow.Cells["plaka"].Value.ToString();
                DownloadContractPDF(selectedPlaka);
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        //kira sozlesme pdf ini acma
        private void DownloadContractPDF(string plaka)
        {
            string contractQuery = "SELECT sozlesme FROM kiraSozlesme WHERE plaka = ?";

            try
            {
                conn.Open();
                da = new OleDbDataAdapter(contractQuery, conn);
                da.SelectCommand.Parameters.AddWithValue("@plaka", plaka);
                ds = new DataSet();
                da.Fill(ds, "kiraSozlesme");

                if (ds.Tables["kiraSozlesme"].Rows.Count > 0)
                {
                    DataRow drContract = ds.Tables["kiraSozlesme"].Rows[0];
                    string filePath = drContract["sozlesme"].ToString();

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                    else
                    {
                        MessageBox.Show("PDF dosya yolu değiştirilmiş veya silinmiş.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sözleşme açılırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //hasar resmi yukleme
        private void btnDamage_Click(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir satır seçin.");
                return;
            }

            string plaka = dataGridRented.SelectedRows[0].Cells["plaka"].Value.ToString();
            string contractQuery = "SELECT sozlesme FROM kiraSozlesme WHERE plaka = ?";

            try
            {
                conn.Open();
                da = new OleDbDataAdapter(contractQuery, conn);
                da.SelectCommand.Parameters.AddWithValue("@plaka", plaka);
                ds = new DataSet();
                da.Fill(ds, "kiraSozlesme");

                if (ds.Tables["kiraSozlesme"].Rows.Count > 0)
                {
                    DataRow drContract = ds.Tables["kiraSozlesme"].Rows[0];
                    string filePath = drContract["sozlesme"].ToString();


                    OpenFileDialog choosePicture = new OpenFileDialog();
                    choosePicture.Title = "Resim Dosyası Seçin";
                    choosePicture.InitialDirectory = "C:\\";
                    choosePicture.Filter = "PNG dosyaları (*.png)|*.png|JPEG dosyaları (*.jpg;*.jpeg)|*.jpg;*.jpeg";
                    if (choosePicture.ShowDialog() == DialogResult.OK)
                    {
                        string sourceFilePath = choosePicture.FileName;
                        string folderPath = @"C:\RentaCar\Hasar";
                        string fileName = plaka + ".jpg";
                        string aracFoto = Path.Combine(folderPath, fileName);
                        File.Copy(sourceFilePath, aracFoto, true);
                    }
                }
                else
                {
                    MessageBox.Show("Belirtilen plakaya ait kira sözleşmesi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sözleşme açılırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        //odenecek tutari hesaplama
        private void btnCount_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = true;
            if (dataGridRented.SelectedRows.Count > 0)
            {
                
                    if (textBoxLastKm.Text.Length > 0)
                    {
                        //Aracin Kiraya Vermeden Onceki Kilometresini Cekme
                        string kilometre;
                        string plaka = dataGridRented.SelectedRows[0].Cells["plaka"].Value.ToString();
                        OleDbConnection conn = new OleDbConnection(connectionString);
                        string query = "SELECT * FROM aracBilgi  WHERE plaka = @plaka";
                        OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.SelectCommand.Parameters.AddWithValue("plaka", plaka);
                        da.Fill(ds, "aracBilgi");
                        DataRow dsCustomer = ds.Tables["aracBilgi"].Rows[0];
                        kilometre = dsCustomer["km"].ToString();
                        
                        

                        int ilkKm = Convert.ToInt32(kilometre);
                        int sonKm = Convert.ToInt32(textBoxLastKm.Text);
                        if (sonKm - ilkKm > 0)
                        {
                            if (sonKm - ilkKm < 700)
                            {
                                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                                object cellKapora = selectedRow.Cells["kapora"].Value;
                                object cellTutar = selectedRow.Cells["tutar"].Value;
                                int kapora = Convert.ToInt32(cellKapora);
                                int tutar = Convert.ToInt32(cellTutar);
                                if (checkBoxActive.Checked == true)
                                {
                                    int hasar = int.Parse(textBoxDamage.Text.ToString());
                                    labelAllAmount.Text = (tutar + hasar - kapora).ToString();
                                }
                            else
                            {
                                labelAllAmount.Text = (tutar - kapora).ToString();
                            }


                        }
                            else
                            {
                            DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                            object cellKapora = selectedRow.Cells["kapora"].Value;
                            object cellTutar = selectedRow.Cells["tutar"].Value;
                            int kapora = Convert.ToInt32(cellKapora);
                            int tutar = Convert.ToInt32(cellTutar);
                            int km = (sonKm - ilkKm - 700);
                            if (checkBoxActive.Checked == true)
                            {
                                int hasarr = int.Parse(textBoxDamage.Text.ToString());
                                labelAllAmount.Text = (((tutar + hasarr) - kapora) + (km * 20)).ToString();
                            }
                            else
                            {
                                labelAllAmount.Text = ((tutar - kapora) + (km * 20)).ToString();
                            }


                        }
                    }
                        else
                        {
                            MessageBox.Show("Hata! Son KM ILK KILOMETREDEN KUCUK OLAMAZ!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata! Lutfen Son KM'yi Giriniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        

        //onayla butonu
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                string lastKm = textBoxLastKm.Text;
                string plaka = selectedRow.Cells["plaka"].Value.ToString();
                string musait = "evet";
                foreach (DataGridViewRow row in dataGridRented.Rows)
                {
                    if (row.Index != selectedRow.Index)
                    {
                        string otherPlaka = row.Cells["plaka"].Value.ToString();

                        if (plaka == otherPlaka)
                        {
                            musait = "hayir";
                            break;
                        }
                    }
                }
                //son kilometreyi guncelleme
                string updateQuery = "UPDATE aracBilgi SET musait = '" + musait + "',km = '" + lastKm + "'  WHERE plaka = '" + plaka + "' ";
                string checkPlakaQuery = "SELECT COUNT(*) FROM aracBilgi WHERE plaka = @plaka";

                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(updateQuery, conn);
                OleDbCommand checkCmd = new OleDbCommand(checkPlakaQuery, conn);

                checkCmd.Parameters.AddWithValue("@plaka", plaka);

                try
                {
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("Ödeme Tamamlandı!");
                    int plakaCount = (int)checkCmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Araç kiralanırken hata oluştu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }

            btnClear.Enabled = true;
        }


        
        //araci bosa cikar butonu
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dataGridRented.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridRented.SelectedRows[0];
                string plaka = selectedRow.Cells["plaka"].Value.ToString();
                ClearRental(plaka);
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        //araci kiradan cikaarma
        private void ClearRental(string plaka)
        {
            string deleteQuery = "DELETE FROM kiraSozlesme WHERE plaka = ?";

            try
            {
                conn.Open();
                cmd = new OleDbCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@plaka", plaka);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Araç müsait listesine eklendi.");
                }
                else
                {
                    MessageBox.Show("Hata! Silinmek istenen araç bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            rentedGet(); 
        }
    }
}