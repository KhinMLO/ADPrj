using LogicUniversity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;

namespace LogicUniversity.Trend_Analysis
{
    public partial class WebForm1 : System.Web.UI.Page
    {
          protected void Page_Load(object sender, EventArgs e)
        {
            ReportControl rc = new ReportControl();

            if (!IsPostBack)
            {
                using (var ctx = new LogicUniversityEntities())
                {

                    var dept = from depart in ctx.Departments
                               select new { depart.DepartmentName };

                    ddldept.DataValueField = "DepartmentName";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataSource = dept.ToList();
                    DataBind();

                    var cat = from categ in ctx.Categories
                              select new { categ.CategoryName };
                    ddlcat.DataValueField = "CategoryName";
                    ddlcat.DataTextField = "CategoryName";
                    ddlcat.DataSource = cat.ToList();
                    DataBind();


                    ListBox1.DataSource = rc.getmonths().ToList();
                    DataBind();
                }
            }

        }
          protected void ddldept_DataBound(object sender, EventArgs e)
          {
              ddldept.Items.Insert(0, new ListItem("--Select--", "0"));
              ddldept.Items.Insert(1, new ListItem("All", "1"));
          }


          protected void ddlcat_DataBound(object sender, EventArgs e)
          {
              ddlcat.Items.Insert(0, new ListItem("--Select--", "0"));
              ddlcat.Items.Insert(1, new ListItem("All", "1"));
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

                if (RadioButtonList1.SelectedItem.Text == "Quantity")
                {                    
                    Session["cname"] = ddlcat.SelectedItem.Text;
                    Session["dname"] = ddldept.SelectedItem.Text;
                                                                              
                        ArrayList lbox = new ArrayList();
                        foreach (ListItem items in ListBox1.Items)
                        {
                            if (items.Selected)
                                lbox.Add(items.Text);
                        }

                        Session["lcnt"] = lbox.Count;
                        if (lbox.Count == 3)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = lbox[1].ToString();
                            Session["m3"] = lbox[2].ToString();
                        }

                        else if (lbox.Count == 2)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = lbox[1].ToString();
                            Session["m3"] = "";
                        }

                        else if (lbox.Count == 1)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = "";
                            Session["m3"] = "";
                        }                  

                     Response.Redirect("~/Trend Analysis/TrendViewer.aspx");               
                  }

                else if(RadioButtonList1.SelectedItem.Text == "Price")
                {                                     
                    Session["cname"] = ddlcat.SelectedItem.Text;
                    Session["dname"] = ddldept.SelectedItem.Text;
                                                                              
                        ArrayList lbox = new ArrayList();
                        foreach (ListItem items in ListBox1.Items)
                        {
                            if (items.Selected)
                                lbox.Add(items.Text);
                        }

                        Session["lcnt"] = lbox.Count;
                        if (lbox.Count == 3)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = lbox[1].ToString();
                            Session["m3"] = lbox[2].ToString();
                        }

                        else if (lbox.Count == 2)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = lbox[1].ToString();
                            Session["m3"] = "";
                        }

                        else if (lbox.Count == 1)
                        {
                            Session["m1"] = lbox[0].ToString();
                            Session["m2"] = "";
                            Session["m3"] = "";
                        }                  

                     Response.Redirect("~/Trend Analysis/PriceViewer.aspx");               
                  }


                }


                }

            } 

  
