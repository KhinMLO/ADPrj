<%@ Page Title="" Language="C#"MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LogicUniversity.WebView.Finance.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 10px;
        }
        .auto-style9 {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    <table class="auto-style1" id="tblDeveloper" runat="server" style="margin-left:35%;">
        <tr>
            <td colspan="5">
<asp:Label ID="lblTitle" runat="server"  Width="500px"
        Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px;"
        Text="Supplier Item Management"></asp:Label>
                 <br /><br /><br />
            </td>

        </tr>
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"
                Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                ></asp:Label></td>
            <td><asp:Label ID="lblSessType"
                Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:15px;"
                 runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" 
                Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:15px;"
                Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label
                Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                 ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:15px;"
                runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtRole" runat="server" Text="Role"
                Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                ></asp:Label></td>
            <td><asp:Label ID="lblRole" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:15px;"
                runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblDevMessage" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <table class="auto-style1" id="tblUser" runat="server" style="margin-left:35%;">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblCategory" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;"
                runat="server" Text="Category"></asp:Label></td>
            <td class="auto-style8"><asp:DropDownList ID="ddlCategory" runat="server" Enabled="false" AutoPostBack="true"
                 Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                ></asp:DropDownList></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblItemDesc" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;"
                runat="server"  Width="216px" Text="Item Description + UOM"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlItemDesc" runat="server" Enabled="false"  AutoPostBack="true"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:Label ID="lblUOM" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><br /><br /><br /><br />&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTitleSupplier" 
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;"
                runat="server" Text="Supplier Name"></asp:Label></td>

            <td class="auto-style8"><asp:Label ID="lblTitlePrice" runat="server" Text="Price"
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;" 
                ></asp:Label></td>

            <td></td>
              <td><asp:Label ID="lblTitleRank" runat="server" Text="Priority"
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;"
                ></asp:Label></td>
            <td></td>
              <td><asp:Label ID="lblTitleEnable" runat="server" Text="Enable"
                 Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size:19px;"
                ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier1" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="supplier12CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier2" ControlToValidate="ddlSupplier1" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities" >*</asp:CompareValidator>
            </td>
             
            <td>
                <asp:TextBox ID="tbxPrice1" runat="server" Text="0"
                     style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="36px" Width="180px"
                    ></asp:TextBox>
                <asp:RangeValidator ID="priceValidator1" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice1" ForeColor="Red"
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlRank1" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="rank12CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank2" ControlToValidate="ddlRank1" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;</td>
            <td><asp:CheckBox ID="cbxSupplier1" runat="server" Checked="true" AutoPostBack="True"  /></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier2" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="supplier23CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier3" ControlToValidate="ddlSupplier2" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities">*</asp:CompareValidator>
            </td>
              
            <td>
                <asp:TextBox ID="tbxPrice2" runat="server" Text="0"
                     style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
               Height="36px" Width="180px"
                    ></asp:TextBox>
                <asp:RangeValidator ID="priceValidator2" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice2" ForeColor="Red" 
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlRank2" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="rank23CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank3" ControlToValidate="ddlRank2" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;</td>
            <td><asp:CheckBox ID="cbxSupplier2" runat="server" Checked="true" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style9"></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier3" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="supplier31CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier1" ControlToValidate="ddlSupplier3" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities">*</asp:CompareValidator>
            </td>
              
            <td>
                <asp:TextBox ID="tbxPrice3" runat="server" Text="0" 
                     style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="36px" Width="180px"
                    ></asp:TextBox>
                <asp:RangeValidator ID="priceValidator3" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice3"  ForeColor="Red"
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlRank3" runat="server"
                     Style="box-shadow: 3px 3px 4px grey; font-size: 13px; font-family: Arial;"
                                    Height="34px" Width="160px"
                    ></asp:DropDownList>
                <asp:CompareValidator ID="rank31CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank1" ControlToValidate="ddlRank3" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
              <td>&nbsp;&nbsp;&nbsp;</td>
            <td><asp:CheckBox ID="cbxSupplier3" runat="server" Checked="true" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style8"><asp:Button 
                cssClass="btn-custom"    
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                ID="btnSubmit" runat="server" Text="Submit" Enabled="false" ValidationGroup="vlgSupplierItem" />&nbsp;</td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><asp:Label ID="lblUserMessage" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vlgSupplierItem" ShowMessageBox="True" ForeColor="Red" />
</asp:Content>
