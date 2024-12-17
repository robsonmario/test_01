namespace Taking.Robson.Domain.Entities
{
    public class Venda
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime DataVenda { get; set; }
    public string Filial { get; set; }
    public List<ItemVenda> Itens { get; set; } = new();
    public bool Cancelado { get; set; }
    public decimal ValorTotal => Itens.Sum(item => item.ValorTotal);

    public void ValidarRegrasDeNegocio()
    {
        if (Itens.Any(item => item.Quantidade > 20))
            throw new InvalidOperationException("Não é permitido vender mais de 20 itens iguais.");

        foreach (var item in Itens)
        {
            if (item.Quantidade >= 10)
                item.AplicarDesconto(0.20m);
            else if (item.Quantidade >= 4)
                item.AplicarDesconto(0.10m);
            else
                item.RemoverDesconto();
        }
    }
}
}
