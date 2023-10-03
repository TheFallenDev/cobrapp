using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Cobrapp.Logic
{
    public class EmailSender
    {
        public async void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentFilePath)
        {
            try
            {
                // Configura el cliente SMTP
                SmtpClient smtpClient = new SmtpClient(ConfigurationLogic.Instance.GetConfigurationValue("EmailServer"));
                smtpClient.Port = int.Parse(ConfigurationLogic.Instance.GetConfigurationValue("EmailPort"));
                smtpClient.Credentials = new NetworkCredential(ConfigurationLogic.Instance.GetConfigurationValue("EmailUser"), ConfigurationLogic.Instance.GetConfigurationValue("EmailPassword"));
                smtpClient.EnableSsl = true;

                Console.WriteLine(smtpClient.Port);
                Console.WriteLine("Usuario: " + ((NetworkCredential)smtpClient.Credentials).UserName);
                Console.WriteLine("Contraseña: " + ((NetworkCredential)smtpClient.Credentials).Password);
                Console.WriteLine(smtpClient.Host);

                // Crea un mensaje de correo electrónico
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ConfigurationLogic.Instance.GetConfigurationValue("EmailUser"));
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                // Adjunta el archivo al correo electrónico
                Attachment attachment = new Attachment(attachmentFilePath, MediaTypeNames.Application.Octet);
                mailMessage.Attachments.Add(attachment);
                Console.WriteLine("Por enviar correo");
                // Envía el correo electrónico
                await Task.Run(() => smtpClient.Send(mailMessage));

                // Limpia los recursos del mensaje y el cliente SMTP
                mailMessage.Dispose();
                smtpClient.Dispose();

                Console.WriteLine("Correo electrónico enviado con éxito.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
