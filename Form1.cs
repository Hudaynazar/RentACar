using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Xml.Xsl;
using System.Xml;
using System.Drawing.Printing;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using System.Reflection;
using System.Data.SqlTypes;
using System.Numerics;





namespace repo1
{
    public partial class customerForm : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand komut = new OleDbCommand();
        public customerForm()
        {
          
            InitializeComponent();

            // C:\ - klasorune yok ise kendi klasorlerimizi olusturma
            if (!Directory.Exists(@"C:\RentaCar\PDFs"))
            {
                Directory.CreateDirectory(@"C:\RentaCar\PDFs");
            }
            if (!Directory.Exists(@"C:\RentaCar\ExcelofCustomersList"))
            {
                Directory.CreateDirectory(@"C:\RentaCar\Excels");
            }
            if (!Directory.Exists(@"C:\RentaCar\Hasar"))
            {
                Directory.CreateDirectory(@"C:\RentaCar\Hasar");
            }
            if (!Directory.Exists(@"C:\RentaCar\Musteri_foto"))
            {
                Directory.CreateDirectory(@"C:\RentaCar\Musteri_foto");
            }
            if (!Directory.Exists(@"C:\RentaCar\Arac_foto"))
            {
                Directory.CreateDirectory(@"C:\RentaCar\Arac_foto");
            }
        }

        //tum araclar butonu
        private void btnVehicleForm_Click(object sender, EventArgs e)
        {
            Form vehicleForm = new vehicleForm();
            vehicleForm.Show();
            this.Hide();
        }

        //Kirala butonu
        private void btnRentForm_Click(object sender, EventArgs e)
        {
            Form rentForm = new rentForm();
            rentForm.Show();
            this.Hide();
        }

        //arac durumu butonu
        private void btnStatusForm_Click(object sender, EventArgs e)
        {
            Form statusForm = new statusForm();
            statusForm.Show();
            this.Hide();
        }

