using System;
using System.Collections.Generic;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.Employee
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
        String _strSessType = ""
            , _strCollPtName = "";

        Model.Employee _currEmp;
        Department _currDept;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                GetData();

                FillDropDownList();

                ToggleDevVariables(false);
                ShowVariables();

            }
            else
            {
                //fillDropDownList();
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 2 IsPostBack=" + IsCallback + ")");

                if (MySession.Current.type.Equals("Employee"))
                {
                    _currEmp = MySession.Current.User as Model.Employee;
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    if (_currEmp != null) _currDept = crt.GetDepartment(_currEmp.DepartmentID);
                } //else
                    //lblChangeResult.Text = "ERROR: Unknown or Illegal Employee Type Accessing this function.";
            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 3 IsPostBack=" + IsCallback + ")");

        }

        private void FillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.
            Control.CollectionPointControl crt = new Control.CollectionPointControl();
            List<CollectionPoint> collectionPointList = crt.getListCollectionPoint();
            if (!_strCollPtName.Equals(string.Empty))
            {
                foreach (CollectionPoint point in collectionPointList)
                {
                    if (point.CollectionPointName.Equals(_strCollPtName))
                    {
                        collectionPointList.Remove(point);
                        break;
                    }
                }
            }

            ddlNewCollPt.DataSource = collectionPointList;
            ddlNewCollPt.DataTextField = "CollectionPointName";
            ddlNewCollPt.DataValueField = "CollectionPointID";

            // Bind the data to the control.
            ddlNewCollPt.DataBind();

            // Set the default selected item, if desired.
            if(_currDept != null)
                ddlNewCollPt.SelectedIndex = Convert.ToInt32(_currDept.CollectionPointID) - 1000000; // set default to current collection point
        }

        private void GetData()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.getData()");

            _strSessType = MySession.Current.type;

            if (_strSessType.Equals("Employee")) {
                _currEmp = Utilities.getCurrLoginEmp2(_strSessType) as Model.Employee;
                Control.CollectionPointControl crt = new Control.CollectionPointControl();
                if (_currEmp != null) _currDept = crt.GetDepartment(_currEmp.DepartmentID);

                _strCollPtName = Utilities.getCollPtName(Convert.ToInt32(_currDept.CollectionPointID));
            }
            //else
            //    lblChangeResult.Text = "ERROR: Unknown or Illegal Employee Type Accessing this function.";

        }

        private void ToggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.toggleDevVariables(" + showDevVariables + ")");

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

            if (lblNewCollPt != null)
                lblNewCollPt.Visible = showDevVariables;

        }

        private void ShowVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.showVariables()");

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

                if (lblDeptRep != null)
                {
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    lblDeptRep.Text = crt.GetDeptRep(_currEmp.DepartmentID).Name;
                }

                if (lblDeptName != null)
                    lblDeptName.Text = _currDept.DepartmentName;

                if (lblCurrCollPt != null)
                    lblCurrCollPt.Text = _strCollPtName;
            }
        }

        public void btnClick_ChangeCollPt(Object sender, EventArgs e)
        {
            Control.CollectionPointControl crt = new Control.CollectionPointControl();
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.btnClick_ChangeCollPt( "
                +"ddlNewCollPt.SelectedItem.Value=" + ddlNewCollPt.SelectedItem.Value 
                + ", .Text="+ddlNewCollPt.SelectedItem.Text+" )");

            int rtnInt = 0, newCollPtId = Convert.ToInt32(ddlNewCollPt.SelectedItem.Value);

            string newCollPtName = ddlNewCollPt.SelectedItem.Text;

            if (newCollPtId != _currDept.CollectionPointID) // stop doing anything if its the same collection point
            {
                if (lblNewCollPt != null)
                {
                    //lblNewCollPt.Text = selectedCollPt.ToString();
                    //lblNewCollPt.Text = ddlNewCollPt.SelectedItem.Value;
                    rtnInt = crt.ChangeCollectionPointForDept(_currEmp.DepartmentID, newCollPtId);
                    lblNewCollPt.Text = rtnInt.ToString();
                }

                if (lblChangeResult != null)
                {
                    if (rtnInt == 1)
                    {
                        //lblChangeResult.Text = currDept.DepartmentName + " new Collection Point at " + Model.Utilities.getCollPtName(newCollPtID) + " saved successfully.";
                        lblChangeResult.Text = _currDept.DepartmentName + " new Collection Point at " + newCollPtName + " saved successfully";

                        //if (lblCurrCollPt != null)
                        lblCurrCollPt.Text = newCollPtName;
                    }
                    else if (rtnInt == 0)
                        lblChangeResult.Text = "ERROR: New Collection Point Not Saved.";
                    else if (rtnInt > 1)
                        lblChangeResult.Text = "ERROR: Multiple Collection Points were saved.";
                    else
                        lblChangeResult.Text = "ERROR: Some unknown error occured with rtnInt=" + rtnInt;
                }

                if (rtnInt == 1)
                {
                    // code for do notification

                    if (lblChangeResult != null)
                        lblChangeResult.Text += crt.SendChangeCollectionPointNotifications(_currEmp, _currDept, newCollPtName);
                }
            }
            List<CollectionPoint> collectionPointList = crt.getListCollectionPoint();
            if (!lblCurrCollPt.Text.Equals(string.Empty))
            {
                foreach (CollectionPoint point in collectionPointList)
                {
                    if (point.CollectionPointName.Equals(lblCurrCollPt.Text))
                    {
                        collectionPointList.Remove(point);
                        break;
                    }
                }
            }

            ddlNewCollPt.DataSource = collectionPointList;
            ddlNewCollPt.DataTextField = "CollectionPointName";
            ddlNewCollPt.DataValueField = "CollectionPointID";

            // Bind the data to the control.
            ddlNewCollPt.DataBind();
        }

    }
}