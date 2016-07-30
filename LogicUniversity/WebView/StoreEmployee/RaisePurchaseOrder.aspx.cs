using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class RaisePurchaseOrder : System.Web.UI.Page
    {
        RaisePOControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //MultiView1.Visible = true;
            crt = new RaisePOControl();
            if (!IsPostBack)
            {
               
                txtQuantityToOrder.Text = "0";
                txtRequiredDelivereyDate.Text = System.DateTime.Today.ToString();
                //if (Request["ItemID"] != null)
                //{
                //    String id = Request["ItemID"].ToString();
                //    Item item = crt.getItemByItemID(id);
                //    if (item != null)
                //    {
                //        ddlCategory.SelectedValue = item.CategoryID.ToString();
                //        List<Item> itemList = crt.getItemByCatID(item.CategoryID.ToString());

                //    }
                //}
                List<Category> catlist = crt.getAllCategory();
                if (catlist != null)
                {
                    foreach (Model.Category cat in catlist)
                    {
                        ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                    }
                    List<Item> itemList = crt.getItemByCatID("" + catlist[0].CategoryID);
                    if (itemList == null)
                        return;
                    foreach (Model.Item item in itemList)
                    {
                        ddlDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                    }
                    txtUnitOfMeasure.Text = itemList[0].UOM;
                    List<SupplierItem> siList = crt.getSupplierByItemID("" + itemList[0].ItemID);
                    if(siList == null)
                        return;
                    foreach(SupplierItem si in siList)
                    {
                        ddlSupplierName.Items.Add(new ListItem(si.Supplier.SupplierName, "" + si.SupplierID));
                    }
                    txtContactName.Text = siList[0].Supplier.ContactName;
                    txtContactEmail.Text = siList[0].Supplier.Email;
                    txtPhone.Text = siList[0].Supplier.PhNo;
                    txtFax.Text = siList[0].Supplier.FaxNo;
                }
                if (Request["ItemItemIDToDelete"] != null && Request["SupplierIDToDelete"] !=null)
                {
                    //Label1.Text = Request["ItemItemIDToDelete"].ToString() + Request["SupplierIDToDelete"].ToString();
                    _delete(Request["ItemItemIDToDelete"].ToString(), Request["SupplierIDToDelete"].ToString());
                }

                if (Request["ItemItemIDToEdit"] != null && Request["SupplierIDToEdit"] != null)
                {
                    //Label1.Text = Request["ItemItemIDToEdit"].ToString()+Request["SupplierIDToEdit"].ToString();
                    _Edit(Request["ItemItemIDToEdit"].ToString(), Request["SupplierIDToEdit"].ToString());
                }
                if (Request["ItemID"] != null)
                {
                    Item i = crt.getItemByItemID(Request["ItemID"]);
                    ddlCategory.SelectedValue = i.CategoryID.GetValueOrDefault().ToString();
                    List<Item> iList = crt.getItemByCatID("" + i.CategoryID);
                    if (iList == null)
                        return;
                    ddlDescription.Items.Clear();
                    foreach (Model.Item item in iList)
                    {
                        ddlDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                    }
                    ddlDescription.SelectedValue = i.ItemID;
                    txtUnitOfMeasure.Text = i.UOM;
                    txtQuantityToOrder.Text = i.ReorderQty.GetValueOrDefault().ToString();

                    List<SupplierItem> siList = crt.getSupplierByItemID("" + i.ItemID);
                    if (siList == null)
                        return;
                    ddlSupplierName.Items.Clear();
                    foreach (SupplierItem si in siList)
                    {
                        ddlSupplierName.Items.Add(new ListItem(si.Supplier.SupplierName, "" + si.SupplierID));
                    }
                    txtContactName.Text = siList[0].Supplier.ContactName;
                    txtContactEmail.Text = siList[0].Supplier.Email;
                    txtPhone.Text = siList[0].Supplier.PhNo;
                    txtFax.Text = siList[0].Supplier.FaxNo;

                }
                gridViewDataBind();
            }
           
        }
        public void _delete(String itemid,String sid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + itemid +" - "+ sid);
            List<RaisePOVoucherItem> POItemList;
            if (Session["POItem"] == null)
                POItemList = new List<RaisePOVoucherItem>();
            else
                POItemList = (List<RaisePOVoucherItem>)Session["POItem"];
            foreach(RaisePOVoucherItem rpov in POItemList)
            {
                if(rpov.ItemID.Equals(itemid) && rpov.SupplierID.Equals(sid))
                {
                    POItemList.Remove(rpov);
                    gridViewDataBind();
                    return;
                }
            }
        }

        public void _Edit(String itemid,String sid)
        {
            System.Diagnostics.Debug.WriteLine("ReOrder Click" + itemid);
            List<RaisePOVoucherItem> POItemList;
            if (Session["POItem"] == null)
                POItemList = new List<RaisePOVoucherItem>();
            else
                POItemList = (List<RaisePOVoucherItem>)Session["POItem"];
            foreach (RaisePOVoucherItem rpov in POItemList)
            {
                if (rpov.ItemID.Equals(itemid) && rpov.SupplierID.Equals(sid))
                {
                    POItemList.Remove(rpov);
                    ddlCategory.SelectedItem.Text = rpov.Category;
                    ddlDescription.SelectedItem.Text = rpov.Description;
                    ddlSupplierName.SelectedValue = rpov.SupplierID;
                    txtRequiredDelivereyDate.Text = rpov.RequiredDeliveryDate;
                    txtQuantityToOrder.Text = rpov.Quantity.ToString();
                    gridViewDataBind();
                    return;
                }
            }

        }
        private void gridViewDataBind()
        {
            if (Session["POItem"] != null)
            {
                gvDataList.DataSource = (List<RaisePOVoucherItem>)Session["POItem"];
                gvDataList.DataBind();
                
            }
            else
            {
                gvDataList.DataSource = null;
                gvDataList.DataBind();
                btnConfirm.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (txtQuantityToOrder.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Please enter the quantiy.";
                return;
            }
            if(Convert.ToInt32(txtQuantityToOrder.Text)<=0)
            {
                lblMessage.Text = "Please enter the quantiy more than zero.";
                return;
            }
            if (txtRequiredDelivereyDate.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Please enter the date.";
                return;
            }
            if (Convert.ToDateTime(txtRequiredDelivereyDate.Text) < DateTime.Today)
            {
                lblMessage.Text = "Please enter the date greater than today";
                return;
            }
            if (ddlDescription.SelectedValue == null)
                return;

            List<RaisePOVoucherItem> POItemList;
            if (Session["POItem"] == null)
                POItemList = new List<RaisePOVoucherItem>();
            else
                POItemList = (List<RaisePOVoucherItem>)Session["POItem"];

            foreach (RaisePOVoucherItem poit in POItemList)
            {
                lblMessage.Text = string.Empty;
                if (poit.ItemID.Equals(ddlDescription.SelectedValue) && poit.SupplierID.Equals(ddlSupplierName.SelectedValue))
                {
                    lblMessage.Text = "Duplicated Item Quantity has been replaced";
                    poit.Quantity = Convert.ToInt32(txtQuantityToOrder.Text);
                    poit.TotalPrice = poit.Quantity * poit.UnitOfPrice;
                    poit.RequiredDeliveryDate = txtRequiredDelivereyDate.Text;
                    gridViewDataBind();
                    return;
                }
            }
            RaisePOVoucherItem poit_temp = new RaisePOVoucherItem();
            poit_temp.Category = ddlCategory.SelectedItem.Text;
            poit_temp.Description = ddlDescription.SelectedItem.Text;
            poit_temp.Quantity = Convert.ToInt32(txtQuantityToOrder.Text);
            poit_temp.UnitOfMeasure = txtUnitOfMeasure.Text;
            SupplierItem temp = ((SupplierItem)crt.getSupplierItemBySupplierIDAndItemID(ddlSupplierName.SelectedValue, ddlDescription.SelectedValue));
            poit_temp.UnitOfPrice = temp.Price.GetValueOrDefault();
            poit_temp.TotalPrice = poit_temp.Quantity * poit_temp.UnitOfPrice;
            poit_temp.ItemID = ddlDescription.SelectedValue;
            poit_temp.SupplierID = ddlSupplierName.SelectedValue;
            poit_temp.RequiredDeliveryDate = txtRequiredDelivereyDate.Text;
            POItemList.Add(poit_temp);
            Session["POItem"] = POItemList;
            gridViewDataBind();

            txtQuantityToOrder.Text = "0";
            txtRequiredDelivereyDate.Text = string.Empty;
            txtRequiredDelivereyDate.Text = System.DateTime.Today.ToString();
            btnConfirm.Visible = true;
            txtQuantityToOrder.Text = "0";
            txtRequiredDelivereyDate.Text = System.DateTime.Today.ToString();
            List<Category> catlist = crt.getAllCategory();
            if (catlist != null)
            {
                ddlCategory.Items.Clear();
                foreach (Model.Category cat in catlist)
                {
                    ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                }
                List<Item> itemList = crt.getItemByCatID("" + catlist[0].CategoryID);
                if (itemList == null)
                    return;
                ddlDescription.Items.Clear();
                foreach (Model.Item item in itemList)
                {
                    ddlDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                }
                txtUnitOfMeasure.Text = itemList[0].UOM;
                List<SupplierItem> siList = crt.getSupplierByItemID("" + itemList[0].ItemID);
                if (siList == null)
                    return;
                ddlSupplierName.Items.Clear();
                foreach (SupplierItem si in siList)
                {
                    ddlSupplierName.Items.Add(new ListItem(si.Supplier.SupplierName, "" + si.SupplierID));
                }
                txtContactName.Text = siList[0].Supplier.ContactName;
                txtContactEmail.Text = siList[0].Supplier.Email;
                txtPhone.Text = siList[0].Supplier.PhNo;
                txtFax.Text = siList[0].Supplier.FaxNo;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDescription.Items.Clear();
            ddlSupplierName.Items.Clear();
            List<Model.Item> itemList = crt.getItemByCatID(ddlCategory.SelectedValue);
            if (itemList == null || itemList.Count == 0)
            {
                txtUnitOfMeasure.Text = "";
                return;
            }
            foreach (Model.Item item in itemList)
            {
                ddlDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnitOfMeasure.Text = itemList[ddlDescription.SelectedIndex].UOM;

            List<SupplierItem> siList = crt.getSupplierByItemID("" + itemList[ddlDescription.SelectedIndex].ItemID);
            if (siList == null)
                return;
            foreach (SupplierItem si in siList)
            {
                ddlSupplierName.Items.Add(new ListItem(si.Supplier.SupplierName, "" + si.SupplierID));
            }
            txtContactName.Text = siList[0].Supplier.ContactName;
            txtContactEmail.Text = siList[0].Supplier.Email;
            txtPhone.Text = siList[0].Supplier.PhNo;
            txtFax.Text = siList[0].Supplier.FaxNo;
        }

        protected void ddlDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSupplierName.Items.Clear();
            List<Model.Item> itemlist = crt.getItemByCatID(ddlCategory.SelectedValue);
            txtUnitOfMeasure.Text = itemlist[ddlDescription.SelectedIndex].UOM;

            List<SupplierItem> siList = crt.getSupplierByItemID("" + itemlist[ddlDescription.SelectedIndex].ItemID);
            if (siList == null)
                return;
            foreach (SupplierItem si in siList)
            {
                ddlSupplierName.Items.Add(new ListItem(si.Supplier.SupplierName, "" + si.SupplierID));
            }
            txtContactName.Text = siList[0].Supplier.ContactName;
            txtContactEmail.Text = siList[0].Supplier.Email;
            txtPhone.Text = siList[0].Supplier.PhNo;
            txtFax.Text = siList[0].Supplier.FaxNo;
        }

        protected void ddlSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SupplierItem> itemlist = crt.getSupplierByItemID(ddlDescription.SelectedValue);
            txtContactName.Text = itemlist[ddlSupplierName.SelectedIndex].Supplier.ContactName;
            txtContactEmail.Text = itemlist[ddlSupplierName.SelectedIndex].Supplier.Email;
            txtPhone.Text = itemlist[ddlSupplierName.SelectedIndex].Supplier.PhNo;
            txtFax.Text = itemlist[ddlSupplierName.SelectedIndex].Supplier.FaxNo;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string result;
            List<PurchaseOrder> pList = new List<PurchaseOrder>();
            if (Session["POItem"] == null)
                return;
            else
                result = crt.confirmPOItem((List<RaisePOVoucherItem>)Session["POItem"], ((Model.StoreEmployee)Session["User"]).StoreEmployeeID,pList);
            if (result == "success")
            {
                Session["POItem"] = null;
                lblMessage.Text = "Purchase order is successfully raise";
                txtQuantityToOrder.Text = "";
                txtQuantityToOrder.Text = "0";
                txtRequiredDelivereyDate.Text = "";
                txtRequiredDelivereyDate.Text = System.DateTime.Today.ToString();
                gridViewDataBind();
                btnConfirm.Visible = false;
                string PList = "";
                foreach (PurchaseOrder po in pList)
                {
                    PList += po.PurchaseOrderID.ToString() + "@";
                }
                Response.Redirect("~/WebView/StoreEmployee/POConfirm.aspx?Data=" + PList);
            }
        }

        protected void gvDataList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Style.Add("display", "none");
            e.Row.Cells[9].Style.Add("display", "none");
          
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {



        }
    }
}