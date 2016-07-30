<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeDepartmentRepresentative.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" 
         style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:30px;margin-left:36%;"  Text="Change Department Representative"></asp:Label>
    <br />
    <br />
   
    <table class="auto-style1" style="margin-left:35%; width:40%; height: 299px;">
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>

        </tr>
        <tr>
             <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="Label1" runat="server" Text="Current Representative"></asp:Label></td>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblCurrDeptRep" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label 
               style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="Label2" runat="server" Text="New Representative"></asp:Label></td>
            <td><asp:DropDownList ID="ddlNewDeptRep" height="36px" Width="181px"
                style="box-shadow: 5px 5px 8px grey; font-family:Arial; font-size:16px;"
                runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label 
                style="box-shadow: 5px 5px 8px grey; font-family:Arial; font-size:16px;"
                ID="lblNewDeptRep" runat="server" Text=""></asp:Label></td>
            <td><asp:Button 
                CssClass="btn-custom11" 
        style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                ID="btnChangeDeptRep" runat="server" Text="Change" OnClick="btnClick_ChangeDeptRep" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblNote" runat="server" Text="Note - Upon confirmation, an email notification will be sent to the current rep., new rep., dept. head and store clerks." Visible="False"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
