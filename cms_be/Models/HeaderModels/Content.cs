using static cms_be.Models.ConstantModels.Enum;

namespace cms_be.Models.ContentModels
{
    public class Content
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int ContentType { get; set; }
    }
}
