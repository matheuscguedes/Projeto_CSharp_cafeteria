namespace Cafeteria.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int PrecoUnitario { get; set; }

        public int BaristaId { get; set; }
        public int CafeId { get; set; }
    }
}
