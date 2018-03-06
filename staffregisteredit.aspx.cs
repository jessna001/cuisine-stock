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
    public partial class staffregisteredit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();



        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
        private void BindGrid()
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();

            string sql = "select * from StaffRegister where StaffName like '%" + txtuserid.Text.Trim() + "%'";
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            gvsearch.DataSource = dt;
            gvsearch.DataBind();
            con.Close();
        }

        protected void gvsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}