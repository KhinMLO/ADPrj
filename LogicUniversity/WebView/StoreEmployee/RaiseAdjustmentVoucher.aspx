<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaiseAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaiseAdjustmentVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 90%; margin-left: 70px;">
      
            <table style="width: 65%; margin-left:35%;">
                <tr>
                    <td>&nbsp;</td>

                    <td colspan="2">
                        <asp:Label
                            Style="font-family: 'Arial Rounded MT'; margin-left:9%; font-weight: bold; font-size: 30px;"
                            ID="Label7" runat="server" Text="Raise Adjustment Voucher"></asp:Label></td>
                    <td>&nbsp;                                
           
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label2" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                            runat="server" Text="Category"></asp:Label>
                    &nbsp;:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server"
                            Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                            Height="36px" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label3" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                            runat="server" Text="Item Description"></asp:Label>&nbsp;:</td>
                    <td>
                        <asp:DropDownList ID="ddlItemDescription" runat="server"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged"
                            Height="36px" Width="180px"
                            Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Label ID="Label4" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                            runat="server" Text="Unit of Measure"></asp:Label>
                    &nbsp;:</td>
                    <td>
                        <asp:TextBox ID="txtUnifOfMeasure"
                            Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                            runat="server" Enabled="False" Height="36px" Width="180px"></asp:TextBox>
                    </td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label5"
                            runat="server"
                            Style="font-family: Arial; font-size: 19px;"
                            Text="Quantity To Adjust"></asp:Label>
                    &nbsp;:</td>
                    <td>
                        <asp:TextBox ID="txtQuantityToAdjust" runat="server"
                            Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                            Height="35px" Width="179px"></asp:TextBox>
                    </td>
                    <td>
                        <!--  Checks if textbox is blank-->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server"
                            ErrorMessage="*Please enter value for quantity"
                            ControlToValidate="txtQuantityToAdjust" ForeColor="black"></asp:RequiredFieldValidator>

                        <!-- Allows only numbers-->
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtQuantityToAdjust"
                            ErrorMessage="Please Enter Only Numbers" ForeColor="black" ValidationExpression="^\d+$">        </asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <div style="margin-left:56%">
                        <asp:RadioButtonList ID="rblIncreaseOrDecrease" runat="server" CssClass="radio">

                            <asp:ListItem Value="Increase" Selected="True">Increase</asp:ListItem>


                            <asp:ListItem>Decrease</asp:ListItem>
                        </asp:RadioButtonList>
                            </div>
                    </td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label6" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                            runat="server" Text="Reason for Adjustment :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReason" Style="box-shadow: 3px 3px 7px grey; color:grey;  font-family: Arial; font-size: 16px;"
                            runat="server" Height="36px" Width="180px"></asp:TextBox>
                    </td>
                    <td>
                        <!--  Checks if textbox is blank-->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*Required"
                            ControlToValidate="txtReason" ForeColor="black"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                </tr>

                <tr>
                   
                    <td colspan="4">
                        <br /><asp:Button ID="btnAdd"
                            CssClass="btn-custom11" Style="box-shadow: 3px 3px 7px grey; margin-left:27.7%;"
                            runat="server" OnClick="btnAdd_Click" Text="Add" />
                        &nbsp;
                    </td>
                </tr>
                <tr><td><br /></td></tr> <tr><td></td></tr> <tr><td></td></tr>
               <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <br />

        <div id="mainContainer" class="container" style="width: 100%; position: relative; margin-left:0.5%;">
            <div class="shadowBox">
                <div class="table-responsive">
                    <asp:GridView ID="gvList" runat="server"
                        HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke" OnRowCreated="gvList_RowCreated">

                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_edit"
                                        NavigateUrl='<%# "~/WebView/StoreEmployee/RaiseAdjustmentVoucher.aspx?ItemCodeToEdit=" + Eval("ItemCode")%>'
                                        Text="Edit"></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_delete"
                                        NavigateUrl='<%# "~/WebView/StoreEmployee/RaiseAdjustmentVoucher.aspx?ItemCodeToDelete=" + Eval("ItemCode")%>'
                                        commandName="lnk_delete"
                                        Text="Delete"></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
             <asp:Button ID="btnConfirm" CssClass="btn-custom11" Style="box-shadow: 3px 3px 7px grey; margin-left:42%;" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
        </div>
        <br />
       
   
    <br />
    <br />
</asp:Content>
