using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace manten
{
    public class EnviaMailStaff
    {
        public string send(string exception)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress("Vizsla Software <soporte.axu@gmail.com>"));
                msg.From = new MailAddress("Vizsla Software <grupo@axu.com.ar>");
                msg.Subject = "VIZSLA SOFTWARE - Soporte";
                msg.Body = exception;

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587); /*587,465 gmail*/
                // Este es el código nuevo
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Credentials = new NetworkCredential("soporte.axu@gmail.com", "IronMan464");
                clienteSmtp.Send(msg);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
