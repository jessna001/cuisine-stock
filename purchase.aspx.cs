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
    public partial class purchase : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();
        String id = "";
        Double tamt = 0.0;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            if (!IsPostBack)
            {
                con.Close();
                string com = "select ItemCode,Category from ItemMaster";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
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
            string str = "select count(PurchaseNo)from PurchaseDetails";
            SqlCommand cmd = new SqlCommand(str, con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            lblinvoiceno.Text = id + i.ToString();
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
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));//for TextBox value

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            GridV1.DataSource = dt;
            GridV1.DataBind();

            //After binding the gridview, we can then extract and fill the DropDownList with Data   
            DropDownList ddl1 = (DropDownList)GridV1.Rows[0].Cells[1].FindControl("DropDownList1");
            //Label lbl1 = (Label)Gridview1.Rows[0].Cells[3].FindControl("Label1");
            // DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[2].FindControl("DropDownList2");
            //  FillDropDownList(ddl1);  
            // FillDropDownList(ddl2);  
        }


        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            //Double total = 0.0;
            //foreach (GridViewRow gr in GridV1.Rows)
            //{
            //    TextBox trate = (TextBox)gr.Cells[4].FindControl("TextBox3");
            //    Double rate = Convert.ToDouble(trate.Text);
            //    TextBox tqty = (TextBox)gr.Cells[5].FindControl("TextBox4");
            //    Double qty = Convert.ToDouble(tqty.Text);
            //    TextBox totalamt = (TextBox)gr.FindControl("TextBox5");
            //    //Double total = Convert.ToDouble(dt.Rows[0][0].ToString());
            //    Double amt = rate * qty;
            //    totalamt.Text = amt.ToString();
            //}

            //    totalamt.Text = amt.ToString();
            //    TextBox amount = (TextBox)gr.Cells[4].FindControl("TextBox5");
            //    Double amt1 = Convert.ToDouble(amount.Text);
            //    total = total + amt1;
            //
            //txtrow.Text = Convert.ToString(total);
            AddNewRowToGrid();
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

                        TextBox box1 = (TextBox)GridV1.Rows[i].Cells[2].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridV1.Rows[i].Cells[3].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridV1.Rows[i].Cells[4].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridV1.Rows[i].Cells[5].FindControl("TextBox4");
                        TextBox box5 = (TextBox)GridV1.Rows[i].Cells[6].FindControl("TextBox5");

                        dtCurrentTable.Rows[i]["Column2"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box3.Text;
                        dtCurrentTable.Rows[i]["Column5"] = box4.Text;
                        dtCurrentTable.Rows[i]["Column6"] = box5.Text;

                        //extract the DropDownList Selected Items   

                        DropDownList ddl1 = (DropDownList)GridV1.Rows[i].Cells[1].FindControl("DropDownList1");
                        //   Label lbl1 = (Label)Gridview1.Rows[i].Cells[3].FindControl("Label1");
                        //DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[2].FindControl("DropDownList2");

                        // Update the DataRow with the DDL Selected Items   

                        dtCurrentTable.Rows[i]["Column1"] = ddl1.SelectedItem.Text;
                        //dtCurrentTable.Rows[i]["Column3"] = lbl1.Text;
                        //dtCurrentTable.Rows[i]["Column2"] = ddl2.SelectedItem.Text;

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridV1.DataSource = dtCurrentTable;
                    GridV1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
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

                        TextBox box1 = (TextBox)GridV1.Rows[i].Cells[2].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridV1.Rows[i].Cells[3].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridV1.Rows[i].Cells[4].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridV1.Rows[i].Cells[5].FindControl("TextBox4");
                        TextBox box5 = (TextBox)GridV1.Rows[i].Cells[6].FindControl("TextBox5");

                        DropDownList ddl1 = (DropDownList)GridV1.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
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
                            box5.Text = dt.Rows[i]["Column6"].ToString();

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



        protected void btnsave_Click(object sender, EventArgs e)
        {

            con.Open();
            Double discount = Convert.ToDouble(txtdiscount.Text);
            Double cgst = Convert.ToDouble(txtcgst.Text.ToString());
            Double sgst = Convert.ToDouble(txtsgst.Text.ToString());
            Double rowtot = Convert.ToDouble(txtrow.Text.ToString());
            Double dist = Convert.ToDouble(txtdiscount.Text.ToString());
            Double Total = cgst + sgst + rowtot - dist;
            txttotalamt.Text = Total.ToString();

            foreach (GridViewRow gr in GridV1.Rows)
            {

                if (gr.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddl1 = gr.FindControl("DropDownList1") as DropDownList;
                    TextBox textBox1 = gr.FindControl("TextBox1") as TextBox;
                    TextBox textBox2 = gr.FindControl("TextBox2") as TextBox;
                    TextBox textBox3 = gr.FindControl("TextBox3") as TextBox;
                    TextBox textBox4 = gr.FindControl("TextBox4") as TextBox;
                    String str1 = Convert.ToString(ddl1.SelectedValue);
                    string sql = "insert into PurchaseDetails(Purchasedate,InvoiceNo,DealerName,ItemCode,ItemName,Category,Rate,Qty,Discount,GrossAmt,TotalAmt,Cgst,Sgst,MobileNo) values('" + txtpurchasedate.Text.Trim() + "','" + lblinvoiceno.Text.Trim() + "','" + txtdealername.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + ddl1.SelectedItem.Value + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + txtdiscount.Text.Trim() + "','" + txtrow.Text.Trim() + "','" + txttotalamt.Text.Trim() + "','" + txtcgst.Text.Trim() + "','" + txtsgst.Text.Trim() + "','" + txtdcontactno.Text.Trim() + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    // ddlsem.Items.Remove(ddlsem.SelectedItem);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";
            con.Open();
            SqlCommand sql = new SqlCommand("select MobileNo from DealerMaster where DealerName='" + txtdealername.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtdcontactno.Text = dt.Rows[0][0].ToString();
            }
            con.Close();
        }



        protected void GridV1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.ConnectionString = @" Data Source=LAPTOP-4GGJAGHB\SQLEXPRESS;Initial Catalog=stockmanagement;User ID=sa;Password=jessna123";

                con.Open();
                DropDownList ddl1itemcode = (e.Row.FindControl("DropDownList1") as DropDownList);
                SqlCommand cmd = new SqlCommand("select * from ItemMaster", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddl1itemcode.DataSource = dt;


                ddl1itemcode.DataTextField = "ItemName";
                ddl1itemcode.DataValueField = "Itemcode";
                ddl1itemcode.DataBind();
                ddl1itemcode.Items.Insert(0, new ListItem("--Select--", "0"));
                con.Close();
                // ddl1itemcode.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void GridV1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow GridV1 = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropdown = (DropDownList)GridV1.FindControl("DropDownList1");
            TextBox txtItemCode = (TextBox)GridV1.FindControl("TextBox1");
            TextBox txtCategory = (TextBox)GridV1.FindControl("TextBox2");
            //TextBox txtRate = (TextBox)GridV1.FindControl("TextBox4");
            con.Open();
            SqlCommand sql = new SqlCommand("select ItemCode,Category  from ItemMaster where ItemName='" + dropdown.SelectedItem.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            adpt.Fill(dt);
            txtItemCode.Text = dt.Rows[0][0].ToString();
            txtCategory.Text = dt.Rows[0][1].ToString();
            //txtRate.Text = dt.Rows[0][2].ToString();
            con.Close();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridV1.Rows)
            {
                TextBox trate = (TextBox)row.Cells[3].FindControl("TextBox3");
                Double rate = Convert.ToDouble(trate.Text);
                TextBox tqty = (TextBox)row.Cells[4].FindControl("TextBox4");
                Double qty = Convert.ToDouble(tqty.Text);
                TextBox txtamount = (TextBox)row.Cells[5].FindControl("TextBox5");
                  
                Double amt = rate * qty;
                txtamount.Text = amt.ToString();
                tamt = tamt + amt;
             }
            txtrow.Text = tamt.ToString();
        
        }
    }
}