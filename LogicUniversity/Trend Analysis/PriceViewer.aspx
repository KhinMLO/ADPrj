<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriceViewer.aspx.cs" Inherits="LogicUniversity.Trend_Analysis.PriceViewer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script src="../crystalreportviewers13/js/crviewer/crv.js"></script>
    <script src="../crystalreportviewers13/js/crviewer/Viewer.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" />
    <div>
    
    </div>
    </form>
</body>
</html>
