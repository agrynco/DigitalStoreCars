namespace Services.DTOs.Models
{
    public class GetModelsItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public bool IsAvailable { get; set; }
    }
}