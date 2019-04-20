using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KarmaWay
{
    public partial class KarmaWay : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public KarmaWay()
        {
            InitializeComponent();
        }
        private void KarmaWay_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=TOSHIBA\KARMAWAYINFO;Initial Catalog=KarmaWayInformation;User ID=oguz;Password=123456123fb.");
            conn.Open();
            cmd = new SqlCommand("select*from BusinessManager where UserID='" + txtBoxKulAd.Text + "' and Password='" + txtBoxSifre.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Icerik ic = new Icerik();
                ic.Show();
                MessageBox.Show("Başarılı Bir Şekilde Bağlantı Oluşturdunuz");
                this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış Girildi. Kontrol Edip Tekrar Deneyiniz!");
            conn.Close();
        }

        private void txtBoxSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnGiris.PerformClick();
                txtBoxSifre.Clear();
            }
        }   
    }
}


