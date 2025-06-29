using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static repo1.addVehicleForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

    namespace repo1
    {
        public partial class vehicleForm : Form
        {
            OleDbConnection con;
            OleDbDataAdapter da;
            DataSet ds;

            public vehicleForm()
            {
                InitializeComponent();
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
            }

            //musteri islemleri butonu
            private void btnCustomerForm_Click(object sender, EventArgs e)
            {
                Form customerForm = new customerForm();
                customerForm.Show();
                this.Hide();
            }

            //kira islemleri butonu
            private void btnRentForm_Click(object sender, EventArgs e)
            {
                Form rentForm = new rentForm();
                rentForm.Show();
                this.Hide();
            }

            //arac ekle butonu
            private void btnAddVehicle_Click(object sender, EventArgs e)
            {
                addVehicleForm addVehicleForm = new addVehicleForm(this);
                addVehicleForm.ShowDialog();
            }

            //arac durumu butonu
            private void btnStatusForm_Click(object sender, EventArgs e)
            {
                Form statusForm = new statusForm();
                statusForm.Show();
                this.Hide();
            }
            
            //database den araclari cekme metodu
            public void vehicleGet()
            {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
            da = new OleDbDataAdapter("SELECT * FROM aracBilgi", con);
                ds = new DataSet();
                try
                {
                    con.Open();
                    da.Fill(ds, "aracBilgi");
                    dataGridAllVehicle.DataSource = ds.Tables["aracBilgi"];
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
            
            //dataGride veri ekleme
            private void vehicleForm_Load(object sender, EventArgs e)
            {
                vehicleGet();
                dataGridAllVehicle.Columns["aracFoto"].Visible = false;
                dataGridAllVehicle.Columns["plaka"].HeaderText = "Plaka";
                dataGridAllVehicle.Columns["marka"].HeaderText = "Marka";
                dataGridAllVehicle.Columns["model"].HeaderText = "Model";
                dataGridAllVehicle.Columns["yil"].HeaderText = "Yıl";
                dataGridAllVehicle.Columns["yakit"].HeaderText = "Yakıt";
                dataGridAllVehicle.Columns["vites"].HeaderText = "Vites";
                dataGridAllVehicle.Columns["km"].HeaderText = "Kilometre";
                dataGridAllVehicle.Columns["kapi"].HeaderText = "Kapı";
                dataGridAllVehicle.Columns["kasaTipi"].HeaderText = "Kasa Tipi";
                dataGridAllVehicle.Columns["renk"].HeaderText = "Renk";
                dataGridAllVehicle.Columns["hasar"].HeaderText = "Hasar";
                dataGridAllVehicle.Columns["musait"].Visible = false;
                dataGridAllVehicle.Columns["hasarFoto"].Visible = false;
            }

            //arac duzenle butonu
            private void btnEditVehicle_Click(object sender, EventArgs e)
            {
                if (dataGridAllVehicle.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridAllVehicle.SelectedRows[0];

                    //editForm a arabanin verilerini gonderme
                    string plaka = selectedRow.Cells["plaka"].Value.ToString();
                    string marka = selectedRow.Cells["marka"].Value.ToString();
                    string model = selectedRow.Cells["model"].Value.ToString();
                    string yil = selectedRow.Cells["yil"].Value.ToString();
                    string yakit = selectedRow.Cells["yakit"].Value.ToString();
                    string vites = selectedRow.Cells["vites"].Value.ToString();
                    string km = selectedRow.Cells["km"].Value.ToString();
                    string kapi = selectedRow.Cells["kapi"].Value.ToString();
                    string kasaTipi = selectedRow.Cells["kasaTipi"].Value.ToString();
                    string renk = selectedRow.Cells["renk"].Value.ToString();
                    string hasar = selectedRow.Cells["hasar"].Value.ToString();
                    string aracFoto = selectedRow.Cells["aracFoto"].Value.ToString();
                    EditForm EditVehicleForm = new EditForm(this, plaka, marka, model, yil, yakit, vites, km, kapi, kasaTipi, renk, hasar, aracFoto);
                    EditVehicleForm.ShowDialog();
                }
            }

            //plakaya gore arama
            private void textSearchPlaka_TextChanged(object sender, EventArgs e)
            {
                string searchChar = textSearchPlaka.Text.ToLower();
                string query = "SELECT * FROM aracBilgi WHERE LOWER(plaka) LIKE @searchChar";
                da.SelectCommand.CommandText = query;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.AddWithValue("@searchChar", "%" + searchChar + "%");
                ds.Clear();
                try
                {
                    con.Open();
                    da.Fill(ds, "aracBilgi");
                    dataGridAllVehicle.DataSource = ds.Tables["aracBilgi"];
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

            //markaya gore arama
            private void textSearchBrand_TextChanged(object sender, EventArgs e)
            {
                string searchChar = textSearchBrand.Text.ToLower();
                string query = "SELECT * FROM aracBilgi WHERE LOWER(marka) LIKE @searchChar";
                da.SelectCommand.CommandText = query;
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.AddWithValue("@searchChar", "%" + searchChar + "%");
                ds.Clear();
                try
                {
                    con.Open();
                    da.Fill(ds, "aracBilgi");
                    dataGridAllVehicle.DataSource = ds.Tables["aracBilgi"];
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

            //arabayi silme
            private void btnDeleteVehicle_Click(object sender, EventArgs e)
            {
                if (dataGridAllVehicle.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridAllVehicle.SelectedRows[0];
                    string plaka = selectedRow.Cells["plaka"].Value.ToString();

                    string deleteQuery = "DELETE FROM aracBilgi WHERE plaka = @plaka";

                    OleDbCommand cmd = new OleDbCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@plaka", plaka);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Araç silinirken bir hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                         
                         con.Close();
                    vehicleGet();
                }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz aracı seçin!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //pdf cikarma 
            private void btnVehiclePDF_Click(object sender, EventArgs e)
            {
                if (dataGridAllVehicle.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    //pdf in cikarilacagi yer
                    sfd.InitialDirectory = @"C:\RentaCar\PDFs";
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    string currentDate = DateTime.Now.ToString("D");
                    sfd.FileName = (currentDate + " Tüm Araçlar.pdf");

                bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("Hata:" + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                PdfPTable pdfTable = new PdfPTable(dataGridAllVehicle.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                foreach (DataGridViewColumn column in dataGridAllVehicle.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }

                                foreach (DataGridViewRow row in dataGridAllVehicle.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                                    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Close();
                                    stream.Close();
                                }

                                MessageBox.Show("Veri başarılı bir şekilde yüklendi");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Hata :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt Yok");
                }
            }

            //exel cikarma
            private void btnVehicleExcel_Click(object sender, EventArgs e)
            {
                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sayfa1");

                        for (int i = 0; i < dataGridAllVehicle.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridAllVehicle.Columns[i].HeaderText;
                        }

                        for (int i = 0; i < dataGridAllVehicle.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridAllVehicle.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dataGridAllVehicle.Rows[i].Cells[j].Value?.ToString();
                            }
                        }
                        //exelin cikarilacak yeri
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folderPath = @"C:\RentaCar\Excels";
                    string currentDate = DateTime.Now.ToString("D");
                    Directory.CreateDirectory(folderPath);
                    string fileName =  "Araç Listesi.xlsx";
                    string filePath = Path.Combine(folderPath, (currentDate +  " " +fileName));
                    workbook.SaveAs(filePath);
                }

                    MessageBox.Show("Excel dosyası başarıyla oluşturulup kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel dosyası oluşturma ve kaydetme işlemi başarısız oldu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


