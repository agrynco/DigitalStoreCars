using Domain;
using Services.DTOs.Models;

namespace Services.AutoMapper
{
    public class CarModelMappingProfile : MappingProfile
    {
        protected override void CreateProfile()
        {
            CreateMap<CarModel, GetModelsItemDto>();
        }
    }
}