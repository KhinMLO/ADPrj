<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ApproveAdjustmentVoucher" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; margin-left: 90px;">

        <%
            if(gvAdjVoucher.Rows.Count>0)
            {
             %>
        <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: -4%;">
        <div class="shadowBox">
            <div class="table-responsive;">
                
        <table style=" margin-left:36%;border-color:none; border:none;"><tr>
      <td> <asp:Label ID="Label1" Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px; margin-left: -17px"
            runat="server" Text="Approve Adjustment Voucher"></asp:Label>
            </td> 
            </tr>
            </table>
        <br />
                <div class="scrolling-table" style="width:auto; height:300px;">
                        <asp:GridView ID="gvAdjVoucher"
                             CssClass="table table-hover table-bordered"
                            HeaderStyle-CssClass="grid_head"
                       
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"
                            runat="server" OnRowCreated="gvAdjVoucher_RowCreated">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Approve">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="Rdn_Approve" GroupName="Approve" runat="server" Checked="true" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reject">
                                    <ItemTemplate>

                                        <asp:RadioButton ID="Rdn_Reject" GroupName="Approve" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>

                     
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <asp:Button CssClass="btn-custom11" Style="box-shadow: 3px 3px 7px grey;  margin-left:38%;"
            ID="btnSubmit" runat="server"  OnClick="btnSubmit_Click" Text="Submit" />
        &nbsp;
         
&nbsp;
   
    <% }else { 
             %>
        <br /><br /><br /><br />
         <asp:Label ID="Label4" Style=" 
             font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 19px; margin-left:38%;"
            runat="server"
            Text="There is no adjustment voucher pending your approval"></asp:Label>
        <%
            
       } %>
         </div>
    <br />
    <br />
</asp:Content>
