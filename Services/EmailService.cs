using EC.Models;
using System.Net.Mail;
using System.Net;

namespace EC.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void EnviarNotificacionAdmin(Mensaje msg)
        {
            var host = _config["Email:Host"];
            var port = int.Parse(_config["Email:Port"]);
            var user = _config["Email:User"];
            var pass = _config["Email:Password"];
            var adminEmail = _config["Email:AdminEmail"];

            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };

            var correo = new MailMessage
            {
                From = new MailAddress(user, "EduClick"),
                Subject = $"📩 Nuevo mensaje: {msg.Asunto}",
                IsBodyHtml = true,
                Body = $@"
                <div style='font-family:sans-serif;'>
                    <h2>Nuevo mensaje de contacto</h2>
                    <p><b>Nombre:</b> {msg.NombreCompleto}</p>
                    <p><b>Correo:</b> {msg.Correo}</p>
                    <p><b>Asunto:</b> {msg.Asunto}</p>
                    <p><b>Mensaje:</b><br/>{msg.Contenido}</p>
                    <hr/>
                    <small>Recibido el {msg.FechaEnvio:dd/MM/yyyy HH:mm}</small>
                </div>"
            };
            correo.To.Add(adminEmail);
            client.Send(correo);
        }
    }
}
