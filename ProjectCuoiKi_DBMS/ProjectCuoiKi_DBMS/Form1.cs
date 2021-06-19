using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCuoiKi_DBMS
{
    public partial class frmKetNoi : Form
    {
        public frmKetNoi()
        {
            InitializeComponent();
        }

        private void frmKetNoi_Load(object sender, EventArgs e)
        {
            txtUser.Enabled = false;
            txtPass.Enabled = false;
        }

        private void ckAut_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAut.Checked)
            {
                txtUser.Enabled = true;
                txtPass.Enabled = true;
            }
            else
            {
                txtUser.Enabled = false;
                txtPass.Enabled = false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnect = "";
                if (!ckAut.Checked)
                    strConnect = "Server=" + txtServer.Text + ";Database=QuanLyBanHang;Trusted_Connection=True;";
                else
                    strConnect = "Server=" + txtServer.Text + ";Database=QuanLyBanHang;User Id=" + txtUser.Text + ";Password = " + txtPass.Text + "; ";
                SqlConnection con = new SqlConnection(strConnect);

                con.Open();

                DataSet ds = new DataSet();

                MessageBox.Show("Kết nối thành công");

                con.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
