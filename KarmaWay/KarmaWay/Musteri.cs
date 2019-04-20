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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtID.Text != "" && txtSirket.Text != "")
            {
                cmd = new SqlCommand("Insert into Customers (CompanyName,City,State,Country) values (@cName,@city,@state,@country)", conn);
                cmd.Parameters.AddWithValue("@cName", txtSirket.Text);
                cmd.Parameters.AddWithValue("@city", txtSehir.Text);
                cmd.Parameters.AddWithValue("@state", txtEyalet.Text);
                cmd.Parameters.AddWithValue("@country", txtUlke.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Müşteri Ekleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Müşteri Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            Doldur();

            conn.Close();
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        private void Doldur()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd = new SqlCommand("Select*from Customers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtID.Text !="")
            {
                cmd = new SqlCommand("Delete from Customers where CustomerID=@cID", conn);
                cmd.Parameters.AddWithValue("@cID", txtID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Müşteri Silme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Müşteri Silme Gerçekleştirilemedi.");

                Doldur();
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken Müşteri ID Boş Bırakılmamalıdır.");

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtID.Text != "")
            {
                cmd = new SqlCommand("Update Customers set CompanyName=@cNAme and City=@city and Country=@country and State=@state where CustomerID=@cID", conn);
                cmd.Parameters.AddWithValue("@cID", txtID.Text);
                cmd.Parameters.AddWithValue("@cName", txtSirket.Text);
                cmd.Parameters.AddWithValue("@city", txtSehir.Text);
                cmd.Parameters.AddWithValue("@state", txtEyalet.Text);
                cmd.Parameters.AddWithValue("@country", txtUlke.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Müşteri Güncelleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Müşteri Güncelleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("Müşteri ID ve Şirket Adı Girilmelidir.");
            Doldur();
            conn.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
