using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace eczane_barkod_sistemi
{
    public partial class Form_ilac_fotograf_video : Form
    {
        public Form_ilac_fotograf_video(string[] barkodDizi)
        {
            InitializeComponent();
            this.barkodDizi = barkodDizi;
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Events
        /// </summary>
        /// 
        ///
        ///

        //Form yüklendiğinde gelen barkod numarasını veritabanında sorgulayacak.
        //Okunan barkod veritabanında kayıtlı ise ilgili fotoğraf gelecek.
        //Eğer barkod veritabanında kayıtlı değilse 
        //"okunan barkod veritabanında bulunamadı" 
        //şeklinde uyarı verip bir önceki form'a geri dönülecek.
        private void ilac_fotograf_video_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap image = new Bitmap((Application.StartupPath + this.barkodDizi[2]));
                pictureBox_fotograf.Image = image;
            }
            catch
            {
                MessageBox.Show("Fotoğraf yüklenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Form kapatıldığında
        private void From_ilac_fotograf_video_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!form_normalGecis) //Form1 in kapatılma isteğini kullanıcı istediyse uygulamadan çık. (Alt + F4)
                Application.Exit();
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
        private string[] barkodDizi = new string[4];
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
        //Video İzle butonuna tıklandığında ilgili video izlenecek
        private void button_video_Click(object sender, EventArgs e)
        {
            if (barkodDizi[3].Length != 0) //barkod numarasına ait video bilgisi veritabanında var mı?
            {
                if (File.Exists(Application.StartupPath + barkodDizi[3])) //Video dosyası mevcut mu?
                    System.Diagnostics.Process.Start(Application.StartupPath + barkodDizi[3]);
                else
                    MessageBox.Show(barkodDizi[0] + " numaralı barkodun videosu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(barkodDizi[0] + " numaralı barkodun videosu mevcut değil.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Yeni barkod okunması için bir önceki form'a dönülecek.
        private void button_yeniBarkod_Click(object sender, EventArgs e)
        {
            new Form_barkod_oku().Show();
            this.form_normalGecis = true;
            this.Close();
        }

        //Giriş ekranına geri dön.
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
    }
}
