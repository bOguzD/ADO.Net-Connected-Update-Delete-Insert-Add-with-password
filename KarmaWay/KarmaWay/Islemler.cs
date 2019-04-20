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
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;


        private void Islemler_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        private void Doldur()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd = new SqlCommand("Select*from Operations", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtID.Text != "" && txtName.Text != "")
            {
                cmd = new SqlCommand("Insert into Operations (OperationID,OperationName) values (@oID,@oName)", conn);
                cmd.Parameters.AddWithValue("@oID", txtID.Text);
                cmd.Parameters.AddWithValue("@oName", txtName.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("İşlem Ekleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("İşlem Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("Ekleme İşlemi Yapılırken İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            Doldur();
            conn.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtID.Text != "")
            {
                cmd = new SqlCommand("Delete from Operations where OperationID=@oID", conn);
                cmd.Parameters.AddWithValue("@oID", txtID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("İşlem Silme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("İşlem Silme Gerçekleştirilemedi.");

                Doldur();
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken İşlem ID'si Boş Bırakılmamalıdır.");

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtID.Text != "" && txtName.Text != "")
            {
                cmd = new SqlCommand("Update Operations set OperationName=@oName where OperationID=@oID", conn);
                cmd.Parameters.AddWithValue("@oName", txtName.Text);
                cmd.Parameters.AddWithValue("@oID", txtID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("İşlem Güncelleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("İşlem Güncelleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            Doldur();
            conn.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            txtID.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }
    }
}
