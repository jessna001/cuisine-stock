using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


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
        Double tamt = 0.0;
        Double tqty = 0.0;
        Double ttamount = 0.0;
        Double cgst;
        Double sgst;
        SqlCommand cmd;
        String id = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            con.ConnectionString = @" Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            if (!IsPostBack)
            {
                con.Open();
                string com = "select ItemDescr,Rate from TodaysMenu";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Close();
                SetInitialRow();
                GenerateAutoID();

                


            }
        }
        public void getcon()
        {
            con.ConnectionString = @" Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();
        }
        public void GenerateAutoID()
        {
            getcon();
            string str = "select count(CustId)from BillDetails1";
            SqlCommand cmd = new SqlCommand(str, con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
             con.Close();
            i++;
            lblno.Text = id + i.ToString();
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for TextBox value    
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for TextBox value
           //dt.Columns.Add(new DataColumn("Column6", typeof(string)));//for TextBox value

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
           // dr["Column6"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            //After binding the gridview, we can then extract and fill the DropDownList with Data   
            DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[1].FindControl("DropDownList1");
            //Label lbl1 = (Label)Gridview1.Rows[0].Cells[3].FindControl("Label1");
            // DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[2].FindControl("DropDownList2");
            //  FillDropDownList(ddl1);  
            // FillDropDownList(ddl2);  
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txtrate");
                        TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("txtqty");
                        TextBox box4 = (TextBox)Gridview1.Rows[i].Cells[5].FindControl("txtamount");
                        //TextBox box5 = (TextBox)GridV1.Rows[i].Cells[6].FindControl("TextBox5");

                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                        //Label lbl1 = (Label)Gridview1.Rows[rowIndex].Cells[3].FindControl("Label1");
                        // DropDownList ddl2 = (DropDownList)GridV1.Rows[rowIndex].Cells[2].FindControl("DropDownList2");

                        //Fill the DropDownList with Data   
                        // FillDropDownList(ddl1);
                        // FillDropDownList(ddl2);

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column2"].ToString();
                            box2.Text = dt.Rows[i]["Column3"].ToString();
                            box3.Text = dt.Rows[i]["Column4"].ToString();
                            box4.Text = dt.Rows[i]["Column5"].ToString();
                           // box5.Text = dt.Rows[i]["Column6"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                            ddl1.ClearSelection();
                            ddl1.Items.FindByText(dt.Rows[i]["Column1"].ToString()).Selected = true;

                            //ddl2.ClearSelection();
                            //ddl2.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;

                        }

                        rowIndex++;
                    }
                }
            }
        }
        private void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txtrate");
                        TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("txtqty");
                        TextBox box4 = (TextBox)Gridview1.Rows[i].Cells[5].FindControl("txtamount");
                       // TextBox box5 = (TextBox)GridV1.Rows[i].Cells[6].FindControl("TextBox5");

                        dtCurrentTable.Rows[i]["Column2"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box3.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box4.Text;
                      //  dtCurrentTable.Rows[i]["Column6"] = box5.Text;

                        //extract the DropDownList Selected Items   

                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("DropDownList1");
                        //   Label lbl1 = (Label)Gridview1.Rows[i].Cells[3].FindControl("Label1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[2].FindControl("DropDownList2");

                        // Update the DataRow with the DDL Selected Items   

                        dtCurrentTable.Rows[i]["Column1"] = ddl1.SelectedItem.Text;
                        //dtCurrentTable.Rows[i]["Column3"] = lbl1.Text;
                        //dtCurrentTable.Rows[i]["Column2"] = ddl2.SelectedItem.Text;

                    }

                    //Rebind the Grid with the current data to reflect changes   
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

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.ConnectionString = @" Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";

                con.Open();
                DropDownList ddl1itemdescr = (e.Row.FindControl("DropDownList1") as DropDownList);
                SqlCommand cmd = new SqlCommand("select * from TodaysMenu", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddl1itemdescr.DataSource = dt;


                ddl1itemdescr.DataTextField = "ItemDescr";
                ddl1itemdescr.DataValueField = "ItemDescrCode";
                ddl1itemdescr.DataBind();
                ddl1itemdescr.Items.Insert(0, new ListItem("--Select--", "0"));
                con.Close();
                // ddl1itemcode.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        protected void GridV1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.ConnectionString = @" Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";

                con.Open();
                DropDownList ddl1itemdescr = (e.Row.FindControl("DropDownList1") as DropDownList);
                SqlCommand cmd = new SqlCommand("select * from TodaysMenu", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddl1itemdescr.DataSource = dt;


                ddl1itemdescr.DataTextField = "ItemDescr";
                ddl1itemdescr.DataValueField = "ItemDescrCode";
                ddl1itemdescr.DataBind();
                ddl1itemdescr.Items.Insert(0, new ListItem("--Select--", "0"));
                con.Close();
                // ddl1itemcode.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

       

        protected void btncalculate_Click(object sender, EventArgs e)
        {
            tamt = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                TextBox trate = (TextBox)row.Cells[2].FindControl("txtrate");
                Double rate = Convert.ToDouble(trate.Text);
                TextBox tqty = (TextBox)row.Cells[3].FindControl("txtqty");
                Double qty = Convert.ToDouble(tqty.Text);
                TextBox txtamount = (TextBox)row.Cells[4].FindControl("txtamount");
                TextBox tnet = (TextBox)row.Cells[5].FindControl("txtnetamt");
                con.Open();
                SqlCommand sql = new SqlCommand("select value from settings where name='cgst'", con);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cgst = Convert.ToDouble(dt.Rows[0][0].ToString());
                sgst = Convert.ToDouble(dt.Rows[0][0].ToString());
                Double total = Convert.ToDouble(dt.Rows[0][0].ToString());
                Double amt = rate * qty;
                txtamount.Text = amt.ToString();
                tamt = tamt + amt;
                //ttamount = ttamount + amt;
                TextBox txtItemDescrCode = (TextBox)Gridview1.FindControl("TextBox1");
                SqlCommand cmd = new SqlCommand("insert into BillDetails (Rate,Qty) values ('" + rate + "','" + qty + "')");
                con.Close();
            }
            txtnetamt.Text = Convert.ToString(tamt);
            txtcgst.Text = Convert.ToString(cgst * tamt);
            txtsgst.Text = Convert.ToString(sgst * tamt);
            txttotal.Text = Convert.ToString((tamt + (sgst * tamt) + (cgst * tamt)));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            foreach (GridViewRow row in Gridview1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddl1 = row.FindControl("DropDownList1") as DropDownList;
                    TextBox TextBox1 = row.FindControl("TextBox1") as TextBox;
                    TextBox txtrate = row.FindControl("txtrate") as TextBox;
                    TextBox txtqty = row.FindControl("txtqty") as TextBox;
                    String str1 = Convert.ToString(ddl1.SelectedValue);
                    String ins = "insert into BillMaster(BillNo,BillDate,TotalNetAmt,GrandTotal)values ('" + lblno.Text.Trim() + "','" + txtbilldate.Text.Trim() + "','" + txtnetamt.Text.Trim() + "','" + txttotal.Text.Trim() + "' )";
                    SqlCommand cmd = new SqlCommand(ins, con);
                    String str = "insert into BillDetails1(BillNo,BillDate,CustId,ItemDescrCode,ItemDescr,Rate,Qty,NetAmt,TotalAmt)values ('" + lblno.Text.Trim() + "','" + txtbilldate.Text.Trim() + "','" + TextBox1.Text.Trim() + "','" + ddl1.SelectedItem.Value.Trim() + "','" + txtrate.Text + "','" + txtqty.Text + "','" + txtnetamt.Text + "','" + txttotal.Text + "' )";
                    SqlCommand cmd1 = new SqlCommand(ins, con);
                    
                    cmd.ExecuteNonQuery();
                }
                   
               txtbilldate.Text = "";
               txtnetamt.Text = "";
                    txtcgst.Text = "";
                    txtsgst.Text = "";
                    txttotal.Text = "";
                    //TextBox1.Text = "";
                    //txtrate.Text = "";
                    //txtqty.Text = "";
                    con.Close();
                }
            }
        

        
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow GridV1 = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropdown = (DropDownList)GridV1.FindControl("DropDownList1");
            TextBox txtItemDescrCode = (TextBox)GridV1.FindControl("TextBox1");
            TextBox txtrate = (TextBox)GridV1.FindControl("txtrate");
            //TextBox txtRate = (TextBox)GridV1.FindControl("TextBox4");
            con.Open();
            SqlCommand sql = new SqlCommand("select ItemDescrCode,Rate  from TodaysMenu where ItemDescr='" + dropdown.SelectedItem.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            adpt.Fill(dt);
            txtItemDescrCode.Text = dt.Rows[0][0].ToString();
            txtrate.Text = dt.Rows[0][1].ToString();
            //txtRate.Text = dt.Rows[0][2].ToString();
            con.Close();




            




        }
        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
}
}                            

