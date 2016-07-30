<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
           
        }

            table th {
                background-color: #F7F7F7;
                color: black;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                
                border-color: #ccc;
            }
        .auto-style8 {
            width: 178px;
        }
        .auto-style9 {
            width: 105px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="width: 90%; margin-left:100px;">
        <div class="table-responsive">
            <table style="width: 91%; border:none;">
                <tr>
                

                    <td colspan=7">
                        <asp:Label ID="Label3" runat="server" Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px; margin-left:47.7%;"
                            Text="Request List"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                </tr>
                <tr>
                    <td></td><td></td>
                    <td class="auto-style8">
                        <asp:Label ID="Label2" runat="server" Style="font-family: Arial; font-size: 19px;"
                            Text="Item Description"></asp:Label>
                    &nbsp;:</td>
                    <td>
                        <asp:TextBox ID="txtItemDescription"
                            Style="box-shadow: 5px 5px 6px grey; font-family: Arial; font-size: 16px;"
                            Height="31px" Width="192px"
                            runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label1" Style="text-shadow: 10px 10px 22px #ffffcc; font-family: Arial; font-size: 19px;"
                            runat="server" Text="Status"></asp:Label>
                    &nbsp;:</td>
                    <td>

                        <asp:DropDownList ID="ddlStatus" runat="server"
                            Style="box-shadow: 5px 5px 6px grey; font-family: Arial; font-size: 16px;"
                            Height="36px" Width="190px">
                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="PendingApproval">Pending Approval</asp:ListItem>
                            <asp:ListItem Value="PartiallyFulfilled">Partially Fulfilled</asp:ListItem>
                            <asp:ListItem>Collected</asp:ListItem>
                            <asp:ListItem Value="NotCollected">Not Collected</asp:ListItem>
                            <asp:ListItem>Approved</asp:ListItem>
                            <asp:ListItem Value="Denied">Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn-custom11" Style="box-shadow: 5px 5px 10px grey;"
                            OnClick="btnSearch_Click" Text="Search" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        
                    </td><td></td><td colspan="2"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        <br />
         <%
             if (gvList.Rows.Count > 0)
            { 
             %>
        <div id="mainContainer" class="container" style="width: 100%; position: relative; margin-left: -1%;">
            <div class="shadowBox">
                <div class="table-responsive" style="width:102%;">
                    <asp:GridView ID="gvList" runat="server"
                        HeaderStyle-CssClass="grid_head" 
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"
                        OnRowCreated="gvList_RowCreated" AllowPaging="True"
                        OnPageIndexChanging="gvList_PageIndexChanging">

                        <PagerStyle CssClass="pagination-ys" />

                        <Columns>


                            <asp:TemplateField HeaderText="Re_Order">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_Reorder"
                                        NavigateUrl='<%# "~/WebView/Employee/ViewRequest.aspx?RequisitionFormIDToReOder=" + Eval("RequisitionForm")%>'
                                        commandName="lnk_reorder"
                                        Text="ReOrder"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_edit"
                                        NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?RequisitionFormID=" + Eval("RequisitionForm")%>' Text="Edit"></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnk_delete"
                                        NavigateUrl='<%# "~/WebView/Employee/ViewRequest.aspx?RequisitionFormIDToDelete=" + Eval("RequisitionForm")%>'
                                        commandName="lnk_delete"
                                        Text="Delete"></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>



                        </Columns>
                        <HeaderStyle />
                       
                        <RowStyle />
                    </asp:GridView>
                </div>
            </div>
        </div></div>
          <%
        }
           else { 
             %>
        <br /><br /><br /><br />
         <asp:Label ID="Label4" Style=" color:midnightblue;
             font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 28px;"
            runat="server"
            Text="There is no request."></asp:Label>
        <%
            
       } %>
    
    &nbsp;
</asp:Content>
