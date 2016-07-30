using System;
using System.Collections.Generic;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.Employee
{
    public partial class ChangeDepartmentRepresentative : System.Web.UI.Page
    {
        protected String StrCurrDeptRepNameId
        {
            get { return ViewState["strCurrDeptRep"] as String; }
            set { ViewState["strCurrDeptRep"] = value; }
        }

        protected String PrevDeptRepId
        {
            get { return ViewState["prevDeptRepID"] as String; }
            set { ViewState["prevDeptRepID"] = value; }
        }

        String _strSessType = "";

        Model.Employee _currEmp;
        Model.Employee _currDeptRep;
        Model.Employee _prevDeptRep;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                GetSessionData();
                FillDropDownList();
                GetCurrDeptRep();

                SaveCurrDeprRep(); // for use during email notification

                

                bool showDevVariables = false;
                ToggleDevVariables(false);

                ShowVariables(); // includes both dev and non-dev variables
            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 2 IsPostBack=" + IsCallback + ")");

                if (MySession.Current.type.Equals("Employee"))
                {
                    _currEmp = MySession.Current.User as Model.Employee; // somehow, I can't save this to a ViewState without a runtime error
                    _prevDeptRep = getPrevDeptRep(PrevDeptRepId);
                }
                else
                    ShowPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");
            }
            

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 3 IsPostBack=" + IsCallback + ")");

        }

        private Model.Employee getPrevDeptRep(string prevDeptRepId)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getPrevDeptRep(prevDeptRepID=" + prevDeptRepId + ")");
            //throw new NotImplementedException();

            var aLoginCtrl = new Control.LoginControl();

            Model.Employee prevDeptRep = aLoginCtrl.getEmployeeUserObject(prevDeptRepId);

            return prevDeptRep;
        }

        private void SaveCurrDeprRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.saveCurrDeprRep()");
            //throw new NotImplementedException();

            if (_currDeptRep != null)
            {
                PrevDeptRepId = _currDeptRep.EmployeeID;
            }

        }

        private void GetCurrDeptRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getCurrDeptRep()");

            if (_currEmp != null)
            {
                Control.CollectionPointControl crt = new Control.CollectionPointControl();
                _currDeptRep = crt.GetDeptRep(_currEmp.DepartmentID);
                StrCurrDeptRepNameId = _currDeptRep.Name; // for the label
            }
        }

        private void GetSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getData()");

            _strSessType = MySession.Current.type;

            if (_strSessType.Equals("Employee"))
            {
                _currEmp = Utilities.getCurrLoginEmp2(_strSessType) as Model.Employee;
            }
            else
                ShowPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");

        }

        private void ToggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.toggleDevVariables(" + showDevVariables + ")");

            if (lblTxtSessType != null)
                lblTxtSessType.Visible = showDevVariables;

            if (lblSessType != null)
                lblSessType.Visible = showDevVariables;

            if (lblTxtEmpID != null)
                lblTxtEmpID.Visible = showDevVariables;

            if (lblEmpID != null)
                lblEmpID.Visible = showDevVariables;

            if (lblTxtDeptID != null)
                lblTxtDeptID.Visible = showDevVariables;

            if (lblDeptID != null)
                lblDeptID.Visible = showDevVariables;
        }

        private void ShowVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = _strSessType;
            }

            if (_currEmp != null)
            {
                if (lblEmpID != null)
                    lblEmpID.Text = _currEmp.EmployeeID;

                if (lblDeptID != null)
                    lblDeptID.Text = _currEmp.DepartmentID;

                ShowCurrDeptRep();
            }
        }

        private void ShowCurrDeptRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.showCurrDeptRep()");

            if (lblCurrDeptRep != null && StrCurrDeptRepNameId != null)
                lblCurrDeptRep.Text = StrCurrDeptRepNameId;
        }

        private void FillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.

            Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
            List<deptEmpDDL_Ele> empList = crt.getListDeptEmpsForDDL(_currEmp.DepartmentID);
            foreach (deptEmpDDL_Ele deptEmpDdlEle in empList)
            {
                if (deptEmpDdlEle.EmployeeID.Equals(_currEmp.EmployeeID))
                    empList.Remove(deptEmpDdlEle);
            }
            ddlNewDeptRep.DataSource = empList;
            ddlNewDeptRep.DataTextField = "combEmpNameID";
            ddlNewDeptRep.DataValueField = "EmployeeID";

            // Bind the data to the control.
            ddlNewDeptRep.DataBind();

            // Set the default selected item, if desired.
            ddlNewDeptRep.SelectedIndex = 0; // set default to the current dept rep, who is at index 0;
        }

        public void btnClick_ChangeDeptRep(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.btnClick_ChangeDeptRep(ddlNewDeptRep.SelectedItem.Value=" + ddlNewDeptRep.SelectedItem.Value + ")");

            String newDeptRepId = ddlNewDeptRep.SelectedItem.Value, confirmMsg, emailRtnMsg;

            if (newDeptRepId != PrevDeptRepId) // to ignore when its the same current dept rep
            {
                if (StrCurrDeptRepNameId != null)
                {
                    //if (currDeptRep != null)
                    //confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(currDeptRep.EmployeeID, newDeptRepID);

                    // doing this method cos I hate going back to the dB for something which I can easily store but this way might use more processing
                    //confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(strCurrDeptRepNameID.Substring(strCurrDeptRepNameID.Length - 9, 8), newDeptRepID);
                    Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                    confirmMsg = crt.changeDeptRep(PrevDeptRepId, newDeptRepId);
                }
                else
                    confirmMsg = "ERROR: Changes Unsuccessful with system error msg: " + "currDeptRep not loaded after PostBack";

                if (!confirmMsg.Substring(0, 5).Equals("ERROR"))
                {
                    GetCurrDeptRep();

                    ShowCurrDeptRep(); // update label to show new current dept rep

                    // NEED TO DO eMail Notifications here to prev rep, new rep, dept head and store clerks

                    if (_currEmp != null && _prevDeptRep != null) {
                        Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                        emailRtnMsg = crt.sendChangeDeptRepNotifications(_currEmp, _prevDeptRep, _currDeptRep);
                        confirmMsg += emailRtnMsg;
                    }
                    else
                        confirmMsg += " but ERROR sending notification emails.";

                    //if (emailRtnMsg.Substring(0, 5).Equals("ERROR"))
                    //{
                    //    confirmMsg += emailRtnMsg;
                    //}
                    //else
                    //{
                    //    // temp
                    //    confirmMsg += emailRtnMsg;
                    //}

                    SaveCurrDeprRep(); // do this in case the user immediately changes dept rep again
                    lblMessage.Text = "Department Representative is successfully changed";
                }
                FillDropDownList();
                //showPopUp(confirmMsg);
            }

        }

        private void ShowPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.showPopUp()");

            // all three looks the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }
    }
}