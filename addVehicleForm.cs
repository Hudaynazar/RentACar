using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace repo1
{
    public partial class addVehicleForm : Form
    {
        //Araclar Formundan Data Cekme
        vehicleForm vehicleFormData;
        
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\RentaCar\\aracKiralama.accdb";


        public addVehicleForm(vehicleForm vehicleForm)
        {
            InitializeComponent();
            this.vehicleFormData = vehicleForm;
        }

        //Resim sec butonu
        private void btnVehiclePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog choosePicture = new OpenFileDialog();
            choosePicture.Title = "Resim Dosyası Seçin";
            choosePicture.InitialDirectory = "C:\\";
            choosePicture.Filter = "PNG dosyaları (*.png)|*.png|JPEG dosyaları (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (choosePicture.ShowDialog() == DialogResult.OK)
            {

                pictureBoxVehicle.ImageLocation = choosePicture.FileName;
            }

            

        }

        //Kaydet butonu basilinca yapilacak islemler
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string aracFoto = pictureBoxVehicle.ImageLocation;
            string plaka = textBoxPlaka.Text.ToUpper();
            string marka = textBoxBrand.Text.ToUpper();
            string model = textBoxModel.Text.ToUpper();
            string yil = textBoxYear.Text;
            string yakit = comboBoxFuel.Text;
            string vites = comboBoxGear.Text;
            string km = textBoxKm.Text;
            string kapi = comboBoxDoor.Text;
            string kasaTipi = textBoxBody.Text;
            string renk = textBoxColor.Text;
            string hasar = radioBtnYes.Checked ? "Evet" : "Hayır";
            string musait = "evet";

            if (string.IsNullOrEmpty(plaka))
            {
                MessageBox.Show("Lütfen geçerli bir plaka girin.");
                return;
            }

            //fotografi kendi klasorumuze atama
            string folderPath = @"C:\RentaCar\Arac_foto";
            string fileName = plaka + ".jpg";
            string aracPhoto = Path.Combine(folderPath, fileName);
            string sourceFilePath = pictureBoxVehicle.ImageLocation;
            File.Copy(sourceFilePath, aracPhoto, true);

            //dataya ekleme parametre olarak
            if (!string.IsNullOrEmpty(plaka) &&
                !string.IsNullOrEmpty(marka) &&
                !string.IsNullOrEmpty(model) &&
                !string.IsNullOrEmpty(yil) &&
                !string.IsNullOrEmpty(yakit) &&
                !string.IsNullOrEmpty(vites) &&
                !string.IsNullOrEmpty(km) &&
                !string.IsNullOrEmpty(kapi) &&
                !string.IsNullOrEmpty(kasaTipi) &&
                !string.IsNullOrEmpty(renk))
            {
                string addQuery = "INSERT INTO aracBilgi (aracFoto, plaka, marka, model, yil, yakit, vites, km, kapi, kasaTipi, renk, hasar, musait) " +
                                  "VALUES (@aracFoto, @plaka, @marka, @model, @yil, @yakit, @vites, @km, @kapi, @kasaTipi, @renk, @hasar, @musait)";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(addQuery, conn);
                    cmd.Parameters.AddWithValue("@aracFoto", aracFoto);
                    cmd.Parameters.AddWithValue("@plaka", plaka);
                    cmd.Parameters.AddWithValue("@marka", marka);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@yil", yil);
                    cmd.Parameters.AddWithValue("@yakit", yakit);
                    cmd.Parameters.AddWithValue("@vites", vites);
                    cmd.Parameters.AddWithValue("@km", km);
                    cmd.Parameters.AddWithValue("@kapi", kapi);
                    cmd.Parameters.AddWithValue("@kasaTipi", kasaTipi);
                    cmd.Parameters.AddWithValue("@renk", renk);
                    cmd.Parameters.AddWithValue("@hasar", hasar);
                    cmd.Parameters.AddWithValue("@musait", musait);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Araç başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Araç eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Araç eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                       conn.Close();
                        vehicleFormData.vehicleGet();

                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addVehicleForm_Load(object sender, EventArgs e)
        {

        }
    }
}