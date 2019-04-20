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
using System.Configuration;

namespace KarmaWay
{
    public partial class YoneticiIslemleri : Form
    {
        public YoneticiIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtAd.Text != "" && txtPass.Text != "" && txtPosition.Text != "" && txtSoyad.Text != "" && txtUser.Text != "")
            {
                cmd = new SqlCommand("Insert into BusinessManager (ManagerFirstName,ManagerLastName,ManagerPosition,UserID,Password) values (@isim,@soyisim,@pozis,@id,@pass)", conn);
                cmd.Parameters.AddWithValue("@isim", txtAd.Text);
                cmd.Parameters.AddWithValue("@soyisim", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@pozis", txtPosition.Text);
                cmd.Parameters.AddWithValue("@id", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Kullanıcı Bilgileri Ekleme Başarıyla Gerçekleşti.");
                }
                else
                    MessageBox.Show("Kullanıcı Bilgileri Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            conn.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }
    }
}
