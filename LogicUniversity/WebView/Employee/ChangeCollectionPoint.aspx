<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ChangeCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 288px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
         <asp:Label ID="lblChangeCollPt"  
        style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:30px; margin-left: 37%;" runat="server" Text="Change Collection Point"></asp:Label>
        <table style="margin-left: 35%; height: 382px;">
        <tr>
            <td class="auto-style8" ><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        
        <tr>
            <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtEmpID" runat="server" Text="EmployeeID :"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
         <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
            <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblTxtDeptID" runat="server" Text="DepartmentID :"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px; width:200px;"
                ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
        </tr>
         <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
            <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px; width:400px;"
                ID="Label3" runat="server" Text="Department Representative :"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblDeptRep" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
            <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="Label2" runat="server" Text="Department :"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblDeptName" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
            <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="Label1" runat="server" Text="Current Collection Point :"></asp:Label></td>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="lblCurrCollPt" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
             <td class="auto-style8"><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
                ID="Label4" runat="server" Text="New Collection Point :"></asp:Label></td>
            <td><asp:DropDownList style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;"
                ID="ddlNewCollPt" runat="server" height="36px" Width="181px" ></asp:DropDownList></td>
        </tr>
         <tr>
                  <td class="auto-style8"><asp:Label ID="lblNewCollPt" runat="server" Text=""></asp:Label></td>
              <td colspan="2" style="align-content:center"><asp:Label ID="lblChangeResult" runat="server" Text="" Visible="false"></asp:Label></td>         
              </tr>
        <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr> <tr>
                  <td class="auto-style8">&nbsp;</td>
                       </tr>
        <tr>
           <td></td>
            <td>
                <asp:Button CssClass="btn-custom11"
        style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                ID="btnChangeCollPt" runat="server" Text="Change" OnClick="btnClick_ChangeCollPt" /></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
        
</asp:Content>
