using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace mailstaff
{
    public class EnviaMailStaff
    {
        public string send(string errorMensaje)
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.To.Add(new MailAddress("gmgiro@gmail.com"));

                msg.From = new MailAddress("Vizsla Software<grupo@axu.com.ar>");

                msg.Subject = "Error: VIZSLA SOFTWARE";

                msg.Body = errorMensaje;

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587); /*465*/

                // Este es el código nuevo
                clienteSmtp.EnableSsl = true;
                clienteSmtp.Credentials = new NetworkCredential("gmgiro@gmail.com", "81MarrieD");
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
