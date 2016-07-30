using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class RaiseAdjustmentVoucherItem
    {
        private string adjItemID;
        private string itemCode;
        private string category;
        private string description;
        private int quantity;
        private string unitOfMeasure;
        private double unitPrice;
        private double totalPrice;
        private string reason;
        private string status;


        public string AdjItemID
        {
            get
            {
                return adjItemID;
            }

            set
            {
                adjItemID = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public RaiseAdjustmentVoucherItem(string adjItemID, string status)
        {
            this.AdjItemID = adjItemID;
            this.Status = status;
        }
        public RaiseAdjustmentVoucherItem()
        { }


        public string ItemCode
        {
            get
            {
                return itemCode;
            }

            set
            {
                itemCode = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public string UnitOfMeasure
        {
            get
            {
                return unitOfMeasure;
            }

            set
            {
                unitOfMeasure = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }
    }
}