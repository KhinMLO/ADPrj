<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="POConfirm.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.POConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
     <div class="margingAlignTop">
        <asp:Label ID="Label2" runat="server"
            Style="font-family: 'Arial Rounded MT'; font-weight: bold; margin-left: 1.5%; font-size: 30px;" Text="PO Sent List"></asp:Label>
         <br />
        <br />
    </div>
  
    <div id="mainContainer" class="container" style="width: 98%; position: relative; margin-left: 1.5%;">
        <div class="shadowBox">
            <div class="table-responsive">
          <div class="scrolling-table" style="width:auto; height:300px;">
                      <asp:GridView 
                          HeaderStyle-CssClass="grid_head"
                        CssClass="table table-hover table-bordered"
                        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                        HeaderStyle-BackColor="WhiteSmoke"
                        runat="server"
                          ID="gvData"  >
                    
                      </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
