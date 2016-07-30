<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LogicUniversity.WebView.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>

            <asp:Label ID="Label1"
                Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px;"
                runat="server" Text="Forgot Password"></asp:Label>
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"
                Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;"
                Text="Enter PIN"></asp:Label>
            <asp:TextBox ID="txtPIN"
                Height="56px" Width="220px"
                Style="box-shadow: 5px 5px 9px grey; font-family: Arial; font-size: 16px;"
                runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3"
                Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;"
                runat="server" Text="Enter Confirm PIN"></asp:Label>
            <asp:TextBox
                Height="56px" Width="220px"
                Style="box-shadow: 5px 5px 9px grey; font-family: Arial; font-size: 16px;"
                ID="txtConfirmPIN" runat="server"></asp:TextBox>
            <br />
            <asp:Button
                CssClass="btn-custom" Style="box-shadow: 5px 5px 10px grey;"
                class="btn btn-lg btn-block btn-info"
                ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change" />

        </div>
</asp:Content>
