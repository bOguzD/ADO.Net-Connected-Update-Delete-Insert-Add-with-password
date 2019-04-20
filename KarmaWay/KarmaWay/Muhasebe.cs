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
    public partial class Muhasebe : Form
    {
        public Muhasebe()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Tools.ConnectionString);
        SqlCommand cmd;

        private void Muhasebe_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDel, "Silme İşlemi Yapılırken İşlem ve Sipariş ID'lerinin Birden Fazla Aynı Olma Durumunda; Silme İşlemi Yerine Önce Güncelle İşlemi Yapılmalıdır.");
            toolTip1.ToolTipTitle = "Silme İşlemi Başarılı Olması İçin";
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.InitialDelay = 0;
            toolTip1.IsBalloon = true;
            cmbCurrent.Items.Add("$");
            cmbCurrent.Items.Add("€");
            cmbCurrent.Items.Add("₺");
            cmbCurrent.Items.Add("IRR");
            
            Doldur();
        }
        private void Doldur()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd = new SqlCommand("Select*from Accounting", conn);
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
            if (txtOperationID.Text != "" && txtIncome.Text != "" && txtExpense.Text != "")
            {
                cmd = new SqlCommand("Insert into Accounting (OperationID,Income,Expense,[Current],BillCode,Date,OrderID) values (@oID,@income,@expense,@curr,@bill,@date,@ordID)", conn);
                cmd.Parameters.AddWithValue("@oID", txtOperationID.Text);
                cmd.Parameters.AddWithValue("@income", txtIncome.Text);
                cmd.Parameters.AddWithValue("@expense", txtExpense.Text);
                cmd.Parameters.AddWithValue("@curr", cmbCurrent.Text);
                cmd.Parameters.AddWithValue("@bill", txtBill.Text);
                cmd.Parameters.AddWithValue("@date", maskedtxtDate.Text);
                cmd.Parameters.AddWithValue("@ordID", txtOrderID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Muhasebe Bilgileri Ekleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Muhasebe Bilgileri Ekleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("İlgili Alanlar(*) Boş Bırakılmamalıdır.");
            conn.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (txtOperationID.Text != "" && txtOrderID.Text !="")
            {
                cmd = new SqlCommand("Delete from Accounting where OperationID=@oID and OrderID=@ordID", conn);
                cmd.Parameters.AddWithValue("@oID", txtOperationID.Text);
                cmd.Parameters.AddWithValue("@ordID", txtOperationID.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Muhasebe Kaydı Silme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Muhasebe Kaydı Silme Gerçekleştirilemedi.");

                Doldur();
            }
            else
                MessageBox.Show("Silme İşlemi Yapılırken İşlem ID ve Sipariş ID Boş Bırakılmamalıdır.");

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (txtOperationID.Text != "" && txtOrderID.Text != "")
            {
                cmd = new SqlCommand("Update Accounting set Income=@income and Expense=@expense and Current=@curr and BillCode=@bill and Date=@date where OrderID=@ordID and OperationID=@oID", conn);
                cmd.Parameters.AddWithValue("@income", txtIncome.Text);
                cmd.Parameters.AddWithValue("@expense", txtExpense.Text);
                cmd.Parameters.AddWithValue("@curr", cmbCurrent.Text);
                cmd.Parameters.AddWithValue("@bill", txtBill.Text);
                cmd.Parameters.AddWithValue("@date", maskedtxtDate.Text);

                int etkilenen = 0;
                etkilenen = cmd.ExecuteNonQuery();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Muhasebe Kaydı Güncelleme Başarıyla Gerçekleşti.");
                    Doldur();
                }
                else
                    MessageBox.Show("Muhasebe Kaydı Güncelleme Gerçekleştirilemedi.");
            }
            else
                MessageBox.Show("Güncelleme İşlemi Yapılırken İşlem ID ve Sipariş ID Boş Bırakılmamalıdır.");
            Doldur();
            conn.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Icerik ic = new Icerik();
            ic.Show();
            this.Hide();
        }

        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
