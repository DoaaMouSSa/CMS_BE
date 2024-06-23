namespace cms_be.Models.HeaderModels

{
    public class HeaderDto
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
    public class HeaderDtoFile
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
