namespace TariffComparison.Data.Models
{
    public class TariffProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TariffModel Model { get; set; }

        public decimal BaseCost { get; set; }

        public decimal AddedCost { get; set; }

        public decimal Threshold { get; set; }
    }
}