        //duzenle butonu
        private void btnEditCustomer_Click_1(object sender, EventArgs e)
        {

            string tcNo = textBoxTc.Text;
            string isim = textBoxCustomerName.Text;
            string soyisim = textBoxCustomerLastName.Text;
            string cepTelefonu = textBoxPhone.Text;
            string mail = textBoxMail.Text;
            string ehliyet = textBoxLicence.Text;
            string meslek = textBoxCustomerJob.Text;
            string adres = textBoxAdress.Text;
            string notlar = textBoxNots.Text;
            string dogumTarihi = dateTimeBirth.Value.ToString("yyyy-MM-dd");
            string musteriFoto = pictureBoxCustomer.ImageLocation;

            string folderPath = @"C:\RentaCar\Musteri_foto";
            string fileName = tcNo + ".jpg";
            string musteriyolu = Path.Combine(folderPath, fileName);
            string sourceFilePath = pictureBoxCustomer.ImageLocation;
            File.Copy(sourceFilePath, musteriyolu, true);

            //fotograf degistirmek isterse islemler olan fotoyu silip yenisini ekleme
            try
            {
                if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                {
                    if (File.Exists(musteriyolu))
                    {
                        File.Delete(musteriyolu);
                    }
                    File.Copy(sourceFilePath, musteriyolu, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fotoğraf işlemleri sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //duzenleme 
            if (ValidateCustomerInfo())
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
                cmd = new OleDbCommand("UPDATE musteriBilgi SET isim = ?, soyisim = ?, dogumTarihi = ?, meslek = ?, cepTelefonu = ?, mail = ?, adres = ?, ehliyet = ?, notlar = ?, musteriFoto = ? WHERE tcNo = ?", con);

                cmd.Parameters.AddWithValue("?", isim);
                cmd.Parameters.AddWithValue("?", soyisim);
                cmd.Parameters.AddWithValue("?", dogumTarihi);
                cmd.Parameters.AddWithValue("?", meslek);
                cmd.Parameters.AddWithValue("?", cepTelefonu);
                cmd.Parameters.AddWithValue("?", mail);
                cmd.Parameters.AddWithValue("?", adres);
                cmd.Parameters.AddWithValue("?", ehliyet);
                cmd.Parameters.AddWithValue("?", notlar);
                cmd.Parameters.AddWithValue("?", musteriFoto);
                cmd.Parameters.AddWithValue("?", tcNo);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri başarıyla güncellendi!");
                    musteriGet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteri güncellenirken bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //duzenlemek icin kontroller
        private bool ValidateCustomerInfo()
        {
            if (textBoxTc.Text.Length == 0)
            {
                MessageBox.Show("Hatalı TC No Girdiniz! TC No 11 Haneli Olmalıdır!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxCustomerName.Text.Length == 0)
            {
                MessageBox.Show("Eksik İsim Girdiniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxCustomerLastName.Text.Length == 0)
            {
                MessageBox.Show("Eksik Soyisim Girdiniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxPhone.Text.Length == 0)
            {
                MessageBox.Show("Lütfen Telefon Bilginizi Doğru Giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxLicence.Text.Length == 0)
            {
                MessageBox.Show("Lütfen Ehliyet Bilginizi Doğru Giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxMail.Text.Length == 0)
            {
                MessageBox.Show("Lütfen Mail Bilginizi Doğru Giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxAdress.Text.Length == 0)
            {
                MessageBox.Show("Lütfen Adres Bilginizi Doğru Giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //tcNo ya gore sil butonu
        private void btnDeleteCustomer_Click_1(object sender, EventArgs e)
        {
            if (dataGridCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridCustomer.SelectedRows[0];
                string tcNo = selectedRow.Cells["tcNo"].Value.ToString();

                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
                cmd = new OleDbCommand("DELETE FROM musteriBilgi WHERE tcNo = ?", con);
                cmd.Parameters.AddWithValue("?", tcNo);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri başarıyla silindi!");
                    musteriGet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteri silinirken bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //tc ye gore arama
        private void textSearchTc_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("tcNo", textSearchTc.Text);
        }

        //isime gore arama
        private void textSearchName_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("isim", textSearchName.Text);
        }

        //maile gore arama
        private void textSearchMail_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("mail", textSearchMail.Text);
        }

        //aramalarda kullanilan metod
        private void SearchCustomer(string columnName, string searchText)
        {
            string searchChar = searchText.ToLower();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
            string query = $"SELECT * FROM musteriBilgi WHERE LOWER({columnName}) LIKE ?";
            da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("?", "%" + searchChar + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridCustomer.DataSource = dt;
        }

        //temizle butonu
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();
        }

        //textbox lari temizleme metodu
        private void ClearCustomerFields()
        {
            textBoxTc.Text = null;
            textBoxCustomerName.Text = null;
            textBoxCustomerLastName.Text = null;
            textBoxPhone.Text = null;
            textBoxMail.Text = null;
            textBoxLicence.Text = null;
            textBoxCustomerJob.Text = null;
            textBoxAdress.Text = null;
            textBoxNots.Text = null;
            dateTimeBirth.Value = DateTime.Today;
            pictureBoxCustomer.Image = null;
        }

        //resim sec butonu
        private void btnCustomerPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosePicture = new OpenFileDialog();
            choosePicture.Title = "Resim Dosyası Seçin";
            choosePicture.InitialDirectory = "C:\\";
            choosePicture.Filter = "PNG dosyaları (*.png)|*.png|JPEG dosyaları (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (choosePicture.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCustomer.ImageLocation = choosePicture.FileName;
                string tcNo = textBoxTc.Text;
                string folderPath = @"C:\RentaCar\Musteri_foto";
                string fileName = tcNo + ".jpg";
                string musteriyolu = Path.Combine(folderPath, fileName);
                string sourceFilePath = pictureBoxCustomer.ImageLocation;
                File.Copy(sourceFilePath, musteriyolu, true);

                //resmi kendi klasorumuze ekleme butonu
                try
                {
                    if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                    {
                        if (File.Exists(musteriyolu))
                        {
                            File.Delete(musteriyolu);
                        }
                        File.Copy(sourceFilePath, musteriyolu, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fotoğraf işlemleri sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        //musterileri cagirma metodu
        private void musteriGet()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
            da = new OleDbDataAdapter("SELECT * FROM musteriBilgi", con);
            ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "musteriBilgi");
                dataGridCustomer.DataSource = ds.Tables["musteriBilgi"];
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

        //musterileri datagride getirme 
        private void customerForm_Load(object sender, EventArgs e)
        {
            musteriGet();
            dataGridCustomer.Columns["tcNo"].HeaderText = "TC";
            dataGridCustomer.Columns["isim"].HeaderText = "İsim";
            dataGridCustomer.Columns["soyisim"].HeaderText = "Soyisim";
            dataGridCustomer.Columns["dogumTarihi"].Visible = false;
            dataGridCustomer.Columns["meslek"].Visible = false;
            dataGridCustomer.Columns["cepTelefonu"].HeaderText = "Cep Telefonu";
            dataGridCustomer.Columns["mail"].HeaderText = "Email";
            dataGridCustomer.Columns["adres"].Visible = false;
            dataGridCustomer.Columns["ehliyet"].Visible = false;
            dataGridCustomer.Columns["notlar"].Visible = false;
            dataGridCustomer.Columns["musteriFoto"].Visible = false;
        }

        //exel butonu
            private void btnExcel_Click(object sender, EventArgs e)
            {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < dataGridCustomer.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridCustomer.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dataGridCustomer.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridCustomer.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataGridCustomer.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    //exelin cikacagi klasoru ayarlama
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folderPath = @"C:\RentaCar\Excels";
                  
                    string currentDate = DateTime.Now.ToString("D");
                    Directory.CreateDirectory(folderPath);
                    string fileName = "Müşteri Listesi.xlsx";
                    string filePath = Path.Combine(folderPath, ( currentDate + " " + fileName));
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Excel dosyası başarıyla oluşturulup kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel dosyası oluşturma ve kaydetme işlemi başarısız oldu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //data grid de secileni satiri textbox lara tasima
        private void dataGridCustomer_SelectionChanged(object sender, EventArgs e)
        {


            if (dataGridCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridCustomer.SelectedRows[0];
                textBoxTc.Text = selectedRow.Cells["tcNo"].Value.ToString();
                textBoxCustomerName.Text = selectedRow.Cells["isim"].Value.ToString();
                textBoxCustomerLastName.Text = selectedRow.Cells["soyisim"].Value.ToString();
                textBoxPhone.Text = selectedRow.Cells["cepTelefonu"].Value.ToString();
                textBoxMail.Text = selectedRow.Cells["mail"].Value.ToString();
                textBoxLicence.Text = selectedRow.Cells["ehliyet"].Value.ToString();
                textBoxCustomerJob.Text = selectedRow.Cells["meslek"].Value.ToString();
                textBoxAdress.Text = selectedRow.Cells["adres"].Value.ToString();
                textBoxNots.Text = selectedRow.Cells["notlar"].Value.ToString();
                dateTimeBirth.Text = selectedRow.Cells["dogumTarihi"].Value.ToString();

                if (selectedRow.Cells["musteriFoto"].Value != null)
                {
                    string musteriFotoPath = selectedRow.Cells["musteriFoto"].Value.ToString();
                    pictureBoxCustomer.ImageLocation = musteriFotoPath;
                }
                else
                {
                    pictureBoxCustomer.Image = null;
                }

            }
        }

        //pdf cikarma
        private void btnPDF_Click(object sender, EventArgs e)
            {
                if (dataGridCustomer.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();

                //pdf i cikarma yeini gosteriyor
                    sfd.InitialDirectory = @"C:\RentaCar\PDFs";
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                     string currentDate = DateTime.Now.ToString("D");
               
                     sfd.FileName = (currentDate + " Tüm Müşteriler.pdf");
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
                                PdfPTable pdfTable = new PdfPTable(dataGridCustomer.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                foreach (DataGridViewColumn column in dataGridCustomer.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }

                                foreach (DataGridViewRow row in dataGridCustomer.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
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

        //ekle butonu
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
                string tcNo = textBoxTc.Text;
                string isim = textBoxCustomerName.Text;
                string soyisim = textBoxCustomerLastName.Text;
                string cepTelefonu = textBoxPhone.Text;
                string mail = textBoxMail.Text;
                string ehliyet = textBoxLicence.Text;
                string meslek = textBoxCustomerJob.Text;
                string adres = textBoxAdress.Text;
                string notlar = textBoxNots.Text;
                string dogumTarihi = dateTimeBirth.Value.ToString("yyyy-MM-dd");
                string musteriFoto = pictureBoxCustomer.ImageLocation;

                if (ValidateCustomerInfo())
                {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb");
                cmd = new OleDbCommand ("INSERT INTO musteriBilgi (tcNo, isim, soyisim, dogumTarihi, meslek, cepTelefonu, mail, adres, ehliyet, notlar, musteriFoto) " +
                                         "VALUES (@tcNo, @isim, @soyisim, @dogumTarihi, @meslek, @cepTelefonu, @mail, @adres, @ehliyet, @notlar, @musteriFoto)", con);

                cmd.Parameters.AddWithValue("@tcNo", tcNo);
                    cmd.Parameters.AddWithValue("@isim", isim);
                    cmd.Parameters.AddWithValue("@soyisim", soyisim);
                    cmd.Parameters.AddWithValue("@dogumTarihi", dogumTarihi);
                    cmd.Parameters.AddWithValue("@meslek", meslek);
                    cmd.Parameters.AddWithValue("@cepTelefonu", cepTelefonu);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.Parameters.AddWithValue("@ehliyet", ehliyet);
                    cmd.Parameters.AddWithValue("@notlar", notlar);
                    cmd.Parameters.AddWithValue("@musteriFoto", musteriFoto);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla eklendi!");
                        musteriGet();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Müşteri eklenirken bir hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }
    }
   
