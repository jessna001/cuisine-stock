<%@ Page Title="" Language="C#" MasterPageFile="~/cuisine.Master" AutoEventWireup="true" CodeBehind="staffregisteredit.aspx.cs" Inherits="cuisine.staffregisteredit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 136px;
        }
        .auto-style2 {
            width: 144px;
        }
        .auto-style3 {
            width: 147px;
        }
        .auto-style4 {
            width: 291px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="txtuserid" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>

    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass=" btn btn btn-primary" OnClick="btnsearch_Click"/>
    <asp:GridView ID="gvsearch" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvsearch_SelectedIndexChanged" >

        <Columns>
                         <asp:BoundField DataField="StaffName" HeaderText="Name" SortExpression="staff_name" ></asp:BoundField>   
                         <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="staff_address"></asp:BoundField>
                         <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="staff_desi"></asp:BoundField>
                         <asp:BoundField DataField="AadharNo" HeaderText="AadhaarNumber" SortExpression="staff_aadharno"></asp:BoundField>
                         <asp:BoundField DataField="MonthlySalary" HeaderText="Monthly Salary" SortExpression="staff_month"  ></asp:BoundField>
                         <asp:BoundField DataField="Mobile" HeaderText="Mobile Number" SortExpression="staff_month"  ></asp:BoundField>
                         <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="staff_password"></asp:BoundField>
                         
                     </Columns>
        </asp:GridView>
</asp:Content>
