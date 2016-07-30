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
    public partial class POConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Data"] != null)
            {
                string temp = Request["Data"];
                string[] POIDList= temp.Split('@');

                RaisePOControl crt = new RaisePOControl();
                List<POSendModel> poItemList = new List<POSendModel>();

                for(int i=0;i<POIDList.Length-1;i++){
                    crt.getPOItembyPOID(Convert.ToInt32(POIDList[i]), poItemList);
                }
                gvData.DataSource = poItemList;
                gvData.DataBind();
            }
        }
    }
}