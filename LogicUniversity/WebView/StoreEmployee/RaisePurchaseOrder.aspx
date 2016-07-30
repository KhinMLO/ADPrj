<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaisePurchaseOrder.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaisePurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div style="width: auto; margin-left: 20px;">
     
                <div class="table-responsive">
                   
          
  
   <table style=" margin-left:10%;">
            <tr>
                <td class="auto-style2" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="auto-style8">   <asp:Label
                                    Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px;margin-left:30%;"
                                    ID="Label10" runat="server" Text="Raise New PO"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    </span></strong></td>
            </tr>
            <tr>
                 <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label ID="Label2" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" runat="server" Text="Category :"></asp:Label>
                </td>
                <td class="auto-style13"> <asp:DropDownList
                                    Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="ddlCategory" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                    Height="34px" Width="160px">
                                </asp:DropDownList>
                  
                </td>
                 <td class="auto-style18">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                                    ID="Label7" runat="server" Text="Supplier Name"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style19"><asp:DropDownList Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;" ID="ddlSupplierName" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSupplierName_SelectedIndexChanged"
                                    Height="34px" Width="160px">
                                </asp:DropDownList>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1"
                        Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;"
                         runat="server" Text="Description"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style13">
                   <asp:DropDownList
                                    Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="ddlDescription" runat="server"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDescription_SelectedIndexChanged"
                                    Height="34px" Width="160px">
                                </asp:DropDownList>
                </td>
               
                <td class="auto-style18">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label8" runat="server" Text="Contact Name"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style19">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="txtContactName" runat="server" Enabled="False"
                                    Height="34px" Width="160px"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label3" runat="server" Text="Unit of Measure"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style24">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="txtUnitOfMeasure" runat="server" Enabled="False" Height="34px" Width="160px"></asp:TextBox>
                </td>
               
                <td class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label4" runat="server" Text="Contact Email"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style25">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;" ID="txtContactEmail" runat="server" Enabled="False"
                                    Height="34px" Width="160px"></asp:TextBox>
                </td>
            </tr>





         <tr>
                <td class="auto-style26">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label5" runat="server" Text="Quantity to Order"></asp:Label>
                
                &nbsp;:</td>
                <td class="auto-style27">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;" 
                                    ID="txtQuantityToOrder" runat="server" Height="34px" Width="160px"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                    runat="server" ControlToValidate="txtQuantityToOrder"
                                    ErrorMessage="Only Number" ForeColor="black" ValidationExpression="^\d+$">       
                                </asp:RegularExpressionValidator>



                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server"
                                    ErrorMessage="*Required"
                                    ControlToValidate="txtQuantityToOrder" ForeColor="black"></asp:RequiredFieldValidator>
                </td>
               
                <td class="auto-style28">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label6" runat="server" Text="Phone"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style29">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="txtPhone" runat="server" Enabled="False"
                                    Height="34px" Width="160px"></asp:TextBox>
                   
                </td>
            </tr>



       

         <tr>
                <td class="auto-style20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label9" runat="server" Text="Required Delivery Date"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style21">
                   <asp:TextBox Style="box-shadow: 5px 5px 9px grey; box-shadow: 3px 3px 4px grey; font-family: Arial; font-size: 16px;"
                                    ID="txtRequiredDelivereyDate" runat="server" TextMode="Date"
                                    Height="34px" Width="160px"></asp:TextBox>
                </td>
               
                <td class="auto-style20">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                 
                    <asp:Label Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;" ID="Label11" runat="server" Text="Fax"></asp:Label>
                &nbsp;:</td>
                <td class="auto-style20">
                   <asp:TextBox Style="box-shadow: 3px 3px 4px grey; font-size: 16px; font-family: Arial;"
                                    ID="txtFax" runat="server"
                                    Enabled="False" Height="34px" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="auto-style8">   
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </span></strong> </td>
                <td class="auto-style12">   
                    &nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style5">
                    
                </td>
            </tr>
           
            <tr>
               <td class="auto-style15">&nbsp;</td>
                <td></td> 
                <td colspan="3">
                    <asp:Button CssClass="btn-custom11" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add"
                                    Style="box-shadow:3px 3px 7px grey; margin-left:33%;" class="btn btn-lg btn-block btn-info" />
                </td>
            </tr>
        </table>
         </div>
  
        <br />
        <br />
        <br />

        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: 0.9%;">
            <div class="shadowBox">
                <div class="table-responsive">
                    <asp:GridView ID="gvDataList" runat="server" OnRowCreated="gvDataList_RowCreated"
                        HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_edit"
                                        NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToEdit="+Eval("ItemID")+"&SupplierIDToEdit="+Eval("SupplierID")%>'
                                        Text="Edit"></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_delete"
                                        NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToDelete="+Eval("ItemID")+"&SupplierIDToDelete="+Eval("SupplierID")%>'
                                        commandName="lnk_delete"
                                        Text="Delete"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
              <asp:Button ID="btnConfirm" Style="box-shadow: 3px 3px 7px grey;  margin-left:42%;" CssClass="btn-custom11"
            runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
        </div>
        <br />

      
        <br />
        <br />

        <br />
        <br />
        <br />

        <br />
    </div>
</asp:Content>
