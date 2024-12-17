using Taking.Robson.Domain.Entities;

namespace Taking.Robson.Domain.Interfaces
{
    public interface IVendaRepository
{
    Task<List<Venda>> GetAllAsync();
    Task<Venda> GetByIdAsync(int id);
    Task AddAsync(Venda venda);
    Task UpdateAsync(Venda venda);
    Task DeleteAsync(int id);
}
}
