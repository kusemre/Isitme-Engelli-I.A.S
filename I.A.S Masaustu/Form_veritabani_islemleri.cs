using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace eczane_barkod_sistemi
{
    public partial class Form_veritabani_islemleri : Form
    {
        public Form_veritabani_islemleri(string dbAddress)
        {
            InitializeComponent();

            //Database adres ayarları
            this.dbAddress = dbAddress;

            //form ayarları (Database)
            this.Size = new Size(800, 500);

            //groupBox ayarları (groupBox_Sil_Guncelle)
            this.groupBox_Sil_Guncelle.Location = new Point(12, 27);
            this.groupBox_Sil_Guncelle.Visible = false;

            //listView kolon ayarları (listView1)
            listView1.Columns.Add("Barkod");
            listView1.Columns.Add("İlaç Adı");
            listView1.Columns.Add("Fotoğraf");
            listView1.Columns.Add("Video");
            listView1.Columns[0].Width = 130;
            listView1.Columns[1].Width = 220;
            listView1.Columns[2].Width = 185;
            listView1.Columns[3].Width = 185;
        }






        //START
        //Events
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Form_giris().Show();
        }
        private void textBoxEkle_barkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonEkle_ekle_Click(new object(), new EventArgs());
        }
        private void textBoxEkle_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonEkle_ekle_Click(new object(), new EventArgs());
        }
        private void textBoxEkle_fotograf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonEkle_ekle_Click(new object(), new EventArgs());
        }
        private void textBoxEkle_video_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonEkle_ekle_Click(new object(), new EventArgs());
        }

        private void textBoxEkle_barkod_Leave(object sender, EventArgs e)
        {
            if (textBoxEkle_barkod.Text.Length != 13)
                panel1.BackColor = Color.Red;
            else
                panel1.BackColor = Color.Green;
        }
        private void textBoxEkle_ad_Leave(object sender, EventArgs e)
        {
            if (textBoxEkle_ad.Text.Length == 0)
                panel2.BackColor = Color.Red;
            else
                panel2.BackColor = Color.Green;
        }

        private void textBoxSilGun_barkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonSilGun_Guncelle_Click(new object(), new EventArgs());
        }
        private void textBoxSilGun_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonSilGun_Guncelle_Click(new object(), new EventArgs());
        }
        private void textBoxSilGun_fotograf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonSilGun_Guncelle_Click(new object(), new EventArgs());
        }
        private void textBoxSilGun_video_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.buttonSilGun_Guncelle_Click(new object(), new EventArgs());
        }

        private void textBoxSilGun_barkod_Leave(object sender, EventArgs e)
        {
            if (textBoxSilGun_barkod.Text.Length != 13 && this.tempBarkod.Length != 0)
                panel8.BackColor = Color.Red;
            else if (this.tempBarkod.Length != 0)
                panel8.BackColor = Color.Transparent;
        }
        private void textBoxSilGun_ad_Leave(object sender, EventArgs e)
        {
            if (textBoxSilGun_ad.Text.Length == 0 && this.tempBarkod.Length != 0)
                panel7.BackColor = Color.Red;
            else if (this.tempBarkod.Length != 0)
                panel7.BackColor = Color.Transparent;
        }

        //Tabloyu yeniler.
        private void buttonSilGun_yenile_Click(object sender, EventArgs e)
        {
            TableUpdate();
        }

        //listView1 'de barkod seçildiğinde bilgileri gerekli yerlere aktar.
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Güncellenecek bilgiler textbox'lara dolduruluyor.
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                this.tempBarkod = listView1.SelectedItems[0].SubItems[0].Text;
                textBoxSilGun_barkod.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBoxSilGun_ad.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBoxSilGun_fotograf.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBoxSilGun_video.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void textBoxSilGun_araBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //Barkod'a göre arama yapar.
        private void textBoxSilGun_araBarkod_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSilGun_araBarkod.Text.Length != 0 && textBoxSilGun_araBarkod.Text != "Barkoda göre ara")
            {
                string barkod = textBoxSilGun_araBarkod.Text;
                List<List<string>> bulunanBarkodlar = new List<List<string>>();
                for (int i = 0; i < this.tempListView.Count; i++) //Veritabanındaki kayıtlar kadar dön.
                    if (this.tempListView[i][0].IndexOf(barkod) != -1) //Aranan barkod numarası varsa listeye ekle.
                        bulunanBarkodlar.Add(this.tempListView[i]);
                ListViewUpdate(bulunanBarkodlar); //İçinde aranan barkod olan listeyi ekrana yazdır.
            }
            else
                ListViewUpdate(this.tempListView);
        }

        //Ad'a göre arama yapar.
        private void textBoxSilGun_araAd_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSilGun_araAd.Text.Length != 0 && textBoxSilGun_araAd.Text != "Ada göre ara")
            {
                string ad = textBoxSilGun_araAd.Text.ToLower();
                List<List<string>> bulunanAdlar = new List<List<string>>();
                for (int i = 0; i < this.tempListView.Count; i++) //Veritabanındaki kayıtlar kadar dön.
                    if (this.tempListView[i][1].ToLower().IndexOf(ad) != -1) //Aranan ad varsa listeye ekle.
                        bulunanAdlar.Add(this.tempListView[i]);
                ListViewUpdate(bulunanAdlar); //İçinde aranan barkod olan listeyi ekrana yazdır.
            }
            else
                ListViewUpdate(this.tempListView);
        }

        private void textBoxSilGun_araBarkod_Enter(object sender, EventArgs e)
        {
            textBoxSilGun_araBarkod.Text = "";
        }
        private void textBoxSilGun_araAd_Enter(object sender, EventArgs e)
        {
            textBoxSilGun_araAd.Text = "";
        }
        private void textBoxSilGun_araBarkod_Leave(object sender, EventArgs e)
        {
            textBoxSilGun_araBarkod.Text = "Barkoda göre ara";
        }
        private void textBoxSilGun_araAd_Leave(object sender, EventArgs e)
        {
            textBoxSilGun_araAd.Text = "Ada göre ara";
        }

        //Events
        //END







        //START
        //Variables
        string dbAddress; //Database adresini saklamak için oluşturuldu.
        string tempBarkod = ""; //Seçilen kaydın barkodunu tutmak için oluşturuldu.
        bool tempFotografAdres = false;
        bool tempVideoAdres = false;
        List<List<string>> tempListView;
        //Variables
        //END







        //START
        //Methods



        /// <summary>
        /// groupBox'lar arasında geçiş yap.
        /// </summary>
        /// 
        //Kayıt Ekle gropBox'ını görünür yapar.
        private void toolStripMenuItem_Ekle_Click(object sender, EventArgs e)
        {
            if (!groupBox_Ekle.Visible)
            {
                groupBox_Sil_Guncelle.Visible = false;
                groupBox_Ekle.Visible = true;
            }
        }

        //Kayıt Sil/Güncelle gropBox'ını görünür yapar.
        private void toolStripMenuItem_SilGun_Click(object sender, EventArgs e)
        {
            if (!groupBox_Sil_Guncelle.Visible)
            {
                groupBox_Ekle.Visible = false;
                groupBox_Sil_Guncelle.Visible = true;
                TableUpdate();
            }
        }



        /// <summary>
        /// groupBox --> Kayıt Ekle işlemleri.
        /// </summary>
        /// 

        //Veritabanına yeni kayıt ekler.
        private void buttonEkle_ekle_Click(object sender, EventArgs e)
        {
            if (this.Kontrol_Ekle())//Girdiler doğruysa devam et. (barkod, ad)
            {
                db database = new db(this.dbAddress);
                if (database.connControl())
                {
                    string komut = "SELECT barkod FROM ilaclar WHERE barkod='" + this.textBoxEkle_barkod.Text + "'";
                    database = new db(this.dbAddress);
                    //Girilen barkod database de zaten kayıtlı mı? Kontrol et.
                    if (database.Query(komut).Count != 0)
                        MessageBox.Show("Bu barkod zaten var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Daha önce girilen barkoda ait hiç kayıt girilmemişse kayıt et.
                    else
                    {
                        komut = "INSERT INTO ilaclar(barkod,ad,fotograf,video) VALUES ("
                                                                                        + "'" + this.textBoxEkle_barkod.Text + "'"
                                                                                        + ",'" + this.textBoxEkle_ad.Text + "'"
                                                                                        + ",'" + this.NameReplaceEkle_fotograf() + "'"
                                                                                        + ",'" + this.NameReplaceEkle_video() + "'"
                                                                                        + ")";
                        if (database.NonQuery(komut)) //Kayıt başarıyla eklendiyse devam et.
                        {
                            this.FileCopy_Ekle(); //Fotoğraf ve videoyu belirtilen dizine kopyala.
                            MessageBox.Show("Kayıt başarıyla eklendi.", "Kayıt Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.textBoxEkle_barkod.Text = "";
                            this.textBoxEkle_ad.Text = "";
                            this.textBoxEkle_fotograf.Text = "";
                            this.textBoxEkle_video.Text = "";
                            this.pictureBoxSecEkle_fotograf.Image = null;
                            this.textBoxEkle_barkod.Focus();
                            this.panel1.BackColor = Color.Transparent;
                            this.panel2.BackColor = Color.Transparent;
                        }
                        else
                            MessageBox.Show(database.Error.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(database.Error.Message, "Veritabanı Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //this.Kontrol() den dönen değer false ise bu bloğa gir.
            {
                textBoxEkle_barkod_Leave(new object(), new EventArgs());
                textBoxEkle_ad_Leave(new object(), new EventArgs());
            }
        }

        //Girdileri kontrol et.
        private bool Kontrol_Ekle()
        {
            bool sonuc = true;
            if (textBoxEkle_barkod.Text.Length != 13)
                sonuc = false;
            if (textBoxEkle_ad.Text.Length == 0)
                sonuc = false;

            return sonuc;
        }

        //Kayıt Ekle --> Veritabanına eklenecek fotoğrafı seçer.
        private void buttonSecEkle_fotograf_Click(object sender, EventArgs e)
        {
            this.openFileDialog_fotograf.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
            this.openFileDialog_fotograf.Title = "Fotoğraf Seç";
            if (this.openFileDialog_fotograf.ShowDialog() == DialogResult.OK)
            {
                this.textBoxEkle_fotograf.Text = this.openFileDialog_fotograf.FileNames[0];
                this.pictureBoxSecEkle_fotograf.Image = new Bitmap(this.openFileDialog_fotograf.FileNames[0]);
            }
        }

        //Kayıt Ekle --> Veritabanına eklenecek videoyu seçer.
        private void buttonSecEkle_video_Click(object sender, EventArgs e)
        {
            this.openFileDialog_video.Filter = "mp4 files (*.mp4)|*.mp4|avi files (*.avi)|*.avi|mkv files (*.mkv)|*.mkv|All files (*.*)|*.*";
            this.openFileDialog_video.Title = "Fotoğraf Seç";
            if (this.openFileDialog_video.ShowDialog() == DialogResult.OK)
            {
                this.textBoxEkle_video.Text = this.openFileDialog_video.FileNames[0];
            }
        }

        //Fotoğraf ve videoyu belirtilen dizine kopyala.
        private void FileCopy_Ekle()
        {
            if (this.textBoxEkle_fotograf.Text != "")//Fotoğraf bilgisi mevcut ise
            {
                try
                {
                    if (!Directory.Exists(Application.StartupPath + @"\fotograflar"))//Klasör mevcut değilse oluştur
                        Directory.CreateDirectory(Application.StartupPath + @"\fotograflar");

                    string tempAddress = this.textBoxEkle_fotograf.Text;
                    this.textBoxEkle_fotograf.Text = @"\fotograflar\" + textBoxEkle_ad.Text.ToLower() + this.textBoxEkle_fotograf.Text.Substring(this.textBoxEkle_fotograf.Text.LastIndexOf('.'));
                    string fotograf = Application.StartupPath + this.textBoxEkle_fotograf.Text;
                    if (!File.Exists(fotograf))
                        File.Copy(tempAddress, fotograf);
                    else
                    {
                        File.Delete(fotograf);
                        File.Copy(tempAddress, fotograf);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (this.textBoxEkle_video.Text != "")//Video bilgisi mevcut ise
            {
                try
                {
                    if (!Directory.Exists(Application.StartupPath + @"\videolar"))//Klasör mevcut değilse oluştur
                        Directory.CreateDirectory(Application.StartupPath + @"\videolar");

                    string tempAddress = this.textBoxEkle_video.Text;
                    this.textBoxEkle_video.Text = @"\videolar\" + textBoxEkle_ad.Text.ToLower() + this.textBoxEkle_video.Text.Substring(this.textBoxEkle_video.Text.LastIndexOf('.'));
                    string video = Application.StartupPath + this.textBoxEkle_video.Text;
                    if (!File.Exists(video))
                        File.Copy(tempAddress, video);
                    else
                    {
                        File.Delete(video);
                        File.Copy(tempAddress, video);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Veritabanı kayıtı için kayıt edilecek fotoğraf adresini dönderir.
        private string NameReplaceEkle_fotograf()
        {
            if (this.textBoxEkle_fotograf.Text != "")
            {
                string result = @"\fotograflar\" + textBoxEkle_ad.Text.ToLower() + this.textBoxEkle_fotograf.Text.Substring(this.textBoxEkle_fotograf.Text.LastIndexOf('.'));
                return result;
            }
            else
                return "";
        }
        //Veritabanı kayıtı için kayıt edilecek video adresini dönderir.
        private string NameReplaceEkle_video()
        {
            if (this.textBoxEkle_video.Text != "")
            {
                string result = @"\videolar\" + textBoxEkle_ad.Text.ToLower() + this.textBoxEkle_video.Text.Substring(this.textBoxEkle_video.Text.LastIndexOf('.'));
                return result;
            }
            else
                return "";
        }


        /// <summary>
        /// groupBox --> Kayıt Sil/Güncelle işlemleri.
        /// </summary>
        /// 
        //Veritabanından seçilen kaydı siler.
        private void buttonSilGun_Sil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)//listView1'de seçilen kayıt varsa devam et.
            {
                string barkod = listView1.SelectedItems[0].SubItems[0].Text;
                string fotograf_adi = listView1.SelectedItems[0].SubItems[2].Text;
                string video_adi = listView1.SelectedItems[0].SubItems[3].Text;
                db database = new db(this.dbAddress);
                if (DialogResult.Yes == MessageBox.Show(barkod + " numaralı barkod silinmek üzere. Silmek istiyor musunuz?", "Barkod Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) //Seçilen kaydın silinmesi onaylandıysa devam et.
                {
                    if (database.connControl())//Veritabanına bağlantı sağlanabiliyor mu?
                    {
                        try
                        {
                            string komut = "DELETE FROM ilaclar WHERE barkod=" + barkod;
                            database = new db(this.dbAddress);
                            if (database.NonQuery(komut))//Kayıt başarıyla silindi mi?
                            {
                                MessageBox.Show(barkod + " numaralı barkod başarıyla silindi.", "Barkod Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.textBoxSilGun_araBarkod.Text = "";
                                this.textBoxSilGun_araAd.Text = "";
                                TableUpdate();
                                if (fotograf_adi != "")
                                {
                                    string fotograf = Application.StartupPath + fotograf_adi;
                                    if (File.Exists(fotograf))
                                        File.Delete(fotograf);
                                }
                                if (video_adi != "")
                                {
                                    string video = Application.StartupPath + video_adi;
                                    if (File.Exists(video))
                                        File.Delete(video);
                                }
                            }
                            else
                                MessageBox.Show("Seçilen kayıt silinirken hata oluştu:\n" + database.Error, "Kayıt Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show(database.Error.Message, "Veritabanı Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        //Veritabanındaki kaydı girilen bilgiler ile günceller.
        private void buttonSilGun_Guncelle_Click(object sender, EventArgs e)
        {
            if (this.Kontrol_SilGun())//Girdiler doğruysa devam et. (barkod, ad)
            {
                if (DialogResult.Yes == MessageBox.Show(this.tempBarkod + " numaralı barkod güncelleniyor. Güncellensin mi?", "Kayıt Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    db database = new db(this.dbAddress);
                    if (database.connControl())//Database bağlantısı başarılı mı?
                    {
                        string temp_fotograf = textBoxSilGun_fotograf.Text;
                        string yeni_fotograf = this.NameReplace_SilGun_fotograf();
                        string temp_video = textBoxSilGun_video.Text;
                        string yeni_video = this.NameReplace_SilGun_video();
                        string komut = "UPDATE ilaclar SET barkod='" + textBoxSilGun_barkod.Text + "'"
                                                      + ", ad='" + textBoxSilGun_ad.Text + "'"
                                                      + ", fotograf='" + yeni_fotograf + "'"
                                                      + ", video='" + yeni_video + "'"
                                    + " WHERE barkod=" + this.tempBarkod;
                        database = new db(this.dbAddress);
                        if (database.NonQuery(komut)) //Kayıt başarıyla eklendiyse devam et.
                        {
                            this.FileCopy_SilGun(); //Fotoğraf ve videoyu belirtilen dizine kopyala.
                            if (File.Exists(Application.StartupPath + temp_fotograf))//Eski fotoğraf adını yeni fotoğraf adıyla değiştir.
                                File.Move(Application.StartupPath + temp_fotograf, Application.StartupPath + yeni_fotograf);
                            if (File.Exists(Application.StartupPath + temp_video))//Eski video adını yeni video adıyla değiştir.
                                File.Move(Application.StartupPath + temp_video, Application.StartupPath + yeni_video);
                            MessageBox.Show("Kayıt başarıyla güncellendi.", "Kayıt Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.textBoxSilGun_araBarkod.Text = "";
                            this.textBoxSilGun_araAd.Text = "";
                            TableUpdate();
                            this.textBoxSilGun_barkod.Text = "";
                            this.textBoxSilGun_ad.Text = "";
                            this.textBoxSilGun_fotograf.Text = "";
                            this.textBoxSilGun_video.Text = "";
                            this.panel1.BackColor = Color.Transparent;
                            this.panel2.BackColor = Color.Transparent;
                            this.tempBarkod = "";
                            this.tempFotografAdres = false;
                            this.tempVideoAdres = false;
                        }
                        else
                            MessageBox.Show(database.Error.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show(database.Error.Message, "Veritabanı Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //this.Kontrol() den dönen değer false ise bu bloğa gir.
            {
                textBoxSilGun_barkod_Leave(new object(), new EventArgs());
                textBoxSilGun_ad_Leave(new object(), new EventArgs());
            }
        }

        //SilGun --> Veritabanına eklenecek fotoğrafı seçer.
        private void buttonSecSilGun_fotograf_Click(object sender, EventArgs e)
        {
            this.openFileDialog_fotograf.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
            this.openFileDialog_fotograf.Title = "Fotoğraf Seç";
            if (this.openFileDialog_fotograf.ShowDialog() == DialogResult.OK)
            {
                this.textBoxSilGun_fotograf.Text = this.openFileDialog_fotograf.FileNames[0];
                this.tempFotografAdres = true;
            }
        }
        //SilGun --> Veritabanına eklenecek videoyu seçer.
        private void buttonSecSilGun_video_Click(object sender, EventArgs e)
        {
            this.openFileDialog_video.Filter = "mp4 files (*.mp4)|*.mp4|avi files (*.avi)|*.avi|mkv files (*.mkv)|*.mkv|All files (*.*)|*.*";
            this.openFileDialog_video.Title = "Fotoğraf Seç";
            if (this.openFileDialog_video.ShowDialog() == DialogResult.OK)
            {
                this.textBoxSilGun_video.Text = this.openFileDialog_video.FileNames[0];
                this.tempVideoAdres = true;
            }
        }

        //Girdileri kontrol et.
        private bool Kontrol_SilGun()
        {
            bool sonuc = true;
            if (textBoxSilGun_barkod.Text.Length != 13)
                sonuc = false;
            if (textBoxSilGun_ad.Text.Length == 0)
                sonuc = false;

            return sonuc;
        }

        //Fotoğraf ve videoyu belirtilen dizine kopyala.
        private void FileCopy_SilGun()
        {
            if (this.textBoxSilGun_fotograf.Text != "" && this.tempFotografAdres)//Fotoğraf bilgisi mevcut ise ve fotoğraf bilgisi değiştirilmiş ise
            {
                try
                {
                    if (!Directory.Exists(Application.StartupPath + @"\fotograflar"))//Klasör mevcut değilse oluştur
                        Directory.CreateDirectory(Application.StartupPath + @"\fotograflar");

                    string tempAddress = this.textBoxSilGun_fotograf.Text;
                    this.textBoxSilGun_fotograf.Text = @"\fotograflar\" + textBoxSilGun_ad.Text.ToLower() + this.textBoxSilGun_fotograf.Text.Substring(this.textBoxSilGun_fotograf.Text.LastIndexOf('.'));
                    if (!File.Exists(Application.StartupPath + this.textBoxSilGun_fotograf.Text))
                        File.Copy(tempAddress, Application.StartupPath + this.textBoxSilGun_fotograf.Text);
                    else
                    {
                        File.Delete(Application.StartupPath + this.textBoxSilGun_fotograf.Text);
                        File.Copy(tempAddress, Application.StartupPath + this.textBoxSilGun_fotograf.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (this.textBoxSilGun_video.Text != "" && this.tempVideoAdres)//Video bilgisi mevcut ise ve fotoğraf bilgisi değiştirilmiş ise
            {
                try
                {
                    if (!Directory.Exists(Application.StartupPath + @"\videolar"))//Klasör mevcut değilse oluştur
                        Directory.CreateDirectory(Application.StartupPath + @"\videolar");

                    string tempAddress = this.textBoxSilGun_video.Text;
                    this.textBoxSilGun_video.Text = @"\videolar\" + textBoxSilGun_ad.Text.ToLower() + this.textBoxSilGun_video.Text.Substring(this.textBoxSilGun_video.Text.LastIndexOf('.'));
                    if (!File.Exists(Application.StartupPath + this.textBoxEkle_video.Text))
                        File.Copy(tempAddress, Application.StartupPath + this.textBoxEkle_video.Text);
                    else
                    {
                        File.Delete(Application.StartupPath + this.textBoxEkle_video.Text);
                        File.Copy(tempAddress, Application.StartupPath + this.textBoxEkle_video.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Veritabanı kayıtı için kayıt edilecek fotoğraf adresini dönderir.
        private string NameReplace_SilGun_fotograf()
        {
            if (textBoxSilGun_fotograf.Text != "")
            {
                string result = @"\fotograflar\" + textBoxSilGun_ad.Text.ToLower() + this.textBoxSilGun_fotograf.Text.Substring(this.textBoxSilGun_fotograf.Text.LastIndexOf('.'));
                return result;
            }
            else
                return "";
        }
        //Veritabanı kayıtı için kayıt edilecek video adresini dönderir.
        private string NameReplace_SilGun_video()
        {
            if (textBoxSilGun_video.Text != "")
            {
                string result = @"\videolar\" + textBoxSilGun_ad.Text.ToLower() + this.textBoxSilGun_video.Text.Substring(this.textBoxSilGun_video.Text.LastIndexOf('.'));
                return result;
            }
            else
                return "";
        }

        //Seçilen kaydın veritabanındaki kayıtlı fotoğrafını açar.
        private void buttonGoster_fotograf_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                if (listView1.SelectedItems[0].SubItems[2].Text != "")
                {
                    string fotograf = Application.StartupPath + listView1.SelectedItems[0].SubItems[2].Text;
                    if (File.Exists(fotograf))
                        System.Diagnostics.Process.Start(fotograf);
                    else
                        MessageBox.Show("Fotoğraf bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        //Seçilen kaydın veritabanındaki kayıtlı videosunu açar.
        private void buttonGoster_video_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                if (listView1.SelectedItems[0].SubItems[3].Text != "")
                {
                    string video = Application.StartupPath + listView1.SelectedItems[0].SubItems[3].Text;
                    if (File.Exists(video))
                        System.Diagnostics.Process.Start(video);
                    else
                        MessageBox.Show("Video bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        //Parametreden gelen verileri listView'e ekle.
        private void ListViewUpdate(List<List<string>> printItems)
        {
            listView1.Items.Clear();
            foreach (var item in printItems)
                listView1.Items.Add(new ListViewItem(new string[] { item[0], item[1], item[2], item[3] }));
        }

        //groupBox --> Kayıt Sil/Güncelle listView1 tablosunu günceller.
        private void TableUpdate()
        {
            db database = new db(this.dbAddress);
            try
            {
                this.tempListView = database.Query("SELECT * FROM ilaclar");
                ListViewUpdate(this.tempListView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        //Methods
        //END
    }
}
