using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class Acknowledge
    {
        LogicUniversityEntities ctx;
        public Acknowledge()
        {
            ctx = new LogicUniversityEntities();
        }

        //overflow = accepted qty is more than request
        //success = successfully updated
        public string acknowledgeDisbursement(List<AcknowledgeModel> acknowledgeObject)
        {
            AcknowledgeModel temp = acknowledgeObject[0];
            Disbursement disbursement = ctx.Disbursements.Where(x => x.DisbursementID == temp.disbursementId).FirstOrDefault();
            disbursement.CollectionDate = DateTime.Today;
            disbursement.AcknowledgeEmployeeID = acknowledgeObject[0].acknowledgeEmpId;
            disbursement.status = "Collected";

            List<DisbursementItem> disbursementItemList = ctx.DisbursementItems.Where(x => x.DisbursementID == temp.disbursementId).ToList();
            int difQty=0;
            Item itm;
            List<RequisitionItem> reqItem;
            foreach (AcknowledgeModel ackModel in acknowledgeObject)
            {
                foreach (DisbursementItem disItem in disbursementItemList)
                {
                    if (ackModel.itemId.Equals(disItem.ItemID))
                    {
                        itm = ctx.Items.Where(x => x.ItemID == disItem.ItemID).FirstOrDefault();
                        if (ackModel.quantityAccepted < (disItem.Quantity - disItem.RemainingQty))
                        {
                            difQty = (disItem.Quantity.GetValueOrDefault() - disItem.RemainingQty.GetValueOrDefault()) - ackModel.quantityAccepted;
                            
                            itm.Quantity += difQty;
                            try
                            {
                                ctx.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                return "Error";
                            }
                            reqItem = disItem.RequisitionItems.ToList();
                            foreach (RequisitionItem req in reqItem)
                            {
                                req.Status = "Partial Fulfilled";
                            }
                            disItem.RemainingQty = disItem.Quantity - ackModel.quantityAccepted;
                            try
                            {
                                ctx.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                return "Error";
                            }
                        }
                        else if (ackModel.quantityAccepted == (disItem.Quantity - disItem.RemainingQty))
                        {
                            reqItem = disItem.RequisitionItems.ToList();
                            if (disItem.RemainingQty.GetValueOrDefault() == 0)
                            {
                                foreach (RequisitionItem req in reqItem)
                                {
                                    req.Status = "Collected";
                                }
                            }
                            else
                            {
                                foreach (RequisitionItem req in reqItem)
                                {
                                    req.Status = "Partial Fulfilled";
                                }
                            }
                            try
                            {
                                ctx.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                return "Error";
                            }
                        }
                        else if (ackModel.quantityAccepted > (disItem.Quantity - disItem.RemainingQty))
                        {
                            return "overflow";
                        }
                        disItem.Status = "Collected";
                        StockTransaction st = new StockTransaction();
                        st.ItemID = ackModel.itemId;
                        st.DepartmentID = ackModel.deptId;
                        st.Balance = itm.Quantity;
                        st.TransactionDate = DateTime.Today;
                        ctx.StockTransactions.Add(st);
                        try
                        {
                            ctx.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            return "Error";
                        }

                    }
                }
                
            }
            return "Success";
        }










            //        actualQty = eachItem.Quantity.GetValueOrDefault() - eachItem.RemainingQty.GetValueOrDefault();
            //        //DisbursementItem disbursementItem = ctx.DisbursementItems.Where(x => x.DisbursementItemID == eachItem.DisbursementItemID).FirstOrDefault();

            //        if (item.quantityAccepted == actualQty)
            //        {
            //            eachItem.Status = "Collected";
            //            List<RequisitionItem> ReqItemList = ctx.RequisitionItems.Where(x => x.DisbursementItems.Any(y => y.DisbursementID == eachItem.DisbursementID)).ToList();
            //            foreach (RequisitionItem reqItem in ReqItemList)
            //            {
            //                if (reqItem.Status.Equals("inProgress"))
            //                {
            //                    reqItem.Status = "Collected";
            //                }
            //            }
            //        }
            //        else if (item.quantityAccepted < actualQty)
            //        {
            //            eachItem.Item.Quantity += actualQty-item.quantityAccepted;
            //            eachItem.RemainingQty += actualQty - item.quantityAccepted;
            //            List<RequisitionItem> ReqItemList = ctx.RequisitionItems.Where(x => x.DisbursementItems.Any(y => y.DisbursementID == eachItem.DisbursementID)).ToList();
            //            foreach(RequisitionItem reqItem in ReqItemList)
            //            {
            //                reqItem.Status = "Partial Fulfilled";
            //            }
            //        }

            //        StockTransaction stockTransaction = new StockTransaction();
            //        stockTransaction.DepartmentID = eachItem.Disbursement.DepartmentID;
            //        stockTransaction.ItemID = eachItem.ItemID;
            //        stockTransaction.Balance = eachItem.Item.Quantity;
            //        stockTransaction.TransactionDate = DateTime.Today;
            //        ctx.StockTransactions.Add(stockTransaction);
            //    }
            //}
            //try
            //{
            //    ctx.SaveChanges();
            //    return "Success";
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Exception " + ex.Message);
            //    return "Error";
            //}
    }
}