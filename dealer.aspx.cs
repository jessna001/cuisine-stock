using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace cuisine
{
    public partial class dealer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            String ins = "insert into DealerMaster values('" + txtdealername.Text + "','" + txtaddress.Text + "','" + txtemail.Text + "','" + txtmobileno.Text + "', '"+ txtopbal.Text + "')";
            SqlCommand cmd = new SqlCommand(ins, con);
            cmd.ExecuteNonQuery();

            txtdealername.Text = "";
            txtaddress.Text = "";
            txtemail.Text = "";
            txtmobileno.Text = "";
            txtopbal.Text = "";
            
        }
    }
}