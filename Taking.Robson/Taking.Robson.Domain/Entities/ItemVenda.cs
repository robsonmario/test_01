namespace Taking.Robson.Domain.Entities
{
    public class ItemVenda
{
    public int ProdutoId { get; set; }
    public string Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal Desconto { get; private set; }
    public decimal ValorTotal => Quantidade * (ValorUnitario - Desconto);

    public void AplicarDesconto(decimal percentual)
    {
        Desconto = ValorUnitario * percentual;
    }

    public void RemoverDesconto()
    {
        Desconto = 0;
    }
}
}
