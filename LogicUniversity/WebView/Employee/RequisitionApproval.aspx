<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RequisitionApproval.aspx.cs" Inherits="LogicUniversity.WebView.Employee.Requisition_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 90%; margin-left:15%;">
       
           
        <asp:Label ID="Label3" Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px; 
position: relative; margin-left: 32%;"
            runat="server" Text="Approve Request"></asp:Label>

        <br />
        <br />
        <asp:Label Style="font-family: Arial; font-size: 16px; position: relative; margin-left: -10%;"
            ID="Label2" runat="server" Text="Department Name:"></asp:Label>
        <asp:Label Style="font-family: Arial; position: relative; font-size: 16px;"
            ID="lblDearptmentName" runat="server"></asp:Label>
            </div>
        <br />
          <%
              if (gvDataList.Rows.Count > 0)
            { 
             %>
      <div id="mainContainer" class="container" style="width: 100%; position: relative; margin-left: 5%;">
        
            <div class="shadowBox">
                <div class="table-responsive">

                    <div class="scrolling-table2" style="height:300px;">
                        <asp:GridView ID="gvDataList" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" 
                            Font-Size="Large" ForeColor="#333333" GridLines="None"
                            HeaderStyle-CssClass="grid_head" margin-left="-400px"
                            CssClass="table table-hover table-bordered ttable2"
                            RowStyle-CssClass="grid_row" HorizontalAlign="Center"
                            HeaderStyle-BackColor="WhiteSmoke" OnRowCreated="gvDataList_RowCreated">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="RequisitionForm" HeaderText="RequisitionID" />

                                <asp:BoundField DataField="RequisitionItemID" HeaderText="RequisitionItemID" />

                                <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />

                                <asp:BoundField DataField="SubmittedDate" HeaderText="SubmittedDate" />

                                <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />

                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
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

                                <asp:TemplateField HeaderText="Reason">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtReason" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                          
                        </asp:GridView>
                        <br />
                    </div>
                </div>
            </div>
       </div>
        <br />
        <br />
     <div style="width: 90%; margin-left:10%;">
        <asp:Button CssClass="btn-custom11" Style="box-shadow: 5px 5px 10px grey; margin-left:40%;"
            ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        &nbsp;
         <%
        }
           else { 
             %>
        <br /><br /><br /><br />
         <asp:Label ID="Label4" Style="
             font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 28px; margin-left:34%;"
            runat="server"
            Text="There is no request pending your approval"></asp:Label>
        <%
            
       } %>
   </div>
    <br />
    <br />
</asp:Content>
