<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="LogicUniversity.WebView.Finance.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle"  runat="server" style="margin-left:42%;" Font-Size="30px"  Text="Supplier Item Management"></asp:Label>
    <br />
    <br /><br />
    <table class="auto-style1" id="tblDeveloper" runat="server" style="margin-left:37%;">
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Font-Size="19px" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Font-Size="16px" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label Font-Size="19px" ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" Font-Size="16px" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label  Font-Size="19px" ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" Font-Size="16px" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label Font-Size="19px" ID="lblTxtRole" runat="server" Text="Role"></asp:Label></td>
            <td><asp:Label ID="lblRole" Font-Size="16px" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblDevMessage" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <table class="auto-style1" id="tblUser" style="margin-left:37%;" runat="server">
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblCategory" runat="server" Font-Size="19px"  Text="Category"></asp:Label></td>
            <td><asp:DropDownList ID="ddlCategory" runat="server" 
                Height="30px" Width="179px" style="box-shadow: 5px 5px 7px grey;"
                Enabled="false" AutoPostBack="true"></asp:DropDownList></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblItemDesc"
                Font-Size="19px"
                 runat="server" Text="Item Description + UOM"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlItemDesc" runat="server"  style="box-shadow: 5px 5px 7px grey;"
                    Height="30px" Width="179px"
                    Enabled="false"  AutoPostBack="true"></asp:DropDownList>
                <asp:Label ID="lblUOM" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTitleSupplier" runat="server" Font-Size="19px" Text="Supplier Name"></asp:Label></td>
            <td><asp:Label ID="lblTitlePrice" runat="server" Text="Price" Font-Size="19px"></asp:Label></td>
            <td><asp:Label ID="lblTitleRank" runat="server" Text="Priority" Font-Size="19px"></asp:Label></td>
            <td><asp:Label ID="lblTitleEnable" runat="server" Text="Enable" Font-Size="19px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier1" Height="30px" Width="179px" runat="server" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="supplier12CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier2" ControlToValidate="ddlSupplier1" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities" >*</asp:CompareValidator>
            </td>
            <td>
                <asp:TextBox ID="tbxPrice1" runat="server" Height="30px" Width="179px" Text="0" style="box-shadow: 5px 5px 7px grey;"></asp:TextBox>
                <asp:RangeValidator ID="priceValidator1" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice1" ForeColor="Red"
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlRank1" runat="server" Height="30px" Width="179px" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="rank12CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank2" ControlToValidate="ddlRank1" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
            <td><asp:CheckBox ID="cbxSupplier1" runat="server" Checked="true" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier2" Height="30px" Width="179px" runat="server" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="supplier23CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier3" ControlToValidate="ddlSupplier2" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities">*</asp:CompareValidator>
            </td>
            <td>
                <asp:TextBox ID="tbxPrice2" runat="server" Height="30px" Width="179px" Text="0"></asp:TextBox>
                <asp:RangeValidator ID="priceValidator2" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice2" ForeColor="Red" 
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlRank2" runat="server" Height="30px" Width="179px" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="rank23CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank3" ControlToValidate="ddlRank2" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
            <td><asp:CheckBox ID="cbxSupplier2" runat="server" Checked="true" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSupplier3" Height="30px" Width="179px" runat="server" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="supplier31CompareValidator" runat="server" 
                    ErrorMessage="Suppliers should not be the same between priorities" 
                    ControlToCompare="ddlSupplier1" ControlToValidate="ddlSupplier3" 
                    ValidationGroup="vlgSupplierItem" Operator="NotEqual" ForeColor="Red"
                    ToolTip="Suppliers should not be the same between priorities"
                    Text="Suppliers should not be the same between priorities">*</asp:CompareValidator>
            </td>
            <td>
                <asp:TextBox ID="tbxPrice3" Height="30px" Width="179px" runat="server" Text="0" style="box-shadow: 5px 5px 7px grey;"></asp:TextBox>
                <asp:RangeValidator ID="priceValidator3" runat="server" ErrorMessage="Price cannot be Zero (0)" 
                    ControlToValidate="tbxPrice3"  ForeColor="Red"
                    MinimumValue="0.00001" MaximumValue="1000000" ValidationGroup="vlgSupplierItem" 
                    Text="Price cannot be Zero (0)" Type="Double" 
                    ToolTip="Price cannot be Zero (0)">*</asp:RangeValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlRank3" runat="server" Height="30px" Width="179px" style="box-shadow: 5px 5px 7px grey;"></asp:DropDownList>
                <asp:CompareValidator ID="rank31CompareValidator" runat="server" 
                    ErrorMessage="Priorities should not be the same between suppliers" 
                    ControlToCompare="ddlRank1" ControlToValidate="ddlRank3" ForeColor="Red" 
                    Text="Priorities should not be the same between suppliers" 
                    ToolTip="Priorities should not be the same between suppliers"
                    Operator="NotEqual" ValidationGroup="vlgSupplierItem">*</asp:CompareValidator>
            </td>
            <td><asp:CheckBox ID="cbxSupplier3" runat="server" Checked="true" AutoPostBack="True"  /></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
           
            <td colspan="2"><asp:Button ID="btnSubmit" 
                cssClass="btn-custom11"   
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                runat="server" Text="Submit" Enabled="false"  ValidationGroup="vlgSupplierItem" /></td>
             <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4"><asp:Label ID="lblUserMessage"  style="font-size:12px;" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vlgSupplierItem" ShowMessageBox="True" ForeColor="Red" />
</asp:Content>

