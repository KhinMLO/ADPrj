
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Trend_Analysis;
using LogicUniversity.TrendDataSetTableAdapters;

namespace LogicUniversity.Trend_Analysis
{
    public partial class TrendViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //TrendDataSet ds = new TrendDataSet();
            //OneDepOneCatQuantTableAdapter adapter = new OneDepOneCatQuantTableAdapter();
            //adapter.Fill(ds.OneDepOneCatQuant);
            //OneDepOneCatQua report = new OneDepOneCatQua();
            //OneDepAllCatQua report1 = new OneDepAllCatQua();
            //AllDepAllCat report2 = new AllDepAllCat();
            //OneCatAllDepQua report3 = new OneCatAllDepQua();

            TrendDataSet ds = new TrendDataSet();
            OneDepOneCatQuantTableAdapter adapter = new OneDepOneCatQuantTableAdapter();
            adapter.Fill(ds.OneDepOneCatQuant);
            OneDepOneCatQua report = new OneDepOneCatQua();
            OneDepAllCatQua report1 = new OneDepAllCatQua();
            AllDepAllCat report2 = new AllDepAllCat();
            OneCatAllDepQua report3 = new OneCatAllDepQua();


            
            string a =(string)Session["cname"];
            string b = (string)Session["dname"];
           
            if (a != "All" && b!= "All")
            {
                report.Load(Server.MapPath("~/OneDepOneCatQua.rpt"));
                report.SetDataSource(ds);
                report.SetParameterValue("pmdeptname", Session["dname"]);
                report.SetParameterValue("pmCatname", Session["cname"]);


                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report.SetParameterValue("pmm1", Session["m1"]);
                    report.SetParameterValue("pmm2", Session["m2"]);
                    report.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report.SetParameterValue("pmm1", Session["m1"]);
                    report.SetParameterValue("pmm2", Session["m2"]);
                    report.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report.SetParameterValue("pmm1", Session["m1"]);
                    report.SetParameterValue("pmm2", Session["m2"]);
                    report.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.DisplayToolbar = true;
            }

            else if(a=="All" && b!="All")
            {
                report1.Load(Server.MapPath("~/OneDepAllCatQua.rpt"));
                report1.SetDataSource(ds);
                report1.SetParameterValue("pmdep", Session["dname"]);
                
                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report1.SetParameterValue("pmm1", Session["m1"]);
                    report1.SetParameterValue("pmm2", Session["m2"]);
                    report1.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report1.SetParameterValue("pmm1", Session["m1"]);
                    report1.SetParameterValue("pmm2", Session["m2"]);
                    report1.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report1.SetParameterValue("pmm1", Session["m1"]);
                    report1.SetParameterValue("pmm2", Session["m2"]);
                    report1.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report1;
                CrystalReportViewer1.DisplayToolbar = true;

            }


            else if(a!="All" && b=="All")
            {
                report3.Load(Server.MapPath("~/OneCatAllDepQua.rpt"));
                report3.SetDataSource(ds);
                
                report3.SetParameterValue("pmcn", Session["cname"]);

                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report3.SetParameterValue("pmm1", Session["m1"]);
                    report3.SetParameterValue("pmm2", Session["m2"]);
                    report3.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report3.SetParameterValue("pmm1", Session["m1"]);
                    report3.SetParameterValue("pmm2", Session["m2"]);
                    report3.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report3.SetParameterValue("pmm1", Session["m1"]);
                    report3.SetParameterValue("pmm2", Session["m2"]);
                    report3.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report3;
                CrystalReportViewer1.DisplayToolbar = true;
                

            }

            else if(b == "All" && a == "All")
            {
                report2.Load(Server.MapPath("~/AllDepAllCat.rpt"));
                report2.SetDataSource(ds);
              
                int m = (int)Session["lcnt"];

                if (m == 3)
                {
                    report2.SetParameterValue("pmm1", Session["m1"]);
                    report2.SetParameterValue("pmm2", Session["m2"]);
                    report2.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 2)
                {
                    report2.SetParameterValue("pmm1", Session["m1"]);
                    report2.SetParameterValue("pmm2", Session["m2"]);
                    report2.SetParameterValue("pmm3", Session["m3"]);
                }
                else if (m == 1)
                {
                    report2.SetParameterValue("pmm1", Session["m1"]);
                    report2.SetParameterValue("pmm2", Session["m2"]);
                    report2.SetParameterValue("pmm3", Session["m3"]);
                }

                CrystalReportViewer1.ReportSource = report2;
                CrystalReportViewer1.DisplayToolbar = true;
                
            }
        }
    }
}