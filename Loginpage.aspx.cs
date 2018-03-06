using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace cuisine
{
    public partial class Loginpage : System.Web.UI.Page
    {
        int RowCount, id;
        string UserName, Password;
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();
        public DataTable dt;
        public DataSet ds = new DataSet();
     

        public SqlDataAdapter ad;
        protected void Page_Load(object sender, EventArgs e)
        {
       con.ConnectionString=@"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            
                String sel= "select * from Login where user_id = '" + txtuser_id.Text + "' and password='" + txtpswd.Text + "' ";
                
                 SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Write("Login Sucessfull");
                Response.Redirect("adminfront.aspx");

                }
                else
                {
                   Response.Write("Login Unsucessfull");
                }
            }

        protected void txtuser_id_TextChanged(object sender, EventArgs e)
        {

        }

         }
      }
     
 