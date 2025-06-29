using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace repo1
{
    public partial class EditForm : Form
    {
        //tum araclar formdan data cekme
        private vehicleForm vehicleFormData;
        public EditForm(vehicleForm vehicleForm, string plaka, string marka, string model, string yil, string yakit, string vites,
            string km, string kapi, string kasaTipi, string renk, string hasar, string aracFoto)
        {
            InitializeComponent();
            this.vehicleFormData = vehicleForm;
            textBoxPlaka.Text = plaka;
            textBoxBrand.Text = marka;
            textBoxModel.Text = model;
            textBoxYear.Text = yil;
            comboBoxFuel.Text = yakit;
            comboBoxGear.Text = vites;
            textBoxKm.Text = km;
            comboBoxDoor.Text = kapi;
            textBoxBody.Text = kasaTipi;
            textBoxColor.Text = renk;
            pictureBoxVehicle.ImageLocation = aracFoto;
            if (hasar == "Evet")
            {
                radioBtnYes.Checked = true;
            }
            else
            {
                radioBtnNo.Checked = true;
            }
            vehicleFormData = vehicleForm;
        }

        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb";


        //kaydet butonu basilinca islemler
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string plaka = textBoxPlaka.Text;
            string marka = textBoxBrand.Text;
            string model = textBoxModel.Text;
            string yil = textBoxYear.Text;
            string yakit = comboBoxFuel.Text;
            string vites = comboBoxGear.Text;
            string km = textBoxKm.Text;
            string kapi = comboBoxDoor.Text;
            string kasaTipi = textBoxBody.Text;
            string renk = textBoxColor.Text;
            string hasar = radioBtnYes.Checked ? "Evet" : "Hayır";
            string yeniAracFoto = pictureBoxVehicle.ImageLocation;

            //datayi yenileme 
            if (textBoxPlaka.Text.Length >= 0 &&
                textBoxBrand.Text.Length >= 0 &&
                textBoxModel.Text.Length >= 0 &&
                textBoxYear.Text.Length >= 0 &&
                comboBoxFuel.Text.Length >= 0 &&
                comboBoxGear.Text.Length >= 0 &&
                textBoxKm.Text.Length >= 0 &&
                comboBoxDoor.Text.Length >= 0 &&
                textBoxBody.Text.Length >= 0 &&
                textBoxColor.Text.Length >= 0)
            {

                string updateQuery = "UPDATE aracBilgi SET " +
                                 "marka = '" + marka + "', " +
                                 "model = '" + model + "', " +
                                 "yil = '" + yil + "', " +
                                 "yakit = '" + yakit + "', " +
                                 "vites = '" + vites + "', " +
                                 "km = '" + km + "', " +
                                 "kapi = '" + kapi + "', " +
                                 "kasaTipi = '" + kasaTipi + "', " +
                                 "renk = '" + renk + "', " +
                                 "hasar = '" + hasar + "', " +
                                 "aracFoto = '" + yeniAracFoto + "' " +
                                 "WHERE plaka = '" + plaka + "'";

                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(updateQuery, conn);
                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Araç başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu veya güncellenecek araç bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    vehicleFormData.vehicleGet();
                    conn.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Doldurunuz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //fotograf secme ve klasorumuze yukleme
        private void btnVehiclePic_Click(object sender, EventArgs e)
        {

            OpenFileDialog choosePicture = new OpenFileDialog();
            choosePicture.Title = "Resim Dosyası Seçin";
            choosePicture.InitialDirectory = "C:\\";
            choosePicture.Filter = "PNG dosyaları (*.png)|*.png|JPEG dosyaları (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (choosePicture.ShowDialog() == DialogResult.OK)
            {

                pictureBoxVehicle.ImageLocation = choosePicture.FileName;
                // Resim dosyası seçildiğinde yapılacak işlemler buraya eklenebilir.
            }
            string plaka = textBoxPlaka.Text;
            string folderPath = @"C:\RentaCar\Arac_foto";
            string fileName = plaka + ".jpg";
            string aracFoto = Path.Combine(folderPath, fileName);
            string sourceFilePath = pictureBoxVehicle.ImageLocation;
            File.Copy(sourceFilePath, aracFoto, true);

            try
            {
                if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                {
                    if (File.Exists(aracFoto))
                    {
                        File.Delete(aracFoto);
                    }
                    File.Copy(sourceFilePath, aracFoto, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fotoğraf işlemleri sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
    }
