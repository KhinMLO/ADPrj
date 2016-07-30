using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class RaiseAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new AdjustmentVoucherControl();
            List<Category> catlist = crt.getAllCategory();
            if (catlist == null)
                return;
            if (!IsPostBack)
            {
                txtQuantityToAdjust.Text = "0";
                txtReason.Text = "Reason";
                btnConfirm.Visible = false;
                foreach (Model.Category cat in catlist)
                {
                    ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                }
                List<Item> itemList = crt.getItemByCatID("" + catlist[0].CategoryID);
                if (itemList == null)
                    return;
                foreach (Model.Item item in itemList)
                {
                    ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                }
                txtUnifOfMeasure.Text = itemList[0].UOM;

                if (Request["ItemCodeToDelete"] != null)
                {
                    String id =Request["ItemCodeToDelete"].ToString();
                    _delete(id);
                }

                if (Request["ItemCodeToEdit"] != null)
                {
                    String id =Request["ItemCodeToEdit"].ToString();
                    _Edit(id);
                }
                gridViewDataBind();
            }
           
        }
        public void _delete(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + itemid);

            List<RaiseAdjustmentVoucherItem> POItemList;
            if (Session["AdjItem"] == null)
                POItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                POItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
            foreach (RaiseAdjustmentVoucherItem rpov in POItemList)
            {
                if (rpov.ItemCode.Equals(itemid))
                {
                    POItemList.Remove(rpov);
                    gridViewDataBind();
                    return;
                }
            }
        }

        public void _Edit(String itemid)
        {
            List<RaiseAdjustmentVoucherItem> POItemList;
            if (Session["AdjItem"] == null)
                POItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                POItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
            foreach (RaiseAdjustmentVoucherItem rpov in POItemList)
            {
                if (rpov.ItemCode.Equals(itemid))
                {
                    POItemList.Remove(rpov);
                    if (rpov.Quantity > 0)
                    {
                        txtQuantityToAdjust.Text = rpov.Quantity.ToString();
                        rblIncreaseOrDecrease.SelectedIndex = 0;
                    }
                    else
                    {
                        txtQuantityToAdjust.Text = (rpov.Quantity*-1).ToString();
                        rblIncreaseOrDecrease.SelectedIndex = 1;
                    }
                    txtReason.Text = rpov.Reason;
                    //start
                    List<Category> catlist = crt.getAllCategory();
                    if (catlist == null)
                        return;
                    ddlCategory.Items.Clear();
                    foreach (Model.Category cat in catlist)
                    {
                        ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                    }
                    ddlCategory.SelectedItem.Text = rpov.Category;
                    List<Item> itemList = crt.getItemByCatID("" + crt.getCategoryIDByCategory(rpov.Category));
                    if (itemList == null)
                        return;
                    ddlItemDescription.Items.Clear();
                    foreach (Model.Item item in itemList)
                    {
                        ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                    }
                    ddlItemDescription.SelectedValue = rpov.ItemCode;
                    txtUnifOfMeasure.Text = itemList[0].UOM;
                    //end
                    gridViewDataBind();
                    return;
                }
            }
        }
        private void gridViewDataBind()
        {
            if (Session["AdjItem"] != null)
            {
                gvList.DataSource = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
                btnConfirm.Visible = true;
                gvList.DataBind();
            }
            else
            {
                gvList.DataSource = null;
                gvList.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text=string.Empty;
            if (ddlItemDescription.SelectedValue == null)
                return;
            if (txtQuantityToAdjust.Text.Equals(string.Empty))
            {
                lblMessage.Text = "Please enter the quantity to adjust";
                return;
            }

            if (Convert.ToInt32(txtQuantityToAdjust.Text) <= 0)
            {
                lblMessage.Text = "The quantity to adjust should be greater than zero";
                return;
            }

            List<RaiseAdjustmentVoucherItem> AdjItemList;
            if (Session["AdjItem"] == null)
                AdjItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                AdjItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
            lblMessage.Text = string.Empty;
            foreach (RaiseAdjustmentVoucherItem ait in AdjItemList)
            {
                if (ait.ItemCode.Equals(ddlItemDescription.SelectedValue))
                {
                    lblMessage.Text = "Duplicated Item Quantity has been replaced";
                    if (rblIncreaseOrDecrease.SelectedValue.Equals("Decrease"))
                        ait.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text) * -1;
                    else
                        ait.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text);

                    ait.TotalPrice = ait.Quantity * ait.UnitPrice;
                    gridViewDataBind();
                    return;
                }
            }
            RaiseAdjustmentVoucherItem temp = crt.getRaiseAdjustmentVoucherItem(ddlItemDescription.SelectedValue);
            temp.Reason = txtReason.Text;
            if(rblIncreaseOrDecrease.SelectedValue.Equals("Decrease"))
                temp.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text)*-1;
            else
                temp.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text);
            temp.TotalPrice = temp.Quantity * temp.UnitPrice;

            AdjItemList.Add(temp);
            Session["AdjItem"] = AdjItemList;
            gridViewDataBind();
            txtQuantityToAdjust.Text = "";
            txtReason.Text = "Reason";
            txtQuantityToAdjust.Text = "0";
            btnConfirm.Visible = true;
            //start
            List<Category> catlist = crt.getAllCategory();
            if (catlist == null)
                return;
            ddlCategory.Items.Clear();
            foreach (Model.Category cat in catlist)
            {
                ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
            }
            ddlCategory.SelectedIndex = 0;
            List<Item> itemList = crt.getItemByCatID("" + catlist[0].CategoryID);
            if (itemList == null)
                return;
            ddlItemDescription.Items.Clear();
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            ddlCategory.SelectedIndex = 0;
            txtUnifOfMeasure.Text = itemList[0].UOM;
            //end
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItemDescription.Items.Clear();
            List<Model.Item> itemList = crt.getItemByCatID(ddlCategory.SelectedValue);
            if (itemList == null || itemList.Count == 0)
            {
                txtUnifOfMeasure.Text = "";
                return;
            }
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnifOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
        }

        protected void ddlItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Item> itemlist = crt.getItemByCatID(ddlCategory.SelectedValue);
            txtUnifOfMeasure.Text = itemlist[ddlItemDescription.SelectedIndex].UOM;
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["AdjItem"] == null)
            {
                lblMessage.Text = "Fill the item first";
            }
            else
            {
                lblMessage.Text = crt.insertNewAdjustementVoucher((List<RaiseAdjustmentVoucherItem>)Session["AdjItem"], ((Model.StoreEmployee)Session["User"]).StoreEmployeeID);
                Session["AdjItem"] = null;
                gridViewDataBind();
                txtQuantityToAdjust.Text = "0";
                txtReason.Text = "Reason";
                btnConfirm.Visible = false;
                lblMessage.Text = "You have successfully raise adjustment voucher";
            }
        }

        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Style.Add("display", "none");
        }
    }
}