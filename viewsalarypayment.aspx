<%@ Page Title="" Language="C#" MasterPageFile="~/cuisine.Master" AutoEventWireup="true" CodeBehind="viewsalarypayment.aspx.cs" Inherits="cuisine.viewsalarypayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


    <asp:TextBox ID="txtstaffname" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

 




    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnsearch" runat="server" Text="Search"  OnClick="btnsearch_Click" />
   
    


    --<asp:GridView ID="gvsearch" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged= "btnsearch_Click" >

        <Columns>
                         <asp:BoundField DataField="StaffId" HeaderText="Name" SortExpression="staff_name" ></asp:BoundField>   
                        
                         <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="staff_desi"></asp:BoundField>
                         <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="salary"></asp:BoundField>
                         
                     </Columns>
        </asp:GridView>-
</asp:Content>
