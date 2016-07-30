<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RequestStationery.aspx.cs" Inherits="LogicUniversity.WebView.Employee.RequestStationery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <table style="width: 50%; margin-left: 35%;">
            <tr>
              
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px; margin-left:19%;"
                        Text="Request Stationery"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

          
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Category :"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddlCategory" Style="box-shadow: 3px 3px 6px grey; font-family: Arial; font-size: 16px;"
                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                        Height="36px" Width="179px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Item Description :"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlItemDescription"
                        Style="box-shadow: 3px 3px 6px grey; font-family: Arial; font-size: 16px;"
                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged"
                        Height="36px" Width="180px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Unit of Measure :"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnitOfMeasure" runat="server" Enabled="False"
                        Style="box-shadow: 3px 3px 6px grey; font-family: Arial; font-size: 16px;"
                        Height="36px" Width="179px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>

            </tr>
              <tr>
                <td>&nbsp;</td>
                <td colspan="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Requested Quantity :"
                        Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRequestQty" runat="server" MinValue="0" 
                        Style="box-shadow: 3px 3px 6px grey; font-family: Arial; font-size: 14px;"
                        Height="36px" Width="180px" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <!-- Allows only numbers-->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ControlToValidate="txtRequestQty"
                        ErrorMessage="Please Enter positive number"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    <!--  Checks if textbox is blank-->

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server"
                        ErrorMessage="Please enter value for quantity"
                        ControlToValidate="txtRequestQty" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td> </td>
                    <td colspan="3"><asp:Label ID="lblMessage" runat="server" ></asp:Label>
                </td>

            </tr>
            <tr>
               <td></td><td></td>
                <td colspan="2">
                    <br />
                    <asp:Button ID="btnAdd" CssClass="btn-custom11" Style="box-shadow: 3px 3px 7px grey; "
                        runat="server" OnClick="btnAdd_Click" Text="Add" />
                </td>
            </tr>
        </table>

        <br />
        <br />
   
    
   
    <div id="mainContainer" class="container" style="width: 92%; position: relative; margin-left: 4.5%;">
        <div class="shadowBox">
            <div class="table-responsive">
                <asp:GridView ID="gvData" runat="server"
                    HeaderStyle-CssClass="grid_head"
                    CssClass="table table-hover table-bordered"
                    RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                    HeaderStyle-BackColor="WhiteSmoke" OnRowCreated="gvData_RowCreated">


                    <Columns>



                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="lnk_edit"
                                    NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?ItemID=" + Eval("ItemID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="lnk_delete"
                                    NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?ItemIDToDelete=" + Eval("ItemID")%>'
                                    Text="Delete"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
  </div>
    <br />
    <br />
  <!--  <% if (gvData.Rows.Count > 0)
        {
            
            btnSubmit.Visible = true;
                btnClearAll.Visible =true;
        }
        else
        {
            btnSubmit.Visible = false;
                btnClearAll.Visible = false;
        }
       %>-->
   
    <table style="margin-left:36%;position:relative;">
        <tr><td>
            <asp:Button ID="btnClearAll" runat="server" CssClass="btn-custom11"
        Style="box-shadow: 5px 5px 10px grey;" Visible="true"
        Text="Clear All" OnClick="btnClearAll_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnSubmit" runat="server" CssClass="btn-custom11"
        Style="box-shadow: 5px 5px 10px grey;" Visible="true"
        OnClick="btnSubmit_Click" Text="Submit" />
                 </td></tr>

    </table>
    

    <br />
    <br />
    &nbsp;
</asp:Content>
