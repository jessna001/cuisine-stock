using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace cuisine
{
    public partial class Viewregistration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                grid();
            }
        }
        public void getcon()
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();
        }
        public void grid()
        {
            getcon();
            string str = "select * from StaffRegister";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter adr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            getcon();
            String StaffName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            String Address = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            String UserId = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label10")).Text;
            String Gender = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label11")).Text;
            String AadharNo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            String Mobile = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text;
            String Designation = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text;
            String MonthlySalary = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox6")).Text;
            String Password = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox7")).Text;
            String update = "update StaffRegister set StaffName='" + StaffName + "' , Address='" + Address + "', AadharNo='" + AadharNo + "', Mobile ='" + Mobile + "', Designation  ='" + Designation + "', MonthlySalary  ='" + MonthlySalary + "', Password='" + Password + "' where UserId='" + UserId + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            grid();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            getcon();
            String UserId = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label4")).Text;
            string del = "delete from StaffRegister where UserId=" + UserId;
            SqlCommand cmd = new SqlCommand(del, con);
            //Response.Write("<script>alert('Data Deleted Successfully! :-)')</script>");
            GridView1.Visible = true;
            cmd.ExecuteNonQuery();
            con.Close();
            grid();
        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            grid();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            
            GridView1.EditIndex = e.NewEditIndex;
            grid();
        }

       
    }
}