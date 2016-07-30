<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LogicUniversity.WebView.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      .btn-custom {
            width: 100px;
            height: 35px;
            font-family: Arial;
            font-size: 20px;
            font-weight: bold;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            -khtml-border-radius: 10px;
            border-radius: 10px;
            background-color: hsl(199, 24%, 45%) !important;
            background-repeat: repeat-x;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr="#e8eef1", endColorstr="#577c8e");
            background-image: -khtml-gradient(linear, left top, left bottom, from(#e8eef1), to(#577c8e));
            background-image: -moz-linear-gradient(top, #e8eef1, #577c8e);
            background-image: -ms-linear-gradient(top, #e8eef1, #577c8e);
            background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #e8eef1), color-stop(100%, #577c8e));
            background-image: -webkit-linear-gradient(top, #e8eef1, #577c8e);
            background-image: -o-linear-gradient(top, #e8eef1, #577c8e);
            background-image: linear-gradient(#e8eef1, #577c8e);
            border-color: #577c8e #577c8e hsl(199, 24%, 33%);
            color: #333 !important;
            text-shadow: 0 1px 1px rgba(255, 255, 255, 0.79);
            -webkit-font-smoothing: antialiased;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:250px; margin-top:50px;">

            <asp:Label ID="Label1"
                Style="font-family: 'Arial Rounded MT'; font-weight: bold; font-size: 30px;"
                runat="server" Text="Forgot PIN"></asp:Label>
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <table>
                <tr>
                    <td>
            <asp:Label ID="Label2" runat="server"
                Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;"
                Text="Enter PIN"></asp:Label>
                        </td>
                    <td>
            <asp:TextBox ID="txtPIN"
                Height="36px" Width="224px"
                Style="box-shadow: 5px 5px 9px grey; font-family: Arial; font-size: 16px;"
                runat="server"></asp:TextBox>
                        </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPIN" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
           </tr>
                <tr><td></td></tr><tr><td></td></tr><tr><td></td></tr>
                <tr>
                    <td>
            <asp:Label ID="Label3"
                Style="text-shadow: 5px 5px 9px #ffffcc; font-family: Arial; font-size: 19px;"
                runat="server" Text="Enter Confirm PIN"></asp:Label>
                        </td>
                    <td>
            <asp:TextBox
                Height="39px" Width="224px"
                Style="box-shadow: 5px 5px 9px grey; font-family: Arial; font-size: 16px;"
                ID="txtConfirmPIN" runat="server"></asp:TextBox>
                        </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ControlToValidate="txtConfirmPIN" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
                </table>
            <asp:Button
                CssClass="btn-custom" Style="box-shadow: 5px 5px 10px grey;"
                class="btn btn-lg btn-block btn-info"
                ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change" />

        </div>
    </form>
</body>
</html>
