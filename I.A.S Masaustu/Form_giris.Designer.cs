namespace eczane_barkod_sistemi
{
    partial class Form_giris
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
            this.button_giris = new System.Windows.Forms.Button();
            this.button_cikis = new System.Windows.Forms.Button();
            this.label_giris = new System.Windows.Forms.Label();
            this.label_cikis = new System.Windows.Forms.Label();
            this.button_database = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_giris
            // 
            this.button_giris.BackColor = System.Drawing.Color.Transparent;
            this.button_giris.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_enter_leave;
            this.button_giris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_giris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_giris.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_giris.FlatAppearance.BorderSize = 0;
            this.button_giris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_giris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_giris.Location = new System.Drawing.Point(122, 57);
            this.button_giris.Name = "button_giris";
            this.button_giris.Size = new System.Drawing.Size(168, 287);
            this.button_giris.TabIndex = 0;
            this.button_giris.UseVisualStyleBackColor = false;
            this.button_giris.Click += new System.EventHandler(this.button_giris_Click);
            this.button_giris.MouseEnter += new System.EventHandler(this.button_giris_MouseEnter);
            this.button_giris.MouseLeave += new System.EventHandler(this.button_giris_MouseLeave);
            // 
            // button_cikis
            // 
            this.button_cikis.BackColor = System.Drawing.Color.Transparent;
            this.button_cikis.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_exit_leave;
            this.button_cikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cikis.FlatAppearance.BorderSize = 0;
            this.button_cikis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_cikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_cikis.Location = new System.Drawing.Point(88, 406);
            this.button_cikis.Name = "button_cikis";
            this.button_cikis.Size = new System.Drawing.Size(202, 150);
            this.button_cikis.TabIndex = 1;
            this.button_cikis.UseVisualStyleBackColor = false;
            this.button_cikis.Click += new System.EventHandler(this.button_cikis_Click);
            this.button_cikis.MouseEnter += new System.EventHandler(this.button_cikis_MouseEnter);
            this.button_cikis.MouseLeave += new System.EventHandler(this.button_cikis_MouseLeave);
            // 
            // label_giris
            // 
            this.label_giris.AutoSize = true;
            this.label_giris.BackColor = System.Drawing.Color.Transparent;
            this.label_giris.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_giris.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_giris.Location = new System.Drawing.Point(170, 28);
            this.label_giris.Name = "label_giris";
            this.label_giris.Size = new System.Drawing.Size(72, 26);
            this.label_giris.TabIndex = 2;
            this.label_giris.Text = "Giriş";
            // 
            // label_cikis
            // 
            this.label_cikis.AutoSize = true;
            this.label_cikis.BackColor = System.Drawing.Color.Transparent;
            this.label_cikis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_cikis.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_cikis.Location = new System.Drawing.Point(202, 377);
            this.label_cikis.Name = "label_cikis";
            this.label_cikis.Size = new System.Drawing.Size(72, 26);
            this.label_cikis.TabIndex = 3;
            this.label_cikis.Text = "Çıkış";
            // 
            // button_database
            // 
            this.button_database.BackColor = System.Drawing.Color.Transparent;
            this.button_database.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_database;
            this.button_database.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_database.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_database.FlatAppearance.BorderSize = 0;
            this.button_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button_database.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_database.Location = new System.Drawing.Point(378, 1);
            this.button_database.Name = "button_database";
            this.button_database.Size = new System.Drawing.Size(30, 30);
            this.button_database.TabIndex = 4;
            this.button_database.UseVisualStyleBackColor = false;
            this.button_database.Click += new System.EventHandler(this.button_database_Click);
            // 
            // Form_giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eczane_barkod_sistemi.Properties.Resources.giris_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(409, 616);
            this.ControlBox = false;
            this.Controls.Add(this.button_database);
            this.Controls.Add(this.label_cikis);
            this.Controls.Add(this.label_giris);
            this.Controls.Add(this.button_cikis);
            this.Controls.Add(this.button_giris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eczane Barkod Sistemi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_giris_FormClosed);
            this.Load += new System.EventHandler(this.Form_giris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_giris;
        private System.Windows.Forms.Button button_cikis;
        private System.Windows.Forms.Label label_giris;
        private System.Windows.Forms.Label label_cikis;
        private System.Windows.Forms.Button button_database;
    }
}