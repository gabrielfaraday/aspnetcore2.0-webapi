using System.Threading.Tasks;

namespace AspNetCore20Example.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
