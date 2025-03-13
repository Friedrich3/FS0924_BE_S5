using FluentEmail.Core;
using FS0924_BE_S5.Models;

namespace FS0924_BE_S5.Services
{
    public class EmailServices
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailServices(IFluentEmail fluentemail)
        {
            _fluentEmail = fluentemail;
        }

    public async Task<bool> SendOrder(string email, string nome)
        {
            var result = await _fluentEmail.To(email).Subject("Prenotazione Libro!").Body($"Hai prenotato il libro {nome}").SendAsync();
            return result.Successful;
        }
    }
}
