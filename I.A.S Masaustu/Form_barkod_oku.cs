using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Barcode;
using AForge.Video;
using AForge.Video.DirectShow;
using Spire.Barcode;
using System.Data.SQLite;
using System.Diagnostics;

namespace eczane_barkod_sistemi
{
    public partial class Form_barkod_oku : Form
    {
        public Form_barkod_oku()
        {
            InitializeComponent();
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Events
        /// </summary>
        /// 
        ///
        ///
        private void Form1_Load(object sender, EventArgs e)
        {
            //START
            //Kamera ayarları yapılıyor.
            this.webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice); //Pc ye bağlı Video Giriş Aygıtlarını ayıkladı ve webcams değişkenine attı.
            for (int i = 0; i < this.webcams.Count; i++)
                this.comboBox1.Items.Add(webcams[i].Name); //webcams dizisindeki aygıt isimlerini comboBox1 e yerleştirdi.
            if (this.comboBox1.Items.Count == 0) //Pc'ye bağlı kamera var mı? Yoksa bu bloğa gir.
            {
                MessageBox.Show("Bilgisayara bağlı kamera bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cam = new VideoCaptureDevice(); //Eğer kamera yoksa uygulamadan çıkarken hata vermemesi için eklendi bu satır. (Form1_FormClosed olayı)
                this.button_formGiris_git_Click(sender, e); //Kamera bulunamamışsa bu forma giriş izni verilmedi demektir.
            }
            else //Kamera bulunduysa bu bloğa gir.
            {
                this.comboBox1.SelectedIndex = 0; //Pc'ye bağlı ilk kamera seçildi.
                this.comboBox1_indexControl = this.comboBox1.SelectedIndex;
                this.cam = new VideoCaptureDevice(this.webcams[this.comboBox1.SelectedIndex].MonikerString); //Seçili kamera bilgisi ile "new VideoCaptureDevice()" sınıfı oluşturuldu.
                this.cam.NewFrame += new NewFrameEventHandler(cam_NewFrame); //this.cam.NewFrame' e yeni event eklendi.
                this.cam.Start(); //Kamera başlatıldı.
            }
            //END

            //START
            //Database işlemleri
            adres = @"Data Source=" + Application.StartupPath + @"\eczane_barkod_sistemi.db;Version=3;";
            baglanti = new SQLiteConnection(adres);
            //END
            timer_BarcodeRead.Start();
        }


        //Form kapatıldığında
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.cam.IsRunning) //Kamera çalışıyorsa durdur. (Aksi takdirde programdan çıkmaz)
                cam.Stop();
            if (!form_normalGecis) //Form1 in kapatılma isteğini kullanıcı istediyse uygulamadan çık. (Alt + F4)
                Application.Exit();
        }


        //comboBox1'in indexi değiştiğinde
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Farklı bir kamera seçildiğinde bu bloğu işle.
        {
            if (this.comboBox1_indexControl != this.comboBox1.SelectedIndex)
            {
                this.cam.Stop(); //Önceki seçilen kamera durduruldu.
                this.cam = new VideoCaptureDevice(this.webcams[this.comboBox1.SelectedIndex].MonikerString);
                this.cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                this.comboBox1_indexControl = this.comboBox1.SelectedIndex;
                this.cam.Start(); //Yeni seçilen kamera başlatıldı.
            }
        }



