<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageSupplier.aspx.cs" Inherits="LogicUniversity.WebView.Finance.ManageSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .Pager span
        {
            color: #333;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
        }
        .Pager a
        {
            text-align: center;
            display: inline-block;
            width: 20px;
            border: 1px solid #ccc;
            color: #fff;
            color: #333;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
        .highlight
        {
            background-color: #FFFFAF;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:50%; border:none; margin-left:35%;">
        <tr>
            <td colspan="3"><asp:Label ID="Label1" 
                style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:30px; margin-left:15%;"
                runat="server" Text="Manage Supplier"></asp:Label><br /></td>
        </tr>
       
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label3" runat="server" Text="SupplierID"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtSupplierID" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtSupplierID" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label4" runat="server" Text="Supplier Name"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtSupplierName" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtSupplierName" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label5" runat="server" Text="Contact Name"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtContactName" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtContactName" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label6" runat="server" Text="Phone No"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtPhoneNo" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtPhoneNo" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label7" runat="server" Text="Fax No"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtFaxNo" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtFaxNo"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label8" runat="server" Text="Address"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtAddress" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtAddress" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                 ID="Label2" runat="server" Text="Email"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  Height="30px" Width="179px"
                ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtEmail" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label9" runat="server" Text="GSTRegistration"></asp:Label>&nbsp;:</td>
            <td><asp:TextBox 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;" Height="30px" Width="179px"
                ID="txtGSTRegistration" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtGSTRegistration" ></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr><td><br /></td></tr>
        <tr>
            <td colspan="4"><asp:Button cssClass="btn-custom11"    
                    style="box-shadow: 5px 5px 10px grey; margin-left:7%;" class="btn btn-lg btn-block btn-info"
                ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
           <asp:Button cssClass="btn-custom11"    
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                ID="btnClearAll" runat="server" Text="Clear All" OnClick="btnClearAll_Click" /></td>
        </tr>
        <tr><td></td></tr>
        <tr><td></td></tr>
         <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
    </table>
    <br />
    <br />
    
                        <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:1.5%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView  HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"
        AllowPaging="True" PageSize="2" 
         
        ID="gvDataList" runat="server" OnPageIndexChanging="gvDataList_PageIndexChanging" OnRowCreated="gvDataList_RowCreated">
   <PagerStyle CssClass="pagination-ys" />
          <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/Finance/ManageSupplier.aspx?IDToEdit="+Eval("SupplierID")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/Finance/ManageSupplier.aspx?IDToDelete="+Eval("SupplierID")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                              </ItemTemplate>
             </asp:TemplateField>
                                        
         </Columns>
         </asp:GridView>
                                    </div>
                </div>
                            </div>
</asp:Content>
