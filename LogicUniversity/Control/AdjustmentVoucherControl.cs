using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class AdjustmentVoucherControl
    {
        LogicUniversityEntities ctx;
        public AdjustmentVoucherControl()
        {
            ctx = new LogicUniversityEntities();
        }
        public Item getItemByItemID(string itemID)
        {
            return ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault();
        }
        public int getCategoryIDByCategory(string cat)
        {
            return ((Category)ctx.Categories.Where(x => x.CategoryName == cat).FirstOrDefault()).CategoryID;
        }
        //success = Successfully Updated
        //notFound = adj voucher item is not found
        public string getToApproveAdjItemList(List<RaiseAdjustmentVoucherItem> rAdjItemList,Model.StoreEmployee sEmp)
        {
            AdjVoucherItem adjItem;
            List<AdjVoucher> adjList = new List<AdjVoucher>();
            Item itm;
            StockTransaction st;
            int adjItemID;

            foreach (RaiseAdjustmentVoucherItem ravi in rAdjItemList)
            {
                adjItemID = Convert.ToInt32(ravi.AdjItemID);
                adjItem = ctx.AdjVoucherItems.Where(x => x.AdjVoucherItemID == adjItemID).FirstOrDefault();
                if (adjItem == null)
                    return "notFound";
                adjList.Add(ctx.AdjVouchers.Where(x => x.AdjVoucherID == adjItem.AdjVoucherID).FirstOrDefault());
                if(ravi.Status.Equals("Approved"))
                {
                    adjItem.Status = "Approved";
                    itm = ctx.Items.Where(x => x.ItemID == adjItem.ItemID).FirstOrDefault();
                    itm.Quantity += adjItem.Quantity.GetValueOrDefault();
                    st = new StockTransaction();
                    st.AdjVoucherItemID = adjItem.AdjVoucherItemID;
                    st.Balance = itm.Quantity;
                    st.TransactionDate = DateTime.Today;
                    st.ItemID = itm.ItemID;
                    ctx.StockTransactions.Add(st);
                    ctx.SaveChanges();
                }
                else
                {
                    adjItem.Status = "Rejected";
                    ctx.SaveChanges();
                }
                List<int> tempList= adjList.Select(x => x.AdjVoucherID).Distinct().ToList();
                EmailControl emailCrt = new EmailControl();
                emailCrt.sendforAdjReview(tempList, sEmp);
            }
            return "success";
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
        public RaiseAdjustmentVoucherItem getRaiseAdjustmentVoucherItem(string itemID)
        {
            RaiseAdjustmentVoucherItem temp = new RaiseAdjustmentVoucherItem();
            Item item = ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault();
            List<SupplierItem> supItem = ctx.SupplierItems.Where(x => x.ItemID == itemID).ToList();
            temp.ItemCode = item.ItemID;
            temp.Category = item.Category.CategoryName;
            temp.Description = item.Description;
            temp.UnitOfMeasure = item.UOM;
            temp.UnitPrice = 0;
            foreach(SupplierItem spi in supItem)
            {
                temp.UnitPrice += (double)spi.Price.GetValueOrDefault();
            }
            temp.UnitPrice /= supItem.Count;
            temp.UnitPrice = Math.Round(temp.UnitPrice, 2);
            return temp;
        }
        //success = successfully added
        public string insertNewAdjustementVoucher(List<RaiseAdjustmentVoucherItem> rAdjList,string sEmpID)
        {
            StoreEmployee semp = ctx.StoreEmployees.Where(x=>x.StoreEmployeeID==sEmpID).FirstOrDefault();
            AdjVoucher adjV = new AdjVoucher();
            adjV.StoreEmployeeID = sEmpID;
            ctx.AdjVouchers.Add(adjV);
            ctx.SaveChanges();
            AdjVoucherItem adjvItem;
            foreach(RaiseAdjustmentVoucherItem temp in rAdjList)
            {
                adjvItem = new AdjVoucherItem();
                adjvItem.AdjVoucherID = adjV.AdjVoucherID;
                adjvItem.ItemID = temp.ItemCode;
                adjvItem.Quantity = temp.Quantity;
                adjvItem.Reason = temp.Reason;
                if (semp.Role.Equals("Store Manager") || semp.Role.Equals("Store Supervisor"))
                    adjvItem.Status = "Approved";
                else
                    adjvItem.Status = "Pending Approval";
                adjV.AdjVoucherItems.Add(adjvItem);
            }
            ctx.SaveChanges();
            List<AdjVoucherItem> adjItemList = ctx.AdjVoucherItems.Where(x => x.AdjVoucherID == adjV.AdjVoucherID).ToList();
            Boolean toManager = false;
            Boolean toSupervisor = false;
            List<SupplierItem> sitemList;
            decimal totalCost = 0;
            foreach(AdjVoucherItem adjitem in adjItemList)
            {
                if (toManager == true && toSupervisor == true)
                    break;
                sitemList = ctx.SupplierItems.Where(x => x.ItemID == adjitem.ItemID).ToList();
                totalCost = 0;
                foreach(SupplierItem sp in sitemList)
                {
                    totalCost += sp.Price.GetValueOrDefault();
                }
                totalCost /= sitemList.Count;
                totalCost *= adjitem.Quantity.GetValueOrDefault();
                if (totalCost > 100)
                    toSupervisor = true;
                else
                    toManager = true;
            }
            
            EmailControl emailCrt = new EmailControl();
            Notification noti;
            string name = ((StoreEmployee)ctx.StoreEmployees.Where(x => x.StoreEmployeeID==sEmpID).FirstOrDefault()).Name;
            if (toManager) { 
                emailCrt.sendforAdjApproval(sEmpID, "Store Manager");
                noti = new Notification();
                noti.UserID = ((StoreEmployee)ctx.StoreEmployees.Where(x => x.Role == "Store Manager").FirstOrDefault()).StoreEmployeeID;
                noti.FromUser = sEmpID;
                noti.NotificationDate = DateTime.Today;
                noti.Message = name+"’s Stock Adjustment Voucher is pending your approval.";
                ctx.Notifications.Add(noti);
                ctx.SaveChanges();
            }
            if (toSupervisor) { 
                emailCrt.sendforAdjApproval(sEmpID, "Store Supervisor");
                noti = new Notification();
                noti.UserID = ((StoreEmployee)ctx.StoreEmployees.Where(x => x.Role == "Store Supervisor").FirstOrDefault()).StoreEmployeeID;
                noti.FromUser = sEmpID;
                noti.NotificationDate = DateTime.Today;
                noti.Message = name + "’s Stock Adjustment Voucher is pending your approval.";
                ctx.Notifications.Add(noti);
                ctx.SaveChanges();
            }
            return "success";
        }
        public List<RaiseAdjustmentVoucherItem> getToApproveAdjItemList(string sempID)
        {
            List<AdjVoucherItem> adjVoucherItems = ctx.AdjVoucherItems.Where(x=>x.Status== "Pending Approval").ToList();
            List<RaiseAdjustmentVoucherItem> resultForSupervisor = new List<RaiseAdjustmentVoucherItem>();
            List<RaiseAdjustmentVoucherItem> resultForManager = new List<RaiseAdjustmentVoucherItem>();
            RaiseAdjustmentVoucherItem temp;
            foreach (AdjVoucherItem adjItem in adjVoucherItems)
            {
                temp = new RaiseAdjustmentVoucherItem();
                temp.AdjItemID = adjItem.AdjVoucherItemID.ToString();
                temp.ItemCode = adjItem.ItemID;
                temp.Category = adjItem.Item.Category.CategoryName;
                temp.Description = adjItem.Item.Description;
                temp.Quantity = adjItem.Quantity.GetValueOrDefault();
                temp.UnitOfMeasure = adjItem.Item.UOM;
                List<SupplierItem> sitemList = ctx.SupplierItems.Where(x => x.ItemID == adjItem.ItemID).ToList();
                foreach(SupplierItem sitem in sitemList)
                {
                    temp.UnitPrice += (double)sitem.Price.GetValueOrDefault();
                }
                temp.UnitPrice /= sitemList.Count;
                temp.UnitPrice = Math.Round(temp.UnitPrice, 2);
                temp.TotalPrice = temp.Quantity * temp.UnitPrice;
                temp.Reason = adjItem.Reason;
                if(temp.TotalPrice<0)
                    if ((temp.TotalPrice)*-1 > 100)
                        resultForManager.Add(temp);
                    else
                        resultForSupervisor.Add(temp);
                else
                    if (temp.TotalPrice > 100)
                        resultForManager.Add(temp);
                    else
                        resultForSupervisor.Add(temp);
            }
            StoreEmployee se = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == sempID).FirstOrDefault();
            if (se.Role.Equals("Store Supervisor"))
                return resultForSupervisor;
            else if (se.Role.Equals("Store Manager"))
                return resultForManager;
            else
                System.Diagnostics.Debug.WriteLine("I m become null");
                return null;
        }
    }
}