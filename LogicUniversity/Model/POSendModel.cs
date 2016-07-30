using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class POSendModel
    {
        private string pOID;
        private string supplierName;
        private string itemDescription;
        private string requiredDeliveryDate;
        private int quantity;
        private string unitOfMeasure;
        private decimal unitPrice;
        private decimal totalPrice;
        public string POID
        {
            get { return pOID; }
            set { pOID = value; }
        }
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }
        public string RequiredDeliveryDate
        {
            get { return requiredDeliveryDate; }
            set { requiredDeliveryDate = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}