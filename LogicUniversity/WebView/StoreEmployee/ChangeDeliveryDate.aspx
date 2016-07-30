<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeDeliveryDate.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ChangeDeliveryDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style9 {
            height: 21px;
            width: 217px;
        }
        .auto-style10 {
            width: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
  
        <table style="margin-left:37%">

            <tr>
               
              
                <td colspan="2">
                    <asp:Label Style="font-family: 'Arial Rounded MT'; margin-left:1%;  font-weight: bold; font-size: 30px;"
                        ID="Label5" runat="server" Text="Change Delivery Date"></asp:Label></td>
               
            </tr>

              <tr>
              
                <td class="auto-style10">&nbsp;</td>
                <td colspan="2"></td>
                   
               
            </tr>
             <tr>
               
                <td class="auto-style10">&nbsp;</td>
                <td colspan="2"></td>
                   
                                       
           
              
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>

            <tr>
               
                
                <td class="auto-style9">
                    <asp:Label ID="Label1" runat="server" Text="First Delivery Date"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                &nbsp;:</td>
                <td>
                    <asp:TextBox ID="txtFirstCollectionDate" runat="server"
                        Height="36px" Width="160px"
                        Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
               
              
                <td class="auto-style9">
                    <asp:Label ID="Label3" runat="server" Text="Change To"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                &nbsp;</td>
                <td>
                    <asp:RadioButtonList ID="rdblFirstCollectionDate" runat="server" CssClass="radio">
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
               
             
                <td class="auto-style9">
                    <asp:Label ID="Label2" runat="server" Text="Second Delivery Date"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                &nbsp;:</td>
                <td>
                    <asp:TextBox ID="txtSecondCollectionDate" runat="server" Height="36px" Width="160px"
                        Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 14px;"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                
              
                <td class="auto-style9">
                    <asp:Label ID="Label4" runat="server" Text="Change To"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                &nbsp;:</td>
                <td>
                    <asp:RadioButtonList ID="rdblSecondCollectionDate" CssClass="radio" runat="server">
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                        <asp:ListItem>Saturday</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
               
                <td colspan="4">
                    <asp:Button ID="btnChangeDeliveryDate" CssClass="btn-custom11"
                        Style="box-shadow: 3px 3px 7px grey; margin-left:14%" class="btn btn-lg btn-block btn-info"
                        runat="server" Text="Change Delivery" OnClick="btnChangeDeliveryDate_Click"/>
                </td>
            </tr>
        </table>
  
</asp:Content>
