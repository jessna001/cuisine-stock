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
    public partial class staffregister : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        void clear()
        {

            txtname.Text = "";
            txtaddress.Text = "";

            txtmobile.Text = "";
            txtaadharno.Text = "";
            txtuid.Text = "";
            txtmonthsalary.Text = "";
            txtpassword.Text = "";
            txtcpassword.Text = "";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();

        }





        protected void btnsave_Click(object sender, EventArgs e)
        {


           
           String ins = "insert into StaffRegister values ('" + txtname.Text + "','" + txtaddress.Text + "','" + txtuid.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtaadharno.Text + "','" + txtmobile.Text + "','" + ddldesignation.SelectedValue + "','" + txtmonthsalary.Text + "','" + txtpassword.Text + "' )";
           SqlCommand cmd = new SqlCommand(ins, con);
           cmd.ExecuteNonQuery();
            String inss = "insert into login values ('" + txtuid.Text + "','" + txtpassword.Text + "','STAFF' )";
            SqlCommand cmdd = new SqlCommand(inss, con);
            cmdd.ExecuteNonQuery();
            clear();





        }

        protected void ddldesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}