namespace Kaizen_final.Models
{
    public class Tea
    {
        public int TeaId { get; set; }
        public string TeaName { get; set; }
        public string TeaDescription { get; set; }
        public decimal Price { get; set; }
        public int Tea_Stock { get; set; }
        public string picURL { get; set; }

        public int farmerid { get; set; }
        public Farmer Farmer { get; set; }

    }
}
