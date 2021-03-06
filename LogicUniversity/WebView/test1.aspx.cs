﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Threading;

namespace LogicUniversity.WebView
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Label1.Text = System.Web.HttpContext.Current.Request.UrlReferrer.Host+"<br>";
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SendEmail("logicuniversity.edu.sg@gmail.com", "logicuniversity@123",465, "This is body", "hhz.neo@gmail.com","This is subject", "hhz.neo@gmail.com;khinmarlwinoo27@gmail.com;asa.aung1989@gmail.com");
            Control.EmailControl crt = new Control.EmailControl();
            //List<string> toList = new List<string>();
            //toList.Add("hhz.neo@gmail.com");
            //crt.SendEmail(toList, "My Subject", "My Body", new List<string>());
            crt.SendEmail("logicuniversity.edu.sg@gmail.com", "logicuniversity@123", 465, "This is body", "hhz.neo@gmail.com", "This is subject", "hhz.neo@gmail.com");
        }
        public int SendEmail(string from,string password,int port,string body,string to,string subject,string cc)
        {
            //string ToEmail;
            bool fSSL = true;
            try
            {
                //Creating Message object

                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", port);
                if (fSSL)
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);

                //Preparing the message object....

                message.From = from;
                message.To = to;
                message.Cc = cc;
                message.Subject = subject;
                message.BodyFormat = System.Web.Mail.MailFormat.Html;
                message.Body = body;
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";

                Thread email = new Thread(delegate ()
                {
                    System.Web.Mail.SmtpMail.Send(message);
                });

                email.IsBackground = true;
                email.Start();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Control.DisbursementController crt = new Control.DisbursementController();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<Model.AcknowledgeModel> ackList = new List<Model.AcknowledgeModel>();
            Model.AcknowledgeModel temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 1, "C001");
            ackList.Add(temp);
            temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 1, "C001");
            ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "P010");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "T003");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "P021");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "S011");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "T001");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "H011");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "H011");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "C005");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "E030");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "C004");
            //ackList.Add(temp);
            //temp = new Model.AcknowledgeModel(17, "Emp00005", "ARSS", 0, "S010");
            //ackList.Add(temp);
            Control.Acknowledge crt = new Control.Acknowledge();
            crt.acknowledgeDisbursement(ackList);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Control.EmailControl crt = new Control.EmailControl();
            crt.sendEmailToRepresentativeToCollect("ARSS", "1");
        }
    }
}