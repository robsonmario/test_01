using Taking.Robson.Domain.Entities;
using Taking.Robson.Domain.Interfaces;

namespace Taking.Robson.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
{
    private readonly List<Venda> _vendas = new();

    public Task<List<Venda>> GetAllAsync()
    {
        return Task.FromResult(_vendas);
    }

    public Task<Venda> GetByIdAsync(int id)
    {
        return Task.FromResult(_vendas.FirstOrDefault(v => v.Id == id));
    }

    public Task AddAsync(Venda venda)
    {
        _vendas.Add(venda);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Venda venda)
    {
        var index = _vendas.FindIndex(v => v.Id == venda.Id);
        if (index >= 0)
            _vendas[index] = venda;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var venda = _vendas.FirstOrDefault(v => v.Id == id);
        if (venda != null) _vendas.Remove(venda);
        return Task.CompletedTask;
    }
}
}
