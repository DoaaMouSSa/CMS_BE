namespace cms_be.Models.HeaderModels

{
    public class ContentDto
    {
        public int ContentType { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }

        public IFormFile File { get; set; }
    }
}
