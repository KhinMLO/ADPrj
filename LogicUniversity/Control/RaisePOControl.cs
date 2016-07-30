using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class RaisePOControl
    {
        Model.LogicUniversityEntities ctx;
        public RaisePOControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public void getPOItembyPOID(int pid, List<POSendModel> piList)
        {
            List<PurchaseOrderItem> pitm = ctx.PurchaseOrderItems.Where(x => x.PurchaseOrderID == pid).ToList();
            POSendModel temp;
            foreach (PurchaseOrderItem po in pitm)
            {
                temp = new POSendModel();
                temp.POID = po.PurchaseOrderID.GetValueOrDefault().ToString();
                temp.SupplierName = po.PurchaseOrder.Supplier.SupplierName;
                temp.ItemDescription = po.Item.Description;
                temp.RequiredDeliveryDate = po.PurchaseOrder.RequireDeliveryDate.GetValueOrDefault().ToString("dd/MM/yyyy");
                temp.Quantity = po.Quantity.GetValueOrDefault();
                temp.UnitOfMeasure = po.Item.UOM;
                SupplierItem sp = ctx.SupplierItems.Where(x=>x.SupplierID==po.PurchaseOrder.SupplierID && x.ItemID==po.ItemID).FirstOrDefault();
                temp.UnitPrice = sp.Price.GetValueOrDefault();
                temp.TotalPrice = temp.Quantity * temp.UnitPrice;
                piList.Add(temp);
            }
        }
        public Item getItemByItemID(string itemID)
        {
            return ctx.Items.Where(x=>x.ItemID==itemID).FirstOrDefault();
        }
        public List<Category> getAllCategory()
        {
            List<Category> catList = ctx.Categories.ToList();
            List<Category> toReturn = new List<Category>();
            List<Item> ItemList;
            foreach (Category cat in catList)
            {
                ItemList = ctx.Items.Where(x => x.CategoryID == cat.CategoryID).ToList();
                if (ItemList.Count > 0)
                    toReturn.Add(cat);
            }
            return toReturn;
        }
        public List<Item> getItemByCatID(string catID)
        {
            int catid = Convert.ToInt32(catID);
            return ctx.Items.Where(x => x.CategoryID == catid).ToList();
        }
        public List<SupplierItem> getSupplierByItemID(string itemID)
        {
            return ctx.SupplierItems.Where(x => x.ItemID == itemID).ToList();
        }
        public SupplierItem getSupplierItemBySupplierIDAndItemID(string sid,string itemid)
        {
            return ctx.SupplierItems.Where(x => x.SupplierID == sid && x.ItemID == itemid).FirstOrDefault();
        }
        public string confirmPOItem(List<RaisePOVoucherItem> rpoitemList,string sEmpID,List<PurchaseOrder> POList)
        {
            if (rpoitemList.Count <= 0)
                return "fail";
            List<PurchaseOrder> poList = new List<PurchaseOrder>();
            PurchaseOrder po_temp;
            PurchaseOrderItem poitem_temp;
            int flag = 0;
            foreach(RaisePOVoucherItem rpoitem in rpoitemList)
            {
                flag = 0;
                foreach(PurchaseOrder po in poList)
                {
                    if (po.SupplierID.Equals(rpoitem.SupplierID))
                    {
                        poitem_temp = new PurchaseOrderItem();
                        poitem_temp.ItemID = rpoitem.ItemID;
                        poitem_temp.Quantity = rpoitem.Quantity;
                        po.PurchaseOrderItems.Add(poitem_temp);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    po_temp = new PurchaseOrder();
                    poitem_temp = new PurchaseOrderItem();

                    po_temp.SupplierID = rpoitem.SupplierID;
                    po_temp.StoreEmployeeID = sEmpID;
                    po_temp.OrderDate = DateTime.Today;
                    po_temp.RequireDeliveryDate = Convert.ToDateTime(rpoitem.RequiredDeliveryDate);
                    poitem_temp.ItemID = rpoitem.ItemID;
                    poitem_temp.Quantity = rpoitem.Quantity;
                    po_temp.PurchaseOrderItems.Add(poitem_temp);
                    poList.Add(po_temp);
                }
            }
            foreach(PurchaseOrder po in poList)
            {
                EmailControl ecrt = new EmailControl();
                ctx.PurchaseOrders.Add(po);
                ctx.SaveChanges();

                //System.Diagnostics.Debug.WriteLine("============");
                //System.Diagnostics.Debug.WriteLine(po.PurchaseOrderID);
                //System.Diagnostics.Debug.WriteLine(po.SupplierID);
                //System.Diagnostics.Debug.WriteLine(po.StoreEmployeeID);
                //System.Diagnostics.Debug.WriteLine(po.OrderDate);
                //System.Diagnostics.Debug.WriteLine(po.RequireDeliveryDate);
                //System.Diagnostics.Debug.WriteLine("----------------------------");
                //foreach (PurchaseOrderItem poitem in po.PurchaseOrderItems)
                //{
                //    poitem.PurchaseOrderID = po.PurchaseOrderID;
                //    ctx.PurchaseOrderItems.Add(poitem);
                //    ctx.SaveChanges();
                //    System.Diagnostics.Debug.WriteLine(poitem.PurchaseOrderItemID);
                //    System.Diagnostics.Debug.WriteLine(poitem.ItemID);
                //    System.Diagnostics.Debug.WriteLine(poitem.Quantity);
                    
                //}
                
                ecrt.sendEmailForRaisePO(ctx.PurchaseOrders.Where(x=>x.PurchaseOrderID==po.PurchaseOrderID).FirstOrDefault());
                System.Diagnostics.Debug.WriteLine("----------------------------");
                System.Diagnostics.Debug.WriteLine("============");
                POList.Add(po);
            }
            
            return "success";
        }
    }

}