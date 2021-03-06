﻿using System;
using System.Collections.Generic;
using System.Linq;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class CollectionPointControl
    {
        LogicUniversityEntities ctx;
        public CollectionPointControl()
        {
            ctx = new LogicUniversityEntities();
        }

        public Department GetDepartment(String deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDepartment( deptID=" + deptID + ")");

            var context = new LogicUniversityEntities();

            Department rtnDept = context.Departments.Where(x => x.DepartmentID == deptID).FirstOrDefault();

            return rtnDept;
        }

        public CollectionPoint getCollectionPoint(int collPtID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getCollectionPoint( collPtID=" + collPtID + ")");

            var context = new LogicUniversityEntities();

            CollectionPoint rtnCollPt = context.CollectionPoints.Where(x => x.CollectionPointID == collPtID).FirstOrDefault();

            return rtnCollPt;
        }

        public List<CollectionPoint> getListCollectionPoint()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            var context = new LogicUniversityEntities();

            List<CollectionPoint> rtnCollPtList = context.CollectionPoints.ToList();

            return rtnCollPtList;
        }

        public int ChangeCollectionPointForDept(string deptId, int newCollPt)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.changeCollectionPointForDept( deptID=" + deptId + ", newCollPt=" + newCollPt + ")");

            //deptID = "ABCD"; // ERROR test - passed
            //newCollPt = 2; // ERROR test - passed

            int rtnInt;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    Department currDept = context.Departments.Single(x => x.DepartmentID == deptId);

                    currDept.CollectionPointID = newCollPt;

                    rtnInt = context.SaveChanges();
                }
                catch (Exception)
                {
                    context.Dispose();

                    rtnInt = -1;
                }
            }

            return rtnInt;
        }

        public Employee GetDeptRep(string deptId)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            Employee deptRep;

            var context = new LogicUniversityEntities();

            deptRep = context.Employees.Where(x => x.DepartmentID == deptId && x.Role == "Representative").FirstOrDefault();

            return deptRep;
        }

        /*
            To: Store Clerk, Store Supervisor, Store Manager
            Cc: Department Representative, Department Head
            Title: XX Department changed its Collection Point to XX

            Dear Sir/ Madam,
            Please be informed that XX Department has changed their collection point to XX.
            This is a system generated email, please do not reply.

            Notification: XX Department has changed its collection point to XX.         

            public void SendEmail(string to, string subject, string body, List<string> cclist)
         */
        public string SendChangeCollectionPointNotifications(Employee currEmp, Department currDept, string newCollPtName)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName=" + newCollPtName + ")");

            string msg, emailSubject, emailBody, notiMsg, currDeptName;

            List<empIdEmail> empIdEmailToList = new List<empIdEmail>(), empIdEmailCCList;

            if (currDept != null)
            {
                currDeptName = currDept.DepartmentName;

                //notiMsg = currDeptName + " Department has changed its collection point to " + newCollPtName;
                notiMsg = GetValidNotificationMsg(currDeptName, newCollPtName, " Department has changed its ", "Collection Point");

                emailSubject = currDeptName + " Department changed its Collection Point to " + newCollPtName;

                emailBody = GetEmailBody(currEmp, currDeptName, newCollPtName, "Collection Point");

                empIdEmailToList = GetAllStoreEmployeesIdEmailToList();

                empIdEmailCCList = GetDeptHeadRepIdEmailList(currDept.DepartmentID);

                // don't do this as it sends to the entire CC list for every TO email sent
                // but I'm doing this temporarily until emailCtrl.SendEmail works with an email list for TO
                foreach (empIdEmail empIdEmail in empIdEmailCCList)
                    empIdEmailToList.Add(empIdEmail);

                msg = SendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList);

            }
            else
            {
                // ERROR: no valid current department obtained
                msg = "ERROR: No valid current department information obtained.";
            }

            return msg;
        }

        public string GetValidNotificationMsg(string currDeptName, string newThing, string middleText, string changedThing)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotiAndEmails(currDeptName=" + currDeptName + ", newThing=" + newThing + ", middleText, changedThing=" + changedThing + " )");

            int maxSize = Utilities.GetColumnMaxLength<Notification>(x => x.Message);

            System.Diagnostics.Debug.WriteLine(">>> Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message)=" + maxSize);

            string notiMsg = currDeptName + middleText + changedThing + " to " + newThing;

            if (notiMsg.Length > maxSize)
            {
                notiMsg = currDeptName + " changed " + changedThing + " to " + newThing;

                if (notiMsg.Length > maxSize)
                {
                    notiMsg = changedThing + " changed";

                    if (notiMsg.Length > maxSize)
                        notiMsg = notiMsg.Substring(0, maxSize - 1);
                }

                System.Diagnostics.Debug.WriteLine(">>> Shortened notiMsg to " + notiMsg.Length);
            }

            return notiMsg;
        }

        public string SendNotiAndEmails(Employee currEmp, string emailSubject, string emailBody, string notiMsg, List<empIdEmail> empIdEmailToList)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList)");

            string notiRtnMsg, msg = "";

            int successfulNotiSentCount = 0;

            List<String> justEmpEmailList = new List<String>();

            if (empIdEmailToList.Count != 0)
            {
                // send an email one-by-one to every email listed in empIdEmailToList

                RegexUtilities regexUtil = new RegexUtilities();
                EmailControl emailCtrl = new EmailControl();

                foreach (var empIdEmail in empIdEmailToList)
                {
                    notiRtnMsg = SendNotification(empIdEmail.EmployeeID, notiMsg, currEmp.EmployeeID);

                    try
                    {
                        successfulNotiSentCount += int.Parse(notiRtnMsg);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                        msg += notiRtnMsg;
                    }

                    justEmpEmailList.Add(empIdEmail.Email);
                }

                msg += "; Notifications sent: " + successfulNotiSentCount;

                //foreach (String empEmail in justEmpEmailList)
                //{
                string empEmail = currEmp.Email; // temporary until emailCtrl.SendEmail works with an email list for TO

                if (regexUtil.IsValidEmail(empEmail))
                {
                    // valid email, so send
                    try
                    {
                        List<string> toList = new List<string>();
                        toList.Add(empEmail);
                        emailCtrl.SendEmail(toList, emailSubject, emailBody, justEmpEmailList);

                        msg += "; Emails sent.";
                    }
                    catch (Exception e)
                    {
                        // send email error
                        System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                        msg += " SendEmail Exception caught for " + empEmail;
                    }
                }
                else
                {
                    // invalid email found
                    msg += ", Invalid email: " + empEmail;
                }
                //}
            }
            else
            {
                // ERROR: cannot get any recipient emails
                msg += "ERROR: Cannot get any recipient emails.";
            }

            return msg;
        }

        public string SendNotification(string toEmpId, string notiMsg, string fromEmpId)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotification(empID=" + toEmpId + ", notiMsg, fromEmpID=" + fromEmpId + ")");
            //throw new NotImplementedException();

            string rtnMsg = "";

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    Notification aNotification = new Notification();

                    aNotification.UserID = toEmpId;
                    aNotification.Message = notiMsg;
                    aNotification.FromUser = fromEmpId;
                    aNotification.NotificationDate = DateTime.Now;

                    context.Notifications.Add(aNotification);

                    rtnMsg += context.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                    rtnMsg += " ERROR: sendNotification for empID=" + toEmpId;
                }
            }

            return rtnMsg;
        }

        public List<empIdEmail> GetDeptHeadRepIdEmailList(string deptId)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDeptHeadRepIdEmailList(deptID=" + deptId + ")");

            List<empIdEmail> deptHeadRepIdEmailList = new List<empIdEmail>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    foreach (Employee row in context.Employees.Where(x => x.DepartmentID == deptId).ToList())
                    {
                        if (row.Role.Equals("Department Head") || row.Role.Equals("Representative"))
                        {
                            ////Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                            ////anEmpIdEmail.EmployeeID = row.EmployeeID;
                            ////anEmpIdEmail.Email = row.Email;

                            //Model.empIdEmail anEmpIdEmail = Model.Utilities.getEmpIdEmail(row);

                            //deptHeadRepIdEmailList.Add(anEmpIdEmail);

                            deptHeadRepIdEmailList.Add(Utilities.getEmpIdEmail(row));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                }
            }

            return deptHeadRepIdEmailList;
        }

        public List<empIdEmail> GetAllStoreEmployeesIdEmailToList()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getAllStoreEmployeesIdEmailToList()");

            List<empIdEmail> empIdEmailToList = new List<empIdEmail>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    foreach (StoreEmployee row in context.StoreEmployees)
                    {
                        //Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                        //anEmpIdEmail.EmployeeID = row.StoreEmployeeID;
                        //anEmpIdEmail.Email = row.Email;

                        //empIdEmailToList.Add(anEmpIdEmail);

                        empIdEmailToList.Add(Utilities.getStoreEmpIdEmail(row));
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                }
            }

            return empIdEmailToList;
        }

        public string GetEmailBody(Employee currEmp, string currDeptName, string newCollPtName, string changeThing)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getEmailBody(currEmp, currDeptName=" + currDeptName + ", newCollPtName=" + newCollPtName + ")");

            string emailBody = "Dear Sir / Madam,\r\n";
            emailBody += "Please be informed that ";
            emailBody += currDeptName;
            emailBody += " Department has changed their ";
            emailBody += changeThing;
            emailBody += " to ";
            emailBody += newCollPtName;
            emailBody += ".\r\n";
            emailBody += "This is a system generated email, please do not reply.\r\n\r\n";

            if (currEmp != null)
            {
                emailBody += "Change made by ";
                Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                emailBody += crt.getCombEmpNameID(currEmp.EmployeeID, currEmp.Name);
                emailBody += ".\r\n";
            }

            return emailBody;
        }
    }
}