        //Sadece rakam girişini kontrol etmek için
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if ((char)e.KeyChar == (char)Keys.Enter)
                button_BarkodTara_Click(new object(), new EventArgs());
        }
        ///
        /// 
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Global Variables
        /// </summary>
        /// 
        ///
        ///
        private bool form_normalGecis = false; //Form_barkod_oku kapatıldığında bu kapatma isteğini kullanıcı mı yaptı yoksa program mı yaptı kontrol altına almak için kullanıldı.
        private AForge.Video.DirectShow.FilterInfoCollection webcams; //Pc ye bağlı kaç tane kamera bağlı olduğunu tutacak dizi.
        private AForge.Video.DirectShow.VideoCaptureDevice cam; //Kullanılacak aygıt.
        private int comboBox1_indexControl;
        private string adres;
        private System.Data.SQLite.SQLiteConnection baglanti;
        private System.Data.SQLite.SQLiteCommand komut;
        ///
        /// 
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Methods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ///
        ///
        //Barkod taraması yapar
        private void button_BarkodTara_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 13)
            {
                string[] barkodDizi = this.BarcodeControl(textBox1.Text);
                try
                {
                    if (barkodDizi[0] != null)
                        this.ilacGoster(barkodDizi);
                    else
                        MessageBox.Show("İlaç bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
            }
            else
                MessageBox.Show("Lütfen geçerli bir barkod numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            textBox1.Text = "";
        }



        // this.cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.pictureBox_video.Image = (Bitmap)eventArgs.Frame.Clone(); //Kameradan alınan görüntü pictureBox_video.Image 'e aktarılıyor.
        }

        //Kamera görüntüsü gelmediyse form1 i yeniden oluştur.
        private void button_yenile_Click(object sender, EventArgs e)
        {
            new Form_barkod_oku().Show();
            this.form_normalGecis = true;
            this.Close();
        }

        //Form_giris formuna gider.
        private void button_formGiris_git_Click(object sender, EventArgs e) //Form_barkod_oku formuna gelindiğinde kamera bulunamamışsa akış buraya yönlendiriliyor.
        {
            new Form_giris().Show();
            this.form_normalGecis = true;
            this.Close();
        }

        //Uygulamadan çıkar.
        private void button_kapat_Click(object sender, EventArgs e)
        {
            new Form_giris().Show();
            this.form_normalGecis = true;
            this.Close();
        }
        ///
        /// 
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







        ///////
        //DÜZENLENECEK KOD BLOĞU
        ///////

        //timer bloğu
        private void timer_BarcodeRead_Tick(object sender, EventArgs e) //timer bloğu
        {
            this.basla();
        }


        //int sayac = 0;
        //timer çağırdı -> barkod okunuyor
        void basla()
        {
            string[] datas = { };
            try
            {
                datas = Spire.Barcode.BarcodeScanner.Scan((Bitmap)pictureBox_video.Image, BarCodeType.DataMatrix); //pictureBox'taki image'i tara ve sonucu datas[]' a dönder.
            }
            catch { }
            if (datas.Length != 0) //Dönen değer varsa bu bloğa gir.
            {
                //MessageBox.Show(datas[0]);
                if (datas[0].Length >= 40)
                {
                    string barkod = datas[0].Replace("<FNC1>", "").Remove(0, 3).Remove(13); //Gerekli barkod numarası alınacak şekilde ayarlandı.
                    string[] barkodDizi = this.BarcodeControl(barkod);
                    try
                    {
                        if (barkodDizi[0] != null)
                            this.ilacGoster(barkodDizi);
                    }
                    catch
                    {
                    }
                }
            }
        }


        //Yollanan barkod numarası database de kayıtlı mı kontrol et.
        private string[] BarcodeControl(string barkod)
        {
            string[] barkodDizi = new string[4];
            try
            {
                this.baglanti.Open();
                this.komut = new SQLiteCommand("SELECT * FROM ilaclar WHERE barkod='" + barkod + "';", this.baglanti); //Veritabanında böyle bir barkod kayıtlı mı?
                SQLiteDataReader okunan = komut.ExecuteReader();
                while (okunan.Read())
                {
                    barkodDizi[0] = okunan[0].ToString();
                    barkodDizi[1] = okunan[1].ToString();
                    barkodDizi[2] = okunan[2].ToString();
                    barkodDizi[3] = okunan[3].ToString();
                    //MessageBox.Show("barkod: " + okunan[0] + "\nilac: " + okunan[1]);
                }
                okunan.Close();
                komut.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return barkodDizi;
        }


        //Yeni forma geç.
        private void ilacGoster(string[] barkodDizi)
        {
            this.form_normalGecis = true;
            this.Close();
            new Form_ilac_fotograf_video(barkodDizi).Show();
        }

    }
}
