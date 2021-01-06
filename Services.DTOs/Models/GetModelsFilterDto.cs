namespace Services.DTOs.Models
{
    public class GetModelsFilterDto : FilterDto
    {
        public string[] Brands { get; set; }
        public bool IsAvailable { get; set; }
    }
}