using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace eczane_barkod_sistemi
{
    public partial class Form_giris : Form
    {
        public Form_giris()
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
        private void Form_giris_Load(object sender, EventArgs e)
        {

        }

        //Form kapatıldığında
        private void Form_giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.form_normalGecis)
                Application.Exit();
        }

        //giriş butonuna mause giriş yaptığında
        private void button_giris_MouseEnter(object sender, EventArgs e)
        {
            this.button_giris.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_enter_enter;
        }

        //giriş butonundan mause çıkış yaptığında
        private void button_giris_MouseLeave(object sender, EventArgs e)
        {
            this.button_giris.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_enter_leave;
        }

        //çıkış butonuna mause giriş yaptığında
        private void button_cikis_MouseEnter(object sender, EventArgs e)
        {
            this.button_cikis.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_exit_enter;
        }

        //çıkış butonundan mause çıkış yaptığında
        private void button_cikis_MouseLeave(object sender, EventArgs e)
        {
            this.button_cikis.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_exit_leave;
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
        private bool form_normalGecis = false; //Form_giris kapatıldığında bu kapatma isteğini kullanıcı mı yaptı yoksa program mı yaptı kontrol altına almak için kullanıldı.
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
        private void button_giris_Click(object sender, EventArgs e)
        {
            new Form_barkod_oku().Show();
            this.form_normalGecis = true;
            this.Close();
        }

        private void button_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_database_Click(object sender, EventArgs e)
        {
            new Form_veritabani_islemleri(Application.StartupPath + @"\eczane_barkod_sistemi.db").Show();
            this.form_normalGecis = true;
            this.Close();
        }

        ///
        /// 
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
