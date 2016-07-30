using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView
{
    public partial class ChangePIN : System.Web.UI.Page
    {
        Control.LoginControl lcrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lcrt = new Control.LoginControl();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(!txtNewPIN.Text.Equals(txtConfirmNewPIN.Text))
            {
                lblMessage.Text = "New PIN and Confirm New PIN should be the same";
                return;
            }
            if (txtNewPIN.Text.Length != 6)
            {
                lblMessage.Text = "New PIN should be 6-digits";
                return;
            }
            if (txtNewPIN.Text.Equals(txtOldPIN.Text))
            {
                lblMessage.Text = "New and old PIN can not be the same";
                return;
            }
            string result = lcrt.ChangePIN((object)Session["User"],(string)Session["type"], txtOldPIN.Text, txtNewPIN.Text);
            switch (result)
            {
                case "success":
                    lblMessage.Text = "Your PIN has been successfully Changed";
                    break;
                case "notfound":
                    lblMessage.Text = "Old PIN is invalid";
                    break;
                case "error":
                    lblMessage.Text = "Error in changing PIN";
                    break;
            }
            txtConfirmNewPIN.Text = string.Empty;
            txtNewPIN.Text = string.Empty;
            txtOldPIN.Text = string.Empty;
        }
    }
}