using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using LogicUniversity.Model;



namespace LogicUniversity.Control
{
    public class ReportControl
    {
       
        LogicUniversityEntities ctx;
        public ReportControl()
        {
            ctx = new LogicUniversityEntities();
        }
             
        public List<string> getmonths()
        {

            int tdmth = DateTime.Now.Month-1;
            int tdyear = DateTime.Now.Year;

            List<string> Result = new List<string>();
            string m; 

            for (int i = 0; i <= 11; i++)
            {
               
                m = themonth(tdmth--) +"-"+ tdyear; 
                Result.Add(m);
                
                if (tdmth == -1)
                {
                    tdmth = 11;
                    tdyear--;
                }
                
            }
            
            return Result;
                    
        }
                
        public string themonth(int month)
        {

            string[] months = new string[] {"January", "February", "March", "April", "May","June", "July", "August", "September", "October", "November", "December"};
            return months[month];

        }
       
        }
    }
