namespace cms_be.Models.ProductModels
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string image_path { get; set; }
        public int rate { get; set; }
    }
}
