using LogicUniversity.Trend_Analysis;
using LogicUniversity.TrendDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.Trend_Analysis
{
    public partial class PriceViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TrendDataSet ds1 = new TrendDataSet();
            PriceTableAdapter adapter = new PriceTableAdapter();
            adapter.Fill(ds1.Price);
            OnePrice report5 = new OnePrice();
            OneDepAllCatPrice report6 = new OneDepAllCatPrice();
            OneCatAllDepPrice report7 = new OneCatAllDepPrice();
            AllDepAllCatPrice report8 = new AllDepAllCatPrice();



            string a = (string)Session["cname"];
            string b = (string)Session["dname"];

            if (a!="All" && b!="All")
            {
                report5.Load(Server.MapPath("~/OnePrice.rpt"));
                report5.SetDataSource(ds1);
                report5.SetParameterValue("pmdnam", Session["dname"]);
                report5.SetParameterValue("pmcn", Session["cname"]);
                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report5.SetParameterValue("pmm1", Session["m1"]);
                    report5.SetParameterValue("pmm2", Session["m2"]);
                    report5.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report5.SetParameterValue("pmm1", Session["m1"]);
                    report5.SetParameterValue("pmm2", Session["m2"]);
                    report5.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report5.SetParameterValue("pmm1", Session["m1"]);
                    report5.SetParameterValue("pmm2", Session["m2"]);
                    report5.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report5;
                CrystalReportViewer1.DisplayToolbar = true;
            }


            else if(a=="All"&&b!="All")
            {

                report6.Load(Server.MapPath("~/OneDepAllCatPrice.rpt"));
                report6.SetDataSource(ds1);
                report6.SetParameterValue("pmdn", Session["dname"]);
                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report6.SetParameterValue("pmm1", Session["m1"]);
                    report6.SetParameterValue("pmm2", Session["m2"]);
                    report6.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report6.SetParameterValue("pmm1", Session["m1"]);
                    report6.SetParameterValue("pmm2", Session["m2"]);
                    report6.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report6.SetParameterValue("pmm1", Session["m1"]);
                    report6.SetParameterValue("pmm2", Session["m2"]);
                    report6.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report6;
                CrystalReportViewer1.DisplayToolbar = true;
                
            }

            else if (a!="All"&&b=="All")
            {
                report7.Load(Server.MapPath("~/OneCatAllDepPrice.rpt"));
                report7.SetDataSource(ds1);
                report7.SetParameterValue("pmcn", Session["cname"]);
                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report7.SetParameterValue("pmm1", Session["m1"]);
                    report7.SetParameterValue("pmm2", Session["m2"]);
                    report7.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report7.SetParameterValue("pmm1", Session["m1"]);
                    report7.SetParameterValue("pmm2", Session["m2"]);
                    report7.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report7.SetParameterValue("pmm1", Session["m1"]);
                    report7.SetParameterValue("pmm2", Session["m2"]);
                    report7.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report7;
                CrystalReportViewer1.DisplayToolbar = true;

            }

            else if (a == "All" && b == "All")
           
            {
                report8.Load(Server.MapPath("~/AllDepAllCatPrice.rpt"));
                report8.SetDataSource(ds1);
             

                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report8.SetParameterValue("pmm1", Session["m1"]);
                    report8.SetParameterValue("pmm2", Session["m2"]);
                    report8.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report8.SetParameterValue("pmm1", Session["m1"]);
                    report8.SetParameterValue("pmm2", Session["m2"]);
                    report8.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report8.SetParameterValue("pmm1", Session["m1"]);
                    report8.SetParameterValue("pmm2", Session["m2"]);
                    report8.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report8;
                CrystalReportViewer1.DisplayToolbar = true;
                
            }
                        
        }
    }
}