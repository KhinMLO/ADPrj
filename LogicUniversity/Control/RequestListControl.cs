using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicUniversity.Control
{
    public class RequestListControl
    {
        Model.LogicUniversityEntities ctx;
        public RequestListControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        //success = successfully deleted
        public string DeleteRequisition(int requisitionId)
        {
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == requisitionId).FirstOrDefault();
            List<Model.RequisitionItem> toRemove = new List<Model.RequisitionItem>();
            if (req != null)
            {
                foreach(Model.RequisitionItem reqitem in req.RequisitionItems)
                {
                    toRemove.Add(reqitem);
                }
                foreach(Model.RequisitionItem reqitem in toRemove)
                {
                    ctx.RequisitionItems.Remove(reqitem);
                }
                ctx.Requisitions.Remove(req);
            }
            ctx.SaveChanges();
            return "success";
        }
        public string ReorderRequisition(int requisitionId,string role)
        {
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == requisitionId).FirstOrDefault();
            Model.Requisition toAdd = new Model.Requisition();
            Model.RequisitionItem toAddItem;
            if (req != null)
            {
                toAdd.EmployeeID = req.EmployeeID;
                toAdd.Date = DateTime.Today;
                ctx.Requisitions.Add(toAdd);
                ctx.SaveChanges();
                foreach(Model.RequisitionItem reqitem in req.RequisitionItems)
                {
                    toAddItem = new Model.RequisitionItem();
                    toAddItem.RequisitionID = toAdd.RequisitionID;
                    toAddItem.ItemID = reqitem.ItemID;
                    toAddItem.Quantity = reqitem.Quantity;
                    if (role.Equals("Department Head"))
                        toAddItem.Status = "Approved";
                    else
                        toAddItem.Status = "PendingApproval";
                    toAdd.RequisitionItems.Add(toAddItem);
                }
            }
            ctx.Requisitions.Add(toAdd);
            ctx.SaveChanges();
            return "success";
        }
        public List<Model.RequisitionItem> GetRequistionList(string description,string status,string empId)
        {
            if (status.Equals("All"))
                if (description.Equals(""))
                    return ctx.RequisitionItems.Where(x => x.Requisition.EmployeeID == empId).OrderByDescending(r=>r.Requisition.Date).ThenByDescending(t=>t.RequisitionID).ToList();
                else
                    return ctx.RequisitionItems.Where(x => x.Item.Description.Contains(description) && x.Requisition.EmployeeID == empId).OrderByDescending(r => r.Requisition.Date).ThenByDescending(t => t.RequisitionID).ToList();
            else
                if (description.Equals(""))
                    return ctx.RequisitionItems.Where(x => x.Status == status && x.Requisition.EmployeeID == empId).OrderByDescending(r => r.Requisition.Date).ThenByDescending(t => t.RequisitionID).ToList();
                else
                    return ctx.RequisitionItems.Where(x => x.Status == status && x.Item.Description.Contains(description) && x.Requisition.EmployeeID == empId).OrderByDescending(r => r.Requisition.Date).ThenByDescending(t => t.RequisitionID).ToList();
        }
        public List<Model.RequestListItem> GetRequisitionListItem(string description, string status, string empId)
        {
            List<Model.RequisitionItem> reqItemList = GetRequistionList(description, status, empId);
            List<Model.RequestListItem> resultList = new List<Model.RequestListItem>();
            Model.RequestListItem result;
            foreach (Model.RequisitionItem req in reqItemList)
            {
                result = new Model.RequestListItem();
                if (req.Requisition.Date != null)
                    result.RequestDate = ((DateTime)req.Requisition.Date).ToString("dd/MM/yyyy");
                result.RequisitionForm = ""+req.RequisitionID;
                result.Description = req.Item.Description;
                result.Quantity = ""+req.Quantity;
                result.UnitOfMeasure = req.Item.UOM;
                result.Status = req.Status;
                resultList.Add(result);
            }
            return resultList;
        }
    }
}