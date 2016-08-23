using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace TPDDSGrupo44.Models
{
    public class EnvioDeMails
    {
        public EnvioDeMails()
        {
        }
        
        public void enviarMail(TimeSpan cantSegDemora, int tipoDeMail)
        {
            
            SmtpClient server = new SmtpClient();
            server.Port = 587;
            server.Host = "smtp.gmail.com";
            server.EnableSsl = true;
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("dds44utnviernes@gmail.com", "carodds44");

            MailMessage mnsj2 = new MailMessage();
            mnsj2.From  = new MailAddress("dds44utnviernes@gmail.com");
            mnsj2.Sender = new MailAddress("dds44utnviernes@gmail.com");
            switch (tipoDeMail)
            {
                case 0:
                    mnsj2.Subject = "Notificacion de busqueda";
                    mnsj2.Body = "Se Notifica al Administrador en caso que una búsqueda demore más de X segundos";
                    ; break;
                case 1:
                    mnsj2.Subject = "Fallo la aplicacion";
                    mnsj2.Body = "Se Notifica al Administrador que hubo un error. Revisar LOGS";
                    ; break;
            }

            mnsj2.To.Add(new MailAddress("dds44utnviernes@gmail.com"));

            /* Enviar */
            server.Send(mnsj2);
            server.SendAsync(mnsj2, "Pruebita");
            server.Dispose();
        }

    }
}