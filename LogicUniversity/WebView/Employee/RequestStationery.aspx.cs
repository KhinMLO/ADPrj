using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        Control.RequestStationeryControl reqCrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            reqCrt = new Control.RequestStationeryControl();
            List<Model.Category> catlist = reqCrt.getAllCategory();
            if (catlist == null)
                return;
            if (!IsPostBack)
            {
                
                txtRequestQty.Text = "0";

                foreach (Model.Category cat in catlist)
                {
                    ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                }
                List<Model.Item> itemList = reqCrt.getItemByCatID("" + catlist[0].CategoryID);
                if (itemList == null)
                    return;
                foreach (Model.Item item in itemList)
                {
                    ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                }
                txtUnitOfMeasure.Text = itemList[0].UOM;
                if (Request["ItemIDToDelete"] != null)
                {
                    string id = Request["ItemIDToDelete"];
                    if (Session["ReqItem"] != null)
                    {
                        List<Model.RequestStationeryItem> temp_List = (List<Model.RequestStationeryItem>)Session["ReqItem"];
                        foreach(Model.RequestStationeryItem temp in temp_List)
                        {
                            if (temp.ItemID.Equals(id))
                            {
                                temp_List.Remove(temp);
                                break;
                            }
                        }
                    }
                    if (((List<Model.RequestStationeryItem>)Session["ReqItem"]).Count == 0 || Session["ReqItem"]==null)
                    {
                        btnClearAll.Enabled = false;
                        btnSubmit.Enabled = false;
                    }
                }
                if (Request["ItemID"] != null)
                {
                    string id = Request["ItemID"];
                    if (Session["ReqItem"] != null)
                    {
                        List<Model.RequestStationeryItem> temp_List = (List<Model.RequestStationeryItem>)Session["ReqItem"];
                        foreach (Model.RequestStationeryItem temp in temp_List)
                        {
                            if (temp.ItemID.Equals(id))
                            {
                                temp_List.Remove(temp);
                                ddlCategory.SelectedValue = reqCrt.getCategoryIDbyItemID(temp.ItemID);
                                //start
                                ddlItemDescription.Items.Clear();
                                List<Model.Item> ilist = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
                                if (ilist == null || ilist.Count == 0)
                                {
                                    txtUnitOfMeasure.Text = "";
                                    return;
                                }
                                foreach (Model.Item item in ilist)
                                {
                                    ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                                }
                                ddlItemDescription.SelectedValue = temp.ItemID;
                                txtUnitOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
                                //End
                                
                                txtUnitOfMeasure.Text = reqCrt.getUOMByItemID(temp.ItemID);
                                txtRequestQty.Text = temp.Quantity.GetValueOrDefault().ToString();
                                break;
                            }
                        }
                    }
                }
                if (Request["RequisitionFormID"] != null)
                {
                    int id = Convert.ToInt32(Request["RequisitionFormID"].ToString());
                    List<Model.RequestStationeryItem> temp_List = reqCrt.getRequisitionItemByReqID(id);
                    Model.RequestStationeryItem temp = temp_List[0];
                    temp_List.Remove(temp);
                    ddlItemDescription.Items.Clear();
                    
                    foreach(Model.RequestStationeryItem req in temp_List)
                    {
                        //req.ItemDescription = req.ItemDescription;
                        req.Reson = "";
                        req.Status = "";
                    }
                    Session["ReqItem"] = temp_List;
                    ddlCategory.SelectedValue = reqCrt.getCategoryIDbyItemID(temp.ItemID);
                    List<Model.Item> ilist = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
                    if (ilist == null || ilist.Count == 0)
                    {
                        txtUnitOfMeasure.Text = "";
                        return;
                    }
                    foreach (Model.Item item in ilist)
                    {
                        ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                    }
                    txtUnitOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
                    txtUnitOfMeasure.Text = reqCrt.getUOMByItemID(temp.ItemID);
                    txtRequestQty.Text = temp.Quantity.GetValueOrDefault().ToString();
                    ddlItemDescription.SelectedValue = temp.ItemID;
                }
            }
            gridViewDataBind();
        }

        private void gridViewDataBind()
        {
            if (Session["ReqItem"] != null)
            {
                gvData.DataSource = (List<Model.RequestStationeryItem>)Session["ReqItem"];
                gvData.DataBind();
                btnClearAll.Enabled = true;
                btnSubmit.Enabled = true;
            }
        }

        protected void ddlItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Item> itemlist = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
            txtUnitOfMeasure.Text = itemlist[ddlItemDescription.SelectedIndex].UOM;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItemDescription.Items.Clear();
            List<Model.Item> itemList = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
            if (itemList == null || itemList.Count==0) {
                txtUnitOfMeasure.Text = "";
                return;
            }
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnitOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            int ReqQty;
            try
            {
                ReqQty = Convert.ToInt32(txtRequestQty.Text);
            }
            catch (Exception)
            {
                lblMessage.Text = "please input the valid quantity";
                return;
            }
            if (txtRequestQty.Text.Equals(string.Empty) || ReqQty <= 0)
            {
                lblMessage.Text = "please add Quantity";
                return;
            }
           
            if (ddlItemDescription.SelectedValue == null)
                return;

            List<Model.RequestStationeryItem> ReqItem;
            if (Session["ReqItem"] == null)
                ReqItem = new List<Model.RequestStationeryItem>();
            else
                ReqItem = (List<Model.RequestStationeryItem>)Session["ReqItem"];
            lblMessage.Text = string.Empty;
            foreach(Model.RequisitionItem rit in ReqItem)
            {
                if (rit.ItemID.Equals(ddlItemDescription.SelectedValue))
                {
                    lblMessage.Text = "Duplicated Item Quantity has been replaced";
                    rit.Quantity = Convert.ToInt32(txtRequestQty.Text);
                /*    btnClearAll.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnClearAll.Visible = true;
                    btnSubmit.Visible = true;*/
                    gridViewDataBind();
                    return;
                }
            }
            Model.RequestStationeryItem temp = new Model.RequestStationeryItem();
            temp.ItemID = ddlItemDescription.SelectedValue;
            temp.Quantity = Convert.ToInt32(txtRequestQty.Text);
            temp.ItemDescription = ddlItemDescription.SelectedItem.Text;
            ReqItem.Add(temp);
            Session["ReqItem"] = ReqItem;
            gridViewDataBind();
            txtRequestQty.Text = "0";

            List<Model.Category> catlist = reqCrt.getAllCategory();
            ddlCategory.SelectedIndex = 0;
            List<Model.Item> itemList = reqCrt.getItemByCatID("" + catlist[0].CategoryID);
            if (itemList == null)
                return;
            ddlItemDescription.Items.Clear();
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnitOfMeasure.Text = itemList[0].UOM;
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["ReqItem"] == null || ((List<Model.RequestStationeryItem>)Session["ReqItem"]).Count==0)
            {
                lblMessage.Text = "please add Data First";
                return;
            }
            else
            {
                reqCrt.insertNewReqisition((List<Model.RequestStationeryItem>)Session["ReqItem"],((Model.Employee)Session["User"]).EmployeeID,"");
                lblMessage.Text = "Your request has been submitted";
                Session["ReqItem"] = null;
                gvData.DataSource = null;
                gvData.DataBind();
                txtRequestQty.Text = "0";
            /*    btnClearAll.Enabled = false;
                btnSubmit.Enabled = false;
                btnSubmit.Visible = false;
                btnClearAll.Visible = false;*/
            }
            
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            Session["ReqItem"] = null;
            gvData.DataSource = null;
            gvData.DataBind();
            txtRequestQty.Text = "0";
            btnClearAll.Enabled = false;
            btnSubmit.Enabled = false;
            btnSubmit.Visible = false;
            btnClearAll.Visible = false;
        }

        protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Style.Add("display", "none");
            e.Row.Cells[4].Style.Add("display", "none");
            e.Row.Cells[5].Style.Add("display", "none");
            e.Row.Cells[7].Style.Add("display", "none");
            e.Row.Cells[8].Style.Add("display", "none");
            //e.Row.Cells[4].Style.Add("display", "none");
        }
    }
}