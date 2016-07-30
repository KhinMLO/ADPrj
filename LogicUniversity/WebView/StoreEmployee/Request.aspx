<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true"
    CodeBehind="Request.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="LogicUniversity.WebView.StoreEmployee.Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="margingAlignTop">
        <asp:Label ID="Label1" runat="server"
            Style="font-family: 'Arial Rounded MT'; font-weight: bold; margin-left: 37%; font-size: 30px;" Text="Stationary Retrieval List"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
    </div>
    <%if(gvDataList.Rows.Count>0)
      { %>
    <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: 1.5%;">
        <div class="shadowBox">
            <div class="table-responsive">
                <div class="scrolling-table" style="width:auto; height:300px;">
                    <asp:GridView ID="gvDataList" HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"
                        runat="server" OnRowCreated="gvDataList_RowCreated"
                        Style="margin-right: 0px" OnRowDataBound="gvDataList_RowDataBound"
                        OnDataBound="gvDataList_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="ActualQty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server" Width="30px" OnTextChanged="txtQty_TextChanged"
                                        Text='<%# Eval("ActualQty") %>'
                                        AutoPostBack="true">
                                
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TotalRetrieved">
                                <ItemTemplate>
                                    <asp:TextBox ID="txttotalQty" runat="server" Width="30px"
                                        Text='<%# Eval("TotalReceived") %>'
                                        OnTextChanged="txttotalQty_TextChanged"
                                        AutoPostBack="true">
                                
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle />
                        <RowStyle />
                    </asp:GridView>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="margingAlign">
        <asp:Button 
             cssClass="btn-custom11" 
        style="box-shadow: 5px 5px 10px grey;margin-left: 39%;" class="btn btn-lg btn-block btn-info" 
            ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
    </div>
    <% }else { 
             %>
        <br /><br /><br /><br />
         <asp:Label ID="Label4" Style="
             font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 19px;margin-left:40px;"
            runat="server"
            Text="There is no Stationery Requisitions to be fulfilled"></asp:Label>
        <%
            
       } %>
    &nbsp;  <br />
    <br />
</asp:Content>
