using Taking.Robson.Application.Interfaces;
using Taking.Robson.Domain.Entities;
using Taking.Robson.Domain.Interfaces;

namespace Taking.Robson.Application.Services
{
    public class VendaService : IVendaService
{
    private readonly IVendaRepository _repository;

    public VendaService(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Venda>> ObterVendasAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Venda> ObterVendaPorIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CriarVendaAsync(Venda venda)
    {
        venda.ValidarRegrasDeNegocio();
        await _repository.AddAsync(venda);
    }

    public async Task AtualizarVendaAsync(Venda venda)
    {
        venda.ValidarRegrasDeNegocio();
        await _repository.UpdateAsync(venda);
    }

    public async Task CancelarVendaAsync(int id)
    {
        var venda = await _repository.GetByIdAsync(id);
        if (venda == null)
            throw new KeyNotFoundException("Venda não encontrada.");

        venda.Cancelado = true;
        await _repository.UpdateAsync(venda);
    }
}
}
