<%@ Page Title="" Language="C#" MasterPageFile="~/cuisine.Master" AutoEventWireup="true" CodeBehind="dealer.aspx.cs" Inherits="cuisine.dealer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 243px;
        }
        .auto-style3 {
            width: 555px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div style="width:100%;height:100%;text-align:center;vertical-align:middle">
       <table>
          
          <caption>DEALER DETAILS</caption>  
          <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbldealername" runat="server" Text="Dealer Name"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtdealername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblemail" runat="server" Text="Email Id"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtemail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblmobileno" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtmobileno" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblopeningbalance" runat="server" Text="Opening Balance"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtopbal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnsave" runat="server" Text="SAVE" OnClick="btnsave_Click" />
                </td>
            </tr>
       </table>
       
        
           
       </div>
</asp:Content>
