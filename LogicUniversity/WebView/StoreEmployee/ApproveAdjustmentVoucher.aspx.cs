using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;
using System.Data;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class ApproveAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new AdjustmentVoucherControl();
            if (!IsPostBack)
            {
                List<RaiseAdjustmentVoucherItem> l = new List<RaiseAdjustmentVoucherItem>();
                l = crt.getToApproveAdjItemList(((Model.StoreEmployee)Session["User"]).StoreEmployeeID);


                this.gvAdjVoucher.DataSource =l;  // set the datasource of the grid

                gvAdjVoucher.DataBind();

                if (Request["ItemCodeToDelete"] != null)
                {
                    String id = Request["ItemCodeToDelete"].ToString();
                    _delete(id);
                }

                if (Request["ItemCodeToEdit"] != null)
                {
                    String id = Request["ItemCodeToEdit"].ToString();
                    _Edit(id);
                }
            }
        }

        public void _delete(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + itemid);

        }

        public void _Edit(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("ReOrder Click" + itemid);

        }



        protected void gvAdjVoucher_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Style.Add("display", "none");
                gvAdjVoucher.HeaderRow.Cells[2].Visible = false;

                e.Row.Cells[3].Style.Add("display", "none");
                gvAdjVoucher.HeaderRow.Cells[3].Visible = false;

                /*   <%
                              for(int i=0;i<gvAdjVoucher.Rows.Count;i++)
                              {
                                  gvAdjVoucher.Rows[i].Cells[2].Style.Add("display", "none");
                                  gvAdjVoucher.Rows[i].Cells[9].Style.Add("display", "none");

                                  gvAdjVoucher.HeaderRow.Cells[2].Visible = false;

                              
                                  gvAdjVoucher.HeaderRow.Cells[9].Visible = false;    
                              }
                           
                               %>


               */
            }
        }

        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gvAdjVoucher.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gvAdjVoucher.Rows[rowIndex];
                GridViewRow previousRow = gvAdjVoucher.Rows[rowIndex + 1];


                if (currentRow.Cells[3].Text == previousRow.Cells[3].Text)
                {
                    if (previousRow.Cells[3].RowSpan < 2)
                    {
                        currentRow.Cells[3].RowSpan = 2;
                        

                    }
                    else
                    {
                        currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                        currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                        currentRow.Cells[2].RowSpan = previousRow.Cells[2].RowSpan + 1;
                        currentRow.Cells[3].RowSpan = previousRow.Cells[3].RowSpan + 1;
                        currentRow.Cells[4].RowSpan = previousRow.Cells[4].RowSpan + 1;

                        currentRow.Cells[5].RowSpan = previousRow.Cells[5].RowSpan + 1;
                        currentRow.Cells[6].RowSpan = previousRow.Cells[6].RowSpan + 1;
                        currentRow.Cells[7].RowSpan = previousRow.Cells[7].RowSpan + 1;
                        currentRow.Cells[8].RowSpan = previousRow.Cells[8].RowSpan + 1;
                        currentRow.Cells[9].RowSpan = previousRow.Cells[9].RowSpan + 1;

                    }
                    
                    previousRow.Cells[3].Visible = false;
                   

                }
              
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //List<RaiseAdjustmentVoucherItem> ApproveList = new List<RaiseAdjustmentVoucherItem>();
            //for (int i = 0; i < gvAdjVoucher.Rows.Count; i++)
            //{
            //    RaiseAdjustmentVoucherItem approve = new RaiseAdjustmentVoucherItem();

            //    string requisitionItemID = gvAdjVoucher.Rows[i].Cells[1].Text; //get the requisition item id from gridview
            //    string reason = ((TextBox)gvAdjVoucher.Rows[i].Cells[8].FindControl("txtReason")).Text;

            //    RadioButton rdn_Approve = (RadioButton)gvAdjVoucher.Rows[i].Cells[6].FindControl("Rdn_Approve");// to check the Radio Button from gridview
            //    RadioButton rdn_Reject = (RadioButton)gvAdjVoucher.Rows[i].Cells[6].FindControl("Rdn_Reject");// to check the Radio from gridview

            //    if (rdn_Approve.Checked == true)
            //        ApproveList.Add(new Model.RequisitionApproval(Convert.ToInt32(requisitionItemID), "Approve", reason)); // add the object 3 args constructure to list

            //    else if (rdn_Reject.Checked == true)
            //        ApproveList.Add(new Model.RequisitionApproval(Convert.ToInt32(requisitionItemID), "Reject", reason)); // add the object 3 args constructure to list
            //}

            //string result = crt.ApproveRequisition(ApproveList);

            //gvAdjVoucher.DataSource = crt.getToApproveAdjItemList(((Model.StoreEmployee)Session["User"]).StoreEmployeeID);
            //gvAdjVoucher.DataBind();

            String status;
            String AdjItemID;
            List<RaiseAdjustmentVoucherItem> listApp = new List<RaiseAdjustmentVoucherItem>();
            for (int i = 0; i < gvAdjVoucher.Rows.Count; i++)
            {
                
                
                RadioButton rdn_Approve = (RadioButton)gvAdjVoucher.Rows[i].Cells[1].FindControl("Rdn_Approve");// to check the Radio Button from gridview
                RadioButton rdn_Reject = (RadioButton)gvAdjVoucher.Rows[i].Cells[2].FindControl("Rdn_Reject");// to check the Radio from gridview

                if (rdn_Approve.Checked == true)
                {
                    status = "Approved";
                    AdjItemID = gvAdjVoucher.Rows[i].Cells[2].Text;
                    listApp.Add(new RaiseAdjustmentVoucherItem(AdjItemID,status));
                }

                else if (rdn_Reject.Checked == true)
                {
                    status = "Rejected";
                    AdjItemID = gvAdjVoucher.Rows[i].Cells[2].Text;
                    listApp.Add(new RaiseAdjustmentVoucherItem(AdjItemID, status));
                    
                }
            }
            crt.getToApproveAdjItemList(listApp, (Model.StoreEmployee)Session["User"]);

            List<RaiseAdjustmentVoucherItem> l = new List<RaiseAdjustmentVoucherItem>();
            l = crt.getToApproveAdjItemList(((Model.StoreEmployee)Session["User"]).StoreEmployeeID);


            this.gvAdjVoucher.DataSource = l;  // set the datasource of the grid

            gvAdjVoucher.DataBind();

        }
    }
}