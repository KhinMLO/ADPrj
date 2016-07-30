using LogicUniversity;
using LogicUniversity.DataSetFinalTableAdapters;
using LogicUniversity.StaReqTrend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.DataSetFinalTableAdapters;


namespace LogicUniversity.StaReqTrend
{
    public partial class ReqTrendView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSetFinal ds = new DataSetFinal();
            DepartmentTableAdapter adapter = new DepartmentTableAdapter();
            adapter.Fill(ds.Department);
            Requestions report = new Requestions();
            AllDepReq report1 = new AllDepReq();

            string a = (string)Session["ddvalue"];

            if (a != "All")
            {
                report.Load(Server.MapPath("~/Requestions.rpt"));
                report.SetDataSource(ds);
                report.SetParameterValue("pmdept", Session["ddvalue"]);

                int l = (int)Session["lct"];

                if (l == 3)
                {
                    report.SetParameterValue("pmmonth", Session["mn1"]);
                    report.SetParameterValue("pmmonth2", Session["mn2"]);
                    report.SetParameterValue("pmmonth3", Session["mn3"]);

                }

                else if (l == 2)
                {
                    report.SetParameterValue("pmmonth", Session["mn1"]);
                    report.SetParameterValue("pmmonth2", Session["mn2"]);
                    report.SetParameterValue("pmmonth3", Session["mn3"]);
                }

                else if (l == 1)
                {
                    report.SetParameterValue("pmmonth", Session["mn1"]);
                    report.SetParameterValue("pmmonth2", Session["mn2"]);
                    report.SetParameterValue("pmmonth3", Session["mn3"]);
                }

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.DisplayToolbar = true;
            }

            else if(a=="All")
            {
                report1.Load(Server.MapPath("~/AllDepReq.rpt"));
                report1.SetDataSource(ds);

                int l = (int)Session["lct"];

                if (l == 3)
                {
                    report1.SetParameterValue("pmmonth", Session["mn1"]);
                    report1.SetParameterValue("pmmonth2", Session["mn2"]);
                    report1.SetParameterValue("pmmonth3", Session["mn3"]);

                }

                else if (l == 2)
                {
                    report1.SetParameterValue("pmmonth", Session["mn1"]);
                    report1.SetParameterValue("pmmonth2", Session["mn2"]);
                    report1.SetParameterValue("pmmonth3", Session["mn3"]);
                }

                else if (l == 1)
                {
                    report1.SetParameterValue("pmmonth", Session["mn1"]);
                    report1.SetParameterValue("pmmonth2", Session["mn2"]);
                    report1.SetParameterValue("pmmonth3", Session["mn3"]);
                }

                CrystalReportViewer1.ReportSource = report1;
                CrystalReportViewer1.DisplayToolbar = true;

            }


        }
    }
}