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
    public partial class Siparis : Form
    {
        public Siparis()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;


        private void Siparis_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDel, "Silme İşlemi Yapılırken Müşteri ve Sipariş ID'leri ve Ürün Kodu Girilmesi Gerekmektedir.");
            toolTip1.ToolTipTitle = "Silme İşlemi Başarılı Olması İçin";
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.InitialDelay = 0;
            toolTip1.IsBalloon = true;
            cmbCurrent.Items.Add("$");
            cmbCurrent.Items.Add("€");
            cmbCurrent.Items.Add("₺");
            cmbCurrent.Items.Add("IRR");
            toolTip2.SetToolTip(txtOrderID, "Silme Ve Güncelleme İşlemlerinde Doldurulmalıdır.");
            toolTip2.ToolTipTitle = "Silme İşlemi Yapılırken";
            toolTip2.ToolTipIcon = ToolTipIcon.Warning;
            toolTip2.InitialDelay = 0;
            toolTip2.IsBalloon = true;
            Doldur();
        }
        private void Doldur()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd = new SqlCommand("Select*from Orders", conn);
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

            if (txtProductCode.Text != "" && txtOnOrder.Text != "" && txtUnitPrice.Text != "" && txtCustomerID.Text != "" && txtDiscount.Text != "")
            {
                cmd = new SqlCommand("Insert into Orders (ProductCode,InStock,UnitsOnOrder,UnitPrice,[Current],CustomerID,ShipperName,SendingAdress,Direction,EstimatedTimeToArrival(Days),Discount) " +
                "values (@oID,@pCode,@instock,@uiorder,@unitprice,@curr,@cID,@shiName,@sending,@direc,@tahmini,@discount)", conn);

                cmd.Parameters.AddWithValue("@pCode", txtProductCode.Text);
                cmd.Parameters.AddWithValue("@instock", txtInStock.Text);
                cmd.Parameters.AddWithValue("@uiorder", txtOnOrder.Text);
                cmd.Parameters.AddWithValue("@unitprice", txtUnitPrice.Text);
                cmd.Parameters.AddWithValue("@curr", cmbCurrent.Text);
                cmd.Parameters.AddWithValue("@cID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@shiName", txtShipper.Text);
                cmd.Parameters.AddWithValue("@sending", txtSending.Text);
                cmd.Parameters.AddWithValue("@direc", txtDirection.Text);
                cmd.Parameters.AddWithValue("@tahmini", txtVaris.Text);
                cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Sipariş Ekleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Sipariş Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            conn.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtOrderID.Text != "")
            {
                cmd = new SqlCommand("Delete from Orders where OrderID=@oID", conn);
                cmd.Parameters.AddWithValue("@oID", txtOrderID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Sipariş Silme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Sipariş Silme Gerçekleştirilemedi.");

                Doldur();
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken Sipariş ID'si Boş Bırakılmamalıdır.");

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtOrderID.Text != "" && txtProductCode.Text != "" && txtCustomerID.Text != "")
            {
                cmd = new SqlCommand("Update Orders set InStock=@instock and UnitsOnOrder=@uiorder and UnitPrice=@unitprice and [Current]=@curr and ShipperName=@shiName and SendingAdress=@sending and Direction=@direc and EstimatedTimeToArrival(Days)=@tahmini and Discount=@discount where OrderID=oID and ProductCode=@pCode and CustomerID=@cID", conn);
                cmd.Parameters.AddWithValue("@oID", txtOrderID.Text);
                cmd.Parameters.AddWithValue("@pCode", txtProductCode.Text);
                cmd.Parameters.AddWithValue("@instock", txtInStock.Text);
                cmd.Parameters.AddWithValue("@uiorder", txtOnOrder.Text);
                cmd.Parameters.AddWithValue("@unitprice", txtUnitPrice.Text);
                cmd.Parameters.AddWithValue("@curr", cmbCurrent.Text);
                cmd.Parameters.AddWithValue("@cID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@shiName", txtShipper.Text);
                cmd.Parameters.AddWithValue("@sending", txtSending.Text);
                cmd.Parameters.AddWithValue("@direc", txtDirection.Text);
                cmd.Parameters.AddWithValue("@tahmini", txtVaris.Text);
                cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Sipariş Bilgileri Güncelleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Sipariş Bilgileri Güncelleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("Ürün Kodu, Sipariş ve Müşteri ID'si Girilmelidir.");
            Doldur();
            conn.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
