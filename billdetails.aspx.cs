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
    public partial class billdetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();
        string str;
        DataRow dr = null;
        public string billdate;
        public string custid;
        public string itemdescr;
        public string rate;
        public string qty;
        public string amount;
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            //con.Open();
            if (!IsPostBack)
            {
                con.Open();
                string com = "select ItemDescr,Rate from TodaysMenu";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                

                //SqlCommand cmd = new SqlCommand("select * from TodaysMenu", con);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                //con.Close();
                //Gridview1.DataSource = dt;
                //Gridview1.DataBind();
                //Gridview1.DataSource = new object[] { null };
                //Gridview1.DataBind();
                // GridViewRow row = GridView1.FooterRow;
                // TextBox item_tb_code = (TextBox)row.FindControl("item_tb_code");
                // TextBox item_tb_desc = (TextBox)row.FindControl("item_tb_desc");
                SetInitialRow();
                
            }

        }

      
        
        protected void txtdescrcode_click(object sender, EventArgs e)
        {

            
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ItemDescrcode", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["ItemDescrcode"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["Qty"] = string.Empty;
            dr["Amount"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        box1.Text = dt.Rows[i]["ItemDescrcode"].ToString();
                        box2.Text = dt.Rows[i]["Rate"].ToString();
                        box3.Text = dt.Rows[i]["Qty"].ToString();
                        box4.Text = dt.Rows[i]["Amount"].ToString();    
                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Column1"] = box1.Text;
                        drCurrentRow["Column2"] = box2.Text;
                        drCurrentRow["Column3"] = box3.Text;
                        drCurrentRow["Column4"] = box4.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
             //Set Previous Data on Postbacks
            SetPreviousData();
        
        }


        protected void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow Gridview1 = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropdown = (DropDownList)Gridview1.FindControl("dropdown");
            con.Open();
            string sql = "select ItemDescr,Rate from TodaysMenu where ItemDescrCode like '" + dropdown.SelectedValue + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            Gridview1.DataBind();
           
                        
            //  Bind State Dropdown here

        }
    



         
       
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.Open();
                DropDownList ddl1itemdescr = (e.Row.FindControl("ddl1") as DropDownList);
                SqlCommand cmd = new SqlCommand("select * from TodaysMenu", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                ddl1itemdescr.DataSource = dt;
                ddl1itemdescr.DataTextField = "ItemDescr";
                ddl1itemdescr.DataValueField = "ItemDescrCode";
                ddl1itemdescr.DataBind();
                ddl1itemdescr.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        protected void ddl1itemdesc_SelectedIndexChanged(object sender,EventArgs e)
        {
            DropDownList ddl1 = sender as DropDownList;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                if (ddl1.ClientID == ddl1.ClientID)
                {
                    TextBox txt1 = row.FindControl("txt1") as TextBox;
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123");
                    con.Open();
                    str = "select ItemDescr from TodaysMenu where ItemDescrCode='" + ddl1.SelectedItem.Text + "'";
                    SqlCommand com = new SqlCommand();
                    com = new SqlCommand(str, con);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        txt1.Text = reader["ItemDescr"].ToString();
                    }
                    reader.Close();
                    con.Close();

                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in Gridview1.Rows)
            {
                TextBox  TextBox1 = (TextBox)row.Cells[2].FindControl("TextBox1");
                itemdescr = TextBox1.Text;
               TextBox TextBox2 = (TextBox)row.Cells[3].FindControl("TextBox2");
               rate = TextBox2.Text;
               TextBox TextBox3 = (TextBox)row.Cells[4].FindControl("Textbox3");
               qty = TextBox3 .Text;
                TextBox TextBox4 = (TextBox)row.Cells[5].FindControl("TextBox4");
                amount = TextBox4.Text;
               
               
                SqlConnection con= new SqlConnection( @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into BillDetails(BillDate,CustId,CustName,ItemDescr,Rate,Qty,Amount) values('" + billdate + "','" + custid + "','" + itemdescr + "','" + rate + "','" + qty + "','" + amount + "')");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    AddNewRowToGrid();
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btncalculate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in Gridview1.Rows)
            {
                TextBox trate = (TextBox)row.Cells[2].FindControl("txtrate");
                Double rate = Convert.ToDouble(trate.Text);
                TextBox tqty = (TextBox)row.Cells[4].FindControl("txtqty");
                Double qty = Convert.ToDouble(tqty.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into BillDetails (Rate,Qty) values ('" + rate + "','" + qty +  "')");
            }
        }

       

        
    }

}