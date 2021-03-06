﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class LoginControl
    {
        LogicUniversityEntities ctx;
        public LoginControl()
        {
            ctx = new LogicUniversityEntities();
        }
        // StoreFound = Store Employee Found;
        // EmployeeFound = Employee Found
        // NotFound = Not Found User;
        // Delegate = Employee is delegate;
        public string Login(string UserID, string PIN)
        {
            string UserType = UserID.Substring(0, 1).ToUpper();
            if (UserType.Equals("S"))
            {
                System.Diagnostics.Debug.WriteLine("StoreClerk Login");
                StoreEmployee semp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == UserID && x.PIN == PIN).FirstOrDefault();
                if (semp == null)
                {
                    System.Diagnostics.Debug.WriteLine("StoreClerk Not Found");
                    return "NotFound";
                }
                return "StoreFound";
            }
            else if (UserType.Equals("E"))
            {
                System.Diagnostics.Debug.WriteLine("Employee Login");
                Employee emp = ctx.Employees.Where(x => x.EmployeeID == UserID && x.PIN == PIN).FirstOrDefault();
                if (emp == null)
                {
                    System.Diagnostics.Debug.WriteLine("Employee Not Found");
                    return "NotFound";
                }
                if (emp.Role != "Department Head")
                {
                    Model.Delegate del = ctx.Delegates.Where(x => x.EmployeeID == emp.EmployeeID && x.ToDate >= DateTime.Today && x.FromDate <= DateTime.Today && x.Active == "Enable").FirstOrDefault();
                    if (del == null)
                    {
                        return "EmployeeFound";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Delegate");
                        return "Delegate";
                    }
                }
                else
                {
                    return "EmployeeFound";
                }
            }
            else if (UserType.Equals("F"))
            {
                System.Diagnostics.Debug.WriteLine("Finance Employee Login");

                try
                {
                    Employee emp = ctx.Employees.Where(x => x.EmployeeID == UserID && x.PIN == PIN).Single();

                    if (emp == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Employee Not Found");
                        return "NotFound";
                    }
                    if (emp.Role != "Department Head")
                    {
                        Model.Delegate del = ctx.Delegates.Where(x => x.EmployeeID == emp.EmployeeID && x.ToDate >= DateTime.Today && x.FromDate <= DateTime.Today).FirstOrDefault();
                        if (del == null)
                        {
                            return "FinanceEmployeeFound";
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Delegate");
                            return "Delegate";
                        }
                    }
                    else
                    {
                        return "FinanceEmployeeFound";
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR: Finance Employee Login e=" + e);
                }
            }
            return "NotFound";
        }
        public Employee getEmployeeUserObject(string empid)
        {
            return ctx.Employees.Where(x => x.EmployeeID == empid).FirstOrDefault();
        }
        public StoreEmployee getStoreEmployeeUserObject(String sid)
        {
            return ctx.StoreEmployees.Where(x => x.StoreEmployeeID == sid).FirstOrDefault();
        }

        // success = successfully changed
        // notfound = user not found
        // error = type is not equal both StoreEmployee and Employee
        public string ChangePIN(Object user, string type, string oldPIN, string newPIN)
        {
            string result = "error";
            if (type.Equals("StoreEmployee"))
            {
                StoreEmployee semp = (StoreEmployee)user;
                StoreEmployee sEmp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == semp.StoreEmployeeID && x.PIN == oldPIN).FirstOrDefault();
                if (sEmp == null)
                    return "notfound";
                sEmp.PIN = newPIN;
                ctx.SaveChanges();
                return "success";
            }
            if (type.Equals("Employee"))
            {
                Employee semp = (Employee)user;
                Employee Emp = ctx.Employees.Where(x => x.EmployeeID == semp.EmployeeID && x.PIN == oldPIN).FirstOrDefault();
                if (Emp == null)
                    return "notfound";
                Emp.PIN = newPIN;
                ctx.SaveChanges();
                return "success";
            }
            return result;
        }
        //Found = UserID is found
        //notFound = UserID is not found
        public string checkUserID(string userID)
        {
            string UserType = userID.Substring(0, 1);
            if (UserType.Equals("S"))
            {
                System.Diagnostics.Debug.WriteLine("StoreClerk Login");
                StoreEmployee sEmp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == userID).FirstOrDefault();
                if (sEmp == null)
                    return "notFound";
                return "Found";
            }
            else if (UserType.Equals("E"))
            {
                System.Diagnostics.Debug.WriteLine("Employee Login");
                Employee emp = ctx.Employees.Where(x => x.EmployeeID == userID).FirstOrDefault();
                if (emp == null)
                    return "notFound";
                return "Found";
            }
            return "notFound";
        }
        //success = successfully send email
        //error = error in send email
        //fail = fail
        //notfound = userID not found
        public string makeForgotPassword(string UserID)
        {
            EmailControl crt = new EmailControl();
            string result = crt.sendEmailForForgotPIN(UserID);
            return result;
        }
        public string forgotPINCheck(int code)
        {
            ForgotPassword fp = ctx.ForgotPasswords.Where(x => x.Code == code && x.Status == "Active").FirstOrDefault();
            if (fp == null)
                return "noFound";
            else
                return "found";
        }
        //invalid
        //Disable
        //notFound
        //success
        //fail
        public string changeForgotPINCheck(int PIN, int code)
        {
            ForgotPassword fp = ctx.ForgotPasswords.Where(x => x.Code == code && x.Status == "Active").FirstOrDefault();
            if (fp == null)
                return "invalid";
            fp.Status = "Disable";
            ctx.SaveChanges();
            string UserType = fp.UserID.Substring(0, 1);
            if (UserType.Equals("S"))
            {
                StoreEmployee sEmp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == fp.UserID).FirstOrDefault();
                if (sEmp == null)
                    return "notFound";
                sEmp.PIN = PIN + "";
                ctx.SaveChanges();
                return "success";
            }
            else if (UserType.Equals("E"))
            {
                Employee emp = ctx.Employees.Where(x => x.EmployeeID == fp.UserID).FirstOrDefault();
                if (emp == null)
                    return "notFound";
                emp.PIN = PIN + "";
                ctx.SaveChanges();
                return "success";

            }
            else
                return "fail";
        }
    }
}