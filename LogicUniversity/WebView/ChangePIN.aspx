﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePIN.aspx.cs" Inherits="LogicUniversity.WebView.ChangePIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1015px;
        }

        .auto-style3 {
            width: 143px;
        }

        .auto-style4 {
            width: 307px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
   
        <table style="vertical-align: central; margin-left: 33%;">
            :      
            <tr>
                
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px;"
                        ID="Label1" runat="server" Text="Change PIN"></asp:Label></td>
                <td>&nbsp;                                
           
                </td>
            </tr>


            <tr>
                <td>&nbsp;</td>
            </tr>

            <tr>
                
                <td>&nbsp;</td>
                <td colspan="3">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
               
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">

                    <asp:Label ID="Label2" Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;"
                        runat="server" Text="Old PIN"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtOldPIN" runat="server"
                        Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        Height="30px" Width="179px"></asp:TextBox>
              
                    <!-- Allows only numbers-->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        runat="server" ControlToValidate="txtOldPIN"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">       

                    </asp:RegularExpressionValidator>
                    <!--  Checks if textbox is blank-->

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="*Required"
                        ControlToValidate="txtOldPIN" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label3" Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;" runat="server" Text="New PIN"></asp:Label>
                </td>

                <td class="auto-style2">
                    <asp:TextBox ID="txtNewPIN"
                        Height="30px" Width="179px"
                        Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        runat="server"></asp:TextBox>
               
                    <!-- Allows only numbers-->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server" ControlToValidate="txtNewPIN"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">       

                    </asp:RegularExpressionValidator>
                    <!--  Checks if textbox is blank-->

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="*Required"
                        ControlToValidate="txtNewPIN" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td>&nbsp; &nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="Label4" Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;" runat="server" Text="Confirm New PIN"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtConfirmNewPIN" runat="server"
                        Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        Height="27px" Width="179px"></asp:TextBox>
             

                    <!-- Allows only numbers-->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ControlToValidate="txtConfirmNewPIN"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">       

                    </asp:RegularExpressionValidator>
                    <!--  Checks if textbox is blank-->

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server"
                        ErrorMessage="*Required"
                        ControlToValidate="txtConfirmNewPIN" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
               <td>&nbsp; &nbsp;</td>
                <td class="auto-style4">
                   
                </td>
                <td class="auto-style2">
              
         
                    <asp:Button CssClass="btn-custom11" Style="box-shadow: 5px 5px 10px grey;"
                        class="btn btn-lg btn-block btn-info"
                        ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
   
</asp:Content>
