namespace eczane_barkod_sistemi
{
    partial class Form_barkod_oku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_barkod = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_kamera = new System.Windows.Forms.Label();
            this.button_yenile = new System.Windows.Forms.Button();
            this.button_kapat = new System.Windows.Forms.Button();
            this.timer_BarcodeRead = new System.Windows.Forms.Timer(this.components);
            this.button_BarkodTara = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox_video = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_video)).BeginInit();
            this.SuspendLayout();
            // 
            // label_barkod
            // 
            this.label_barkod.AutoSize = true;
            this.label_barkod.BackColor = System.Drawing.Color.Transparent;
            this.label_barkod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_barkod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_barkod.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_barkod.Location = new System.Drawing.Point(201, 466);
            this.label_barkod.Name = "label_barkod";
            this.label_barkod.Size = new System.Drawing.Size(58, 16);
            this.label_barkod.TabIndex = 2;
            this.label_barkod.Text = "Barkod:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(265, 459);
            this.textBox1.MaxLength = 13;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Honeydew;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(76, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_kamera
            // 
            this.label_kamera.AutoSize = true;
            this.label_kamera.BackColor = System.Drawing.Color.Transparent;
            this.label_kamera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_kamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_kamera.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_kamera.Location = new System.Drawing.Point(12, 19);
            this.label_kamera.Name = "label_kamera";
            this.label_kamera.Size = new System.Drawing.Size(58, 16);
            this.label_kamera.TabIndex = 5;
            this.label_kamera.Text = "Kamera:";
            // 
            // button_yenile
            // 
            this.button_yenile.BackColor = System.Drawing.Color.Transparent;
            this.button_yenile.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.barkod_oku_circling_arrows;
            this.button_yenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_yenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_yenile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_yenile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_yenile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_yenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_yenile.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_yenile.Location = new System.Drawing.Point(621, 6);
            this.button_yenile.Name = "button_yenile";
            this.button_yenile.Size = new System.Drawing.Size(35, 35);
            this.button_yenile.TabIndex = 8;
            this.button_yenile.UseVisualStyleBackColor = false;
            this.button_yenile.Click += new System.EventHandler(this.button_yenile_Click);
            // 
            // button_kapat
            // 
            this.button_kapat.BackColor = System.Drawing.Color.Transparent;
            this.button_kapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_kapat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_kapat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_kapat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_kapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_kapat.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kapat.Location = new System.Drawing.Point(662, 6);
            this.button_kapat.Name = "button_kapat";
            this.button_kapat.Size = new System.Drawing.Size(35, 35);
            this.button_kapat.TabIndex = 10;
            this.button_kapat.Text = "X";
            this.button_kapat.UseVisualStyleBackColor = false;
            this.button_kapat.Click += new System.EventHandler(this.button_kapat_Click);
            // 
            // timer_BarcodeRead
            // 
            this.timer_BarcodeRead.Interval = 550;
            this.timer_BarcodeRead.Tick += new System.EventHandler(this.timer_BarcodeRead_Tick);
            // 
            // button_BarkodTara
            // 
            this.button_BarkodTara.BackColor = System.Drawing.Color.Transparent;
            this.button_BarkodTara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_BarkodTara.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_BarkodTara.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_BarkodTara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button_BarkodTara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BarkodTara.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_BarkodTara.Location = new System.Drawing.Point(292, 491);
            this.button_BarkodTara.Name = "button_BarkodTara";
            this.button_BarkodTara.Size = new System.Drawing.Size(101, 40);
            this.button_BarkodTara.TabIndex = 12;
            this.button_BarkodTara.Text = "Barkod Tara";
            this.button_BarkodTara.UseVisualStyleBackColor = false;
            this.button_BarkodTara.Click += new System.EventHandler(this.button_BarkodTara_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(300, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 10);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(300, 200);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox5.Location = new System.Drawing.Point(340, 200);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(15, 10);
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox6.Location = new System.Drawing.Point(370, 200);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 10);
            this.pictureBox6.TabIndex = 18;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox7.Location = new System.Drawing.Point(300, 240);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 15);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox8.Location = new System.Drawing.Point(300, 270);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(10, 25);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 20;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox9.Location = new System.Drawing.Point(370, 285);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(25, 10);
            this.pictureBox9.TabIndex = 23;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox10.Location = new System.Drawing.Point(340, 285);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(15, 10);
            this.pictureBox10.TabIndex = 22;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox11.Location = new System.Drawing.Point(300, 285);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(25, 10);
            this.pictureBox11.TabIndex = 21;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox12.Location = new System.Drawing.Point(385, 270);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(10, 25);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 26;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox13.Location = new System.Drawing.Point(385, 240);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(10, 15);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 25;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox14.Location = new System.Drawing.Point(385, 200);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(10, 25);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox_video
            // 
            this.pictureBox_video.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_video.Location = new System.Drawing.Point(63, 70);
            this.pictureBox_video.Name = "pictureBox_video";
            this.pictureBox_video.Size = new System.Drawing.Size(583, 368);
            this.pictureBox_video.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_video.TabIndex = 6;
            this.pictureBox_video.TabStop = false;
            // 
            // Form_barkod_oku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(709, 543);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_BarkodTara);
            this.Controls.Add(this.button_kapat);
            this.Controls.Add(this.button_yenile);
            this.Controls.Add(this.pictureBox_video);
            this.Controls.Add(this.label_kamera);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_barkod);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_barkod_oku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eczane Barkod Sistemi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_video)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_barkod;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_kamera;
        private System.Windows.Forms.Button button_yenile;
        private System.Windows.Forms.Button button_kapat;
        private System.Windows.Forms.Timer timer_BarcodeRead;
        private System.Windows.Forms.Button button_BarkodTara;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox_video;
    }
}

