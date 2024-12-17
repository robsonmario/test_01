using Taking.Robson.Domain.Entities;

namespace Taking.Robson.Application.Interfaces
{
    public interface IVendaService
{
    Task<List<Venda>> ObterVendasAsync();
    Task<Venda> ObterVendaPorIdAsync(int id);
    Task CriarVendaAsync(Venda venda);
    Task AtualizarVendaAsync(Venda venda);
    Task CancelarVendaAsync(int id);
}
}
