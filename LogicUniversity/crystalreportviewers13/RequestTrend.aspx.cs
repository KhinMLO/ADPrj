using LogicUniversity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;

namespace LogicUniversity.StaReqTrend
{
    public partial class WebForm3 : System.Web.UI.Page
    {
       ReportControl rc = new ReportControl();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                using (var ctx = new LogicUniversityEntities())
                {

                    var dept = from depart in ctx.Departments
                               select new { depart.DepartmentName };

                    DropDownList1.DataValueField = "DepartmentName";
                    DropDownList1.DataTextField = "DepartmentName";
                    DropDownList1.DataSource = dept.ToList();
                    DataBind();


                    ListBox1.DataSource = rc.getmonths().ToList();
                    DataBind();
                }
            }

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList1.Items.Insert(1, new ListItem("All", "1"));
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                if (ListBox1.Items[i].Selected)
                    count++;
            }
            args.IsValid = (count > 3) ? false : true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session["ddvalue"] = DropDownList1.SelectedItem.Text;

            ArrayList lbox = new ArrayList();
            foreach (ListItem items in ListBox1.Items)
            {

                if (items.Selected)
                    lbox.Add(items.Text);
            }


            Session["lct"] = lbox.Count;

            if (lbox.Count == 3)
            {
                Session["mn1"] = lbox[0].ToString();
                Session["mn2"] = lbox[1].ToString();
                Session["mn3"] = lbox[2].ToString();
            }

            else if (lbox.Count == 2)
            {
                Session["mn1"] = lbox[0].ToString();
                Session["mn2"] = lbox[1].ToString();
                Session["mn3"] = "";
            }

            else if (lbox.Count == 1)
            {
                Session["mn1"] = lbox[0].ToString();
                Session["mn2"] = "";
                Session["mn3"] = "";
            }

            Response.Redirect("~/StaReqTrend/ReqTrendView.aspx");


        }


    }
}