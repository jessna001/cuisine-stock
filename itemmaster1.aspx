<%@ Page Title="" Language="C#" MasterPageFile="~/staff.Master" AutoEventWireup="true" CodeBehind="itemmaster1.aspx.cs" Inherits="cuisine.itemmaster1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="panel">
        <div class="container">
           <header class="panel-heading">
              <h2 > <b> Item Details </b>  </h2>
           </header>
           <div class="panel-body">
               <h5 class="form-group" > <b> Item Description</b> </h5>
               <div class="form-class">
                 <div class="col-md-6">
                    <label >Item Name</label>
                    <asp:TextBox ID="txtiname" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Item Name" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtiname" ErrorMessage="Please enter the ItemName"></asp:RequiredFieldValidator>
                          
                 </div>
            </div>
              <%-- <div class="row">--%>
                      <%--<div class="col-md-6">--%>
                           <label>Category</label>
                          <asp:DropDownList ID="ddlcategory" CssClass="form-control" placeholder="Category" runat="server" Width="300px">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>Veg</asp:ListItem>
                        <asp:ListItem>Non Veg</asp:ListItem>
                        <asp:ListItem>Indian</asp:ListItem>
                        <asp:ListItem>Chinese</asp:ListItem>
                        <asp:ListItem>Continental</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlcategory" ErrorMessage="Please select the designation"></asp:RequiredFieldValidator>
                          <%--</div>--%>
                      <%--</div>--%>
              <%-- <div class="form-class">
                 <div class="col-md-6">
                    <label >Item Rate</label>
                    <asp:TextBox ID="txtrate" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Item Rate" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrate" ErrorMessage="Please enter the rate"></asp:RequiredFieldValidator>
                          
                 </div>
            </div>--%>
              <%-- <div class="form-class">
                 <div class="col-md-6">
                    <label>GST Percentage</label>
                    <asp:TextBox ID="txtgst" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Gst" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtgst" ErrorMessage="Please enter the Gst"></asp:RequiredFieldValidator>
                          
                 </div>
            </div>--%>
              <%-- <div class="form-class">
                 <div class="col-md-6">
                    <label >Opening Quantity</label>
                    <asp:TextBox ID="txtopqty" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Opening Quantity" runat="server" Width="300px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtopqty" ErrorMessage="Please enter the Opening quantity"></asp:RequiredFieldValidator>
                          
                 </div>
            </div>--%>
                <div class="row">
                      <div class="col-md-6">
                  <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btn btn-primary btn-block" Width="100px"  Height="36px" OnClick="btnsave_Click" />
    </div>
                      </div>
               </div>
            </div>
            </section>
</asp:Content>
