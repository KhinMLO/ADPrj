using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class RequestStationeryControl
    {
        LogicUniversityEntities ctx;

        public RequestStationeryControl()
        {
            ctx = new LogicUniversityEntities();
        }
        public string getUOMByItemID(string itemID)
        {
            return ((Item)ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault()).UOM;
        }
        public string getCategoryIDbyItemID(string itemID)
        {
            return ((Item)ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault()).CategoryID.GetValueOrDefault().ToString();
        }
        public List<RequestStationeryItem> getRequisitionItemByReqID(int reqID)
        {
            List<Model.RequisitionItem> reqItemList = ctx.RequisitionItems.Where(x => x.RequisitionID == reqID).ToList();
            List<Model.RequestStationeryItem> toReturn = new List<RequestStationeryItem>();
            Model.RequestStationeryItem temp;
            for (int i=0;i<reqItemList.Count;i++)
            {
                temp = new RequestStationeryItem();
                temp.ItemDescription = reqItemList[i].Item.Description;
                temp.ItemID = reqItemList[i].ItemID;
                temp.Quantity = reqItemList[i].Quantity;

                ctx.RequisitionItems.Remove(reqItemList[i]);

                toReturn.Add(temp);
            }
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == reqID).FirstOrDefault();
            ctx.Requisitions.Remove(req);
            ctx.SaveChanges();
            return toReturn;
        }
        public List<Category> getAllCategory()
        {
            List<Category> catList = ctx.Categories.ToList();
            List<Category> toReturn = new List<Category>();
            List<Item> ItemList;
            foreach(Category cat in catList){
                ItemList = ctx.Items.Where(x=>x.CategoryID==cat.CategoryID).ToList();
                if(ItemList.Count>0)
                    toReturn.Add(cat);
            }
            return toReturn;
        }
        public List<Item> getItemByCatID(string catID)
        {
            int catid = Convert.ToInt32(catID);
            return ctx.Items.Where(x => x.CategoryID == catid).ToList();
        }
        // success = successfully saved
        // if requistionID is "", it is new
        // if not, it is edit
        //EmpNotFound = Employee Id not found in Employee Table
        public string insertNewReqisition(List<RequestStationeryItem> ReqItem, string empID, string requisitionID)
        {
            System.DateTime today = DateTime.Today;
            if (requisitionID.Equals(""))
            {
                Model.Requisition req = new Requisition();
                req.EmployeeID = empID;
                req.Date = today;
                ctx.Requisitions.Add(req);
                ctx.SaveChanges();
                Model.RequisitionItem reqItem;
                Employee emp = ctx.Employees.Where(x => x.EmployeeID == empID).FirstOrDefault();
                if (emp == null)
                    return "EmpNotFound";
                foreach (RequestStationeryItem Item in ReqItem)
                {
                    reqItem = new Model.RequisitionItem();

                    reqItem.RequisitionID = req.RequisitionID;
                    if (emp.Role == "Department Head")
                    {
                        reqItem.Status = "Approved";
                        reqItem.Reson = "";
                    }
                    else
                        reqItem.Status = "PendingApproval";
                    reqItem.ItemID = Item.ItemID;
                    reqItem.Quantity = Item.Quantity;
                    req.RequisitionItems.Add(reqItem);
                }
                ctx.SaveChanges();
                if (emp.Role != "Department Head")
                {
                    EmailControl emailCrt = new EmailControl();
                    emailCrt.sendforReqStationaryApproval(empID);
                    Notification noti = new Notification();
                    noti.Message = emp.Name+"’s Stationary Requisition is pending your approval.";
                    noti.FromUser = emp.EmployeeID;
                    noti.NotificationDate = DateTime.Today;
                    noti.UserID = ((Employee)ctx.Employees.Where(x => x.Role == "Department Head" && x.DepartmentID == emp.DepartmentID).FirstOrDefault()).EmployeeID;
                    ctx.Notifications.Add(noti);
                    ctx.SaveChanges();
                }
            }
            return "success";
        }
    }
}