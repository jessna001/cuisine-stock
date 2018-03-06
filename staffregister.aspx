<%@ Page Title="" Language="C#" MasterPageFile="~/cuisine.Master" AutoEventWireup="true" CodeBehind="staffregister.aspx.cs" Inherits="cuisine.staffregister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 175px;
        }
        .auto-style3 {
            width: 175px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 175px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 175px;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>


    <section class="panel">
        <div class="container">
            
              <header class="panel-heading">
               <h2> <b> Staff Registration</b>  </h2>
              </header>
              <div class="panel-body">
                  <div class="row">
                <div class="col-md-6">
                    
     <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Name" runat="server" Width="300" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqname" runat="server" ErrorMessage="Please enter your name!" ControlToValidate="txtname"></asp:RequiredFieldValidator>
                   
    </div>
                       </div>
                      <div class="row">
                      <div class="col-md-6">
                         
                          <asp:TextBox ID="txtaddress" CssClass="form-control" placeholder="Address" runat="server" TextMode="MultiLine" Width="300px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqaddress" runat="server" ErrorMessage="Please enter your address!" ControlToValidate="txtaddress"></asp:RequiredFieldValidator>
                   </div>
                      </div>
                  
                   
               <div class="row">
                      <div class="col-md-6">
                           
                          <asp:TextBox ID="txtuid" CssClass="form-control" placeholder="User ID" runat="server"  Width="300px" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="This field is required!" ControlToValidate="txtuid"></asp:RequiredFieldValidator>
                          </div>
                      </div>
                   <div class="row">
                      <div class="col-md-6">
                           
                           <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Please select the gender"></asp:RequiredFieldValidator>
                   
                     </div>
                      </div>
                  <div class="row">
                      <div class="col-md-6">
                           
           <asp:TextBox ID="txtaadharno" CssClass="form-control" placeholder="Aadhar Number" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqaadharno" runat="server" ErrorMessage="Please enter your aadhar no!" ControlToValidate="txtaadharno"></asp:RequiredFieldValidator>
                          </div>
                      </div>
                  <div class="row">
                      <div class="col-md-6">
                           
                           <asp:TextBox ID="txtmobile" CssClass="form-control" placeholder="Mobile" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmobile" ErrorMessage="Please Enter Your Mobile Number."></asp:RequiredFieldValidator>
                           </div>
                      </div>
                  <div class="row">
                      <div class="col-md-6">
                           
                          <asp:DropDownList ID="ddldesignation" CssClass="form-control" placeholder="Designation" runat="server" Width="300px" OnSelectedIndexChanged="ddldesignation_SelectedIndexChanged">
                        <asp:ListItem>--SELECT DESIGNATION--</asp:ListItem>
                        <asp:ListItem>Master Chef</asp:ListItem>
                        <asp:ListItem>Production</asp:ListItem>
                        <asp:ListItem>Serving</asp:ListItem>
                        <asp:ListItem>Billing</asp:ListItem>
                        <asp:ListItem>others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldesignation" ErrorMessage="Please select the designation"></asp:RequiredFieldValidator>
                          </div>
                      </div>
                   <div class="row">
                      <div class="col-md-6">
                          
                          <asp:TextBox ID="txtmonthsalary" CssClass="form-control" placeholder="Monthly Salary" runat="server" Width="300px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmonthsalary" ErrorMessage="Please enter monthly salary"></asp:RequiredFieldValidator>
                          </div>
                      </div>
                  <div class="row">
                      <div class="col-md-6">
                         
                          <asp:TextBox ID="txtpassword" CssClass="form-control" placeholder="Password" runat="server"  Width="300px" style="margin-bottom: 0px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqpswd" runat="server" ControlToValidate="txtpassword" ErrorMessage="please enter the password"></asp:RequiredFieldValidator>
                            </div>
                      </div>
                      <div class="row">
                      <div class="col-md-6">
                           
                      <asp:TextBox ID="txtcpassword" CssClass="form-control" placeholder=" Confirm Password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqconfirmpassword" runat="server" ControlToValidate="txtcpassword" ErrorMessage ="Please enter confirm password"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtcpassword" ControlToCompare="txtpassword" ErrorMessage="Not similar"></asp:CompareValidator>
                          </div>
                          </div>
                  <div class="row">
                      <div class="col-md-6">
                  <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btn btn-primary btn-block" Width="86px" OnClick="btnsave_Click" Height="26px" />
    </div>
                      </div>
                  </div>
                </div>
        </section>
    </asp:Content>

    


        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; STAFF REGISTRATION&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table  class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td class="auto-style6">
                    
    <br /><br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lbluid" runat="server" Text="User Id"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblaadharno" runat="server" Text="Aadhar No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtaadharno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqaadharno" runat="server" ErrorMessage="Please enter your aadhar no!" ControlToValidate="txtaadharno"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblmobile" runat="server" Text="Mobile"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmobile" ErrorMessage="Please Enter Your Mobile Number."></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbldesignation" runat="server" Text="Designation"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldesignation" runat="server" OnSelectedIndexChanged="ddldesignation_SelectedIndexChanged">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>Master Chef</asp:ListItem>
                        <asp:ListItem>Production</asp:ListItem>
                        <asp:ListItem>Serving</asp:ListItem>
                        <asp:ListItem>Billing</asp:ListItem>
                        <asp:ListItem>others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldesignation" ErrorMessage="Please select the designation"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblsalary" runat="server" Text="Monthly Salary"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtmonthsalary" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmonthsalary" ErrorMessage="Please enter monthly salary"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server" style="margin-bottom: 0px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqpswd" runat="server" ControlToValidate="txtpassword" ErrorMessage="please enter the password"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblconfirmpswd" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcpassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqconfirmpassword" runat="server" ControlToValidate="txtcpassword" ErrorMessage ="Please enter confirm password"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtcpassword" ControlToCompare="txtpassword" ErrorMessage="Not similar"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="SAVE" Width="66px" OnClick="btnsave_Click" Height="26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>--%>
   
