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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtUrunKodu.Text != "" && txtUrunAdi.Text != "")
            {
                cmd = new SqlCommand("Insert into Products (ProductCode,ProductName) values (@pCode,@pName)", conn);
                cmd.Parameters.AddWithValue("@pCode", txtUrunKodu.Text);
                cmd.Parameters.AddWithValue("@pName", txtUrunAdi.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Ürün Ekleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Ürün Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            Doldur();
            conn.Close();
        }
        private void Doldur()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd = new SqlCommand("Select*from Products", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Urunler_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtUrunKodu, "Sadece Bir Kere Tanımlanabilir. İlk Verilen Kod Bir Daha Değiştirilemez.");
            toolTip1.ToolTipTitle = "ÜRÜN KODU TANIMLAMA";
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.InitialDelay = 0;
            toolTip1.IsBalloon = true;
            Doldur();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtUrunKodu.Text !="")
            {
                cmd = new SqlCommand("Delete from Products where ProductCode=@pCode", conn);
                cmd.Parameters.AddWithValue("@pCode", txtUrunKodu.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Ürün Silme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Ürün Silme Gerçekleştirilemedi.");

                Doldur();
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken Ürün Kodu Boş Bırakılmamalıdır.");

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtUrunKodu.Text != "" && txtUrunAdi.Text != "")
            {
                cmd = new SqlCommand("Update Products set ProductName=@pName where ProductCode=@pCode", conn);
                cmd.Parameters.AddWithValue("@pName", txtUrunAdi.Text);
                cmd.Parameters.AddWithValue("@pCode", txtUrunKodu.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Ürün Güncelleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Ürün Güncelleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            Doldur();
            conn.Close();
        }

        private void txtUrunKodu_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int visibletime = 6000;

            ToolTip tt = new ToolTip();
            tt.Show("Sadece Bir Kere Tanımlanabilir. İlk Verilen Kod Bir Daha Değiştirilemez.", tb,visibletime);

        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {
            txtUrunKodu.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }
    }
}
