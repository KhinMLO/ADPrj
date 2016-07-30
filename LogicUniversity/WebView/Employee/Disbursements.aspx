<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Disbursements.aspx.cs" Inherits="LogicUniversity.WebView.Employee.Disbursements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            width:30px;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }

        .Pager span {
            color: #333;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
            margin-top: inherit;
        }

        .Pager a {
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

        .highlight {
            background-color: #FFFFAF;
        }

        .auto-style2 {
            height: 38px;
        }

        .auto-style3 {
            height: 39px;
        }

        .auto-style8 {
            width: 382px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 90%; margin-left: 7%;">
        <asp:Label Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 40px;margin-left: 37%;"
            ID="lblTitle" runat="server" Text="Disbursements"></asp:Label>
        <table class="auto-style1" style="border: none;">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
                <td class="auto-style8">
                    <asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
                <td class="auto-style8">
                    <asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
                <td class="auto-style8">
                    <asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTxtRole" runat="server" Text="Role"></asp:Label></td>
                <td class="auto-style8">
                    <asp:Label ID="lblRole" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
       
     
        <%
           if( Session["type"] != "StoreEmployee")
           {
            if (gvDisbursement.Rows.Count > 0)
            { 
        %>
        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: -1%;">
            <div class="shadowBox">
                <div class="table-responsive">
                     <div class="scrolling-table" style="width:auto; height:auto;">
                    <asp:GridView ID="gvDisbursement" runat="server" AutoGenerateColumns="False" OnRowCreated="gvDisbursement_RowCreated"
                        HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"
                       >
                        
                        <Columns>
                            <asp:BoundField DataField="DisbursementID" HeaderText="Disbursement ID" />
                            <asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="collectionPointName" HeaderText="Collection Point" />
                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:HyperLink ID="detailsHyperLink" runat="server" NavigateUrl='<%# Eval("DisbursementID", "Disbursements.aspx?DisbursementID={0}") %>'
                                        Text="Details"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div></div>
            </div>
        </div>
        <%       
              
         if (
                gvDisbursementDetails.Rows.Count > 0

                )
            { 
        %>
        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: -1%;">
            <div class="shadowBox">
                <div class="table-responsive">
                    <asp:GridView ID="gvDisbursementDetails" runat="server" AutoGenerateColumns="False"
                        HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvDisbursementDetails_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:BoundField DataField="employeeName" HeaderText="Employee" />
                            <asp:BoundField DataField="itemDesc" HeaderText="Item Description" />
                            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="UOM" HeaderText="Unit of Measure" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <%
            }                                                                                               
           } %>

        <% else { 
             %>
      <br /><br /><br />
         <asp:Label ID="Label2" Style=" font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 19px; margin-left:35%"
            runat="server"
            Text="There is no Disbursement List available"></asp:Label>
        <%
        }                                                            
           } %>




        <%
        else
           { 
         if (gvAllDeptDisbursement.Rows.Count > 0)
            { 
        %>
        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: -1%;">
            <div class="shadowBox">
                <div class="table-responsive">
                     <div class="scrolling-table" style="width:auto; height:auto;">
                    <asp:GridView ID="gvAllDeptDisbursement" runat="server" AutoGenerateColumns="False"
                        HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"  
                        OnRowCreated="gvAllDeptDisbursement_RowCreated">
                      
                        <Columns>
                            <asp:BoundField DataField="DisbursementID" HeaderText="Disbursement ID" />
                            <asp:BoundField DataField="deptName" HeaderText="Department" />
                            <asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:HyperLink ID="detailsHyperLink" runat="server" NavigateUrl='<%# Eval("DisbursementID", "Disbursements.aspx?DisbursementID={0}") %>'
                                        Text="Details"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                    </div>
            </div>
        </div>
        <%
          
        if (
                gvStoreDisbursementDetails.Rows.Count > 0
                )
            { 
        %>
        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: -1%;">
            <div class="shadowBox">
                <div class="table-responsive">
                     <div class="scrolling-table" style="width:auto; height:auto;">
                    <asp:GridView ID="gvStoreDisbursementDetails" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke" 
                        OnRowCreated="gvStoreDisbursementDetails_RowCreated">
                     
                        <Columns>
                            <asp:BoundField DataField="requestID" HeaderText="Requisition ID" />
                            <asp:BoundField DataField="itemDesc" HeaderText="Item Description" />
                            <asp:BoundField DataField="quantityUOM" HeaderText="Quantity" />
                            <asp:BoundField DataField="requestDate" HeaderText="Request Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="employeeName" HeaderText="Employee Name" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            </div>

        </div>
         <%
            }                                                                                               
           } %>

        <% else { 
             %>
      
      <br /><br /><br />
         <asp:Label ID="Label1" Style=" font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 19px; margin-left:35%"
            runat="server"
            Text="There is no Disbursement List available"></asp:Label>
        <%
        }                                                           
           } %>

          
        <asp:Button
            CssClass="btn-custom1"
            Style="box-shadow: 5px 5px 10px grey; width: 300px;" class="btn btn-lg btn-block btn-info"
            ID="btnBackToDisbursements" runat="server" Text="Back To Disbursements" Visible="false" OnClick="btnClick_BackToDisbursements" />
    </div>
    <br /><br /><br />
       <asp:Label ID="lblDisbursementTitle" Style=" font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 19px; margin-left:37%" runat="server" Text=""></asp:Label>


</asp:Content>
