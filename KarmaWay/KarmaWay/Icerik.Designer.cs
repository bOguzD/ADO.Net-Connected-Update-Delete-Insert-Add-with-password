namespace KarmaWay
{
    partial class Icerik
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
            this.btnMuhasebe = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.btnIslemler = new System.Windows.Forms.Button();
            this.btnUrunler = new System.Windows.Forms.Button();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMuhasebe
            // 
            this.btnMuhasebe.Location = new System.Drawing.Point(28, 91);
            this.btnMuhasebe.Name = "btnMuhasebe";
            this.btnMuhasebe.Size = new System.Drawing.Size(136, 78);
            this.btnMuhasebe.TabIndex = 3;
            this.btnMuhasebe.Text = "Muhasebe";
            this.btnMuhasebe.UseVisualStyleBackColor = true;
            this.btnMuhasebe.Click += new System.EventHandler(this.btnMuhasebe_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Location = new System.Drawing.Point(28, 175);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(136, 75);
            this.btnMusteri.TabIndex = 4;
            this.btnMusteri.Text = "Müşteri";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnSiparis
            // 
            this.btnSiparis.Location = new System.Drawing.Point(68, 256);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(216, 75);
            this.btnSiparis.TabIndex = 5;
            this.btnSiparis.Text = "Sipariş";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // btnIslemler
            // 
            this.btnIslemler.Location = new System.Drawing.Point(184, 175);
            this.btnIslemler.Name = "btnIslemler";
            this.btnIslemler.Size = new System.Drawing.Size(136, 75);
            this.btnIslemler.TabIndex = 6;
            this.btnIslemler.Text = "İşlemler";
            this.btnIslemler.UseVisualStyleBackColor = true;
            this.btnIslemler.Click += new System.EventHandler(this.btnIslemler_Click);
            // 
            // btnUrunler
            // 
            this.btnUrunler.Location = new System.Drawing.Point(184, 91);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new System.Drawing.Size(136, 78);
            this.btnUrunler.TabIndex = 7;
            this.btnUrunler.Text = "Ürünler";
            this.btnUrunler.UseVisualStyleBackColor = true;
            this.btnUrunler.Click += new System.EventHandler(this.btnUrunler_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.Location = new System.Drawing.Point(93, 337);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(169, 23);
            this.btnYonetici.TabIndex = 8;
            this.btnYonetici.Text = "Yönetici İşlemleri";
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hangi Alanda İşlem Gerçekleştirmek İstiyorsunuz?";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(127, 366);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(94, 23);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "Kullanıcı Çıkışı";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // Icerik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 397);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYonetici);
            this.Controls.Add(this.btnUrunler);
            this.Controls.Add(this.btnIslemler);
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnMuhasebe);
            this.Name = "Icerik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Icerik";
            this.Load += new System.EventHandler(this.Icerik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMuhasebe;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.Button btnIslemler;
        private System.Windows.Forms.Button btnUrunler;
        private System.Windows.Forms.Button btnYonetici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogOut;
    }
}