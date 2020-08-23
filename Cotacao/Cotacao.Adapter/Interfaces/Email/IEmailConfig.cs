using Cotacao.Adapter.Models.Config;

namespace Cotacao.Adapter.Interfaces.Email
{
    public interface IEmailConfig
    {
        AddressMail FromAddress { get; }
        AddressMail ToAddress { get; }
        Smtp Smtp { get; }
    }
}
