<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="OrderedTrend.aspx.cs" Inherits="LogicUniversity.Trend_Analysis.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" language="javascript">
function CustomValidator1_ClientValidate(source,args)
{ 
var listbox = document.getElementById("<%=ListBox1.ClientID %>");
var total = 0;
var i=0;
for( i = 0; i<listbox.options.length; i++ )
{
 if (listbox.options[i].selected) 
  {
   total ++; 
    if (total >3) {
      args.IsValid = false;
      return;
  }
  } 
 } 
 args.IsValid = true; return;
}
       </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 564px;
        }
        .auto-style2 {
            height: 67px;
        }
        .auto-style3 {
            width: 231px;
        }
        .auto-style5 {
            width: 527px;
        }
        .auto-style7 {
            width: 203px;
        }
        .auto-style8 {
            font-size: x-large;
        }
        .auto-style15 {
            width: 222px;
            height: 42px;
        }
        .auto-style16 {
            width: 222px;
        }
        .auto-style17 {
            font-size: x-large;
            width: 211px;
        }
        .auto-style19 {
            font-size: x-large;
            width: 211px;
            height: 42px;
        }
        .auto-style20 {
            width: 231px;
            height: 42px;
        }
        .auto-style21 {
            width: 527px;
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="auto-style1" style="margin-left:10%;">
            <tr>
                <td class="auto-style2" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <strong><span style="font-family:Arial; font-size:30px;" class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp; Stationery Ordered Trend - Trend Analysis &nbsp;<br />
                    <br />
                    </span></strong></td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                 <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label ID="Label3"
                        Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;"
                         runat="server" Text="Department :"></asp:Label>
                </td>
                <td><asp:DropDownList ID="ddldept" OnDataBound="ddldept_DataBound"
                    Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        
                    runat="server" Height="39px" Width="212px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                          style="color:red;"
                        runat="server" ControlToValidate="ddldept" InitialValue="0" ErrorMessage="Please make a selection"></asp:RequiredFieldValidator>
                </td>
                 <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4"
                        Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;"
                         runat="server" Text="Category :"></asp:Label>
                </td>
                <td>&nbsp;<asp:DropDownList ID="ddlcat" runat="server" Height="39px" Width="212px"  OnDataBound="ddlcat_DataBound"
                     Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator 
                          style="color:red;"
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlcat" InitialValue="0" ErrorMessage="Please make a selection"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style3">
                   
                </td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style5">
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1"
                        Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;"
                         runat="server" Text="Period :"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:ListBox ID="ListBox1" runat="server" 
                         Style="box-shadow: 3px 3px 7px grey; font-family: Arial; font-size: 16px;"
                        Height="91px" Width="214px" SelectionMode="Multiple"></asp:ListBox>
                    <asp:CustomValidator ID="CustomValidator1" 
                      style="color:red;"
                    ControlToValidate="ListBox1" runat="server" Display="Dynamic" ErrorMessage="Please select any 3 months only."
ClientValidationFunction="CustomValidator1_ClientValidate" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>  
                    <asp:RequiredFieldValidator 
                          style="color:red;"
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="ListBox1" ErrorMessage="Please make a selection" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
               
                <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                    <asp:Label ID="Label2"
                        Style="text-shadow: 5px 5px 7px #ffffcc; font-family: Arial; font-size: 19px;"
                         runat="server" Text="Criteria :"></asp:Label>
                </td>
                <td>
                  
                 
                    <asp:RadioButtonList ID="RadioButtonList1"  CssClass="radio"
                         Style="font-family: Arial; font-size: 16px;"
                        runat="server">
                        <asp:ListItem>Price</asp:ListItem>
                        <asp:ListItem>Quantity</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        style="color:red;"
                         runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Pleae make a selection"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style20">   
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style21">
                    
                </td>
            </tr>
           
            <tr>
               <td class="auto-style17"></td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Button 
                        CssClass="btn-custom11" Style="box-shadow: 5px 5px 10px grey; "
                        class="btn btn-lg btn-block btn-info"
                        ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    <br />
    <br />
</asp:Content>
