using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Abstract;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.DTOs;
using Services.DTOs.Models;

namespace Services
{
    public class CarModelsService : ICarModelsService
    {
        private readonly ICarModelsRepository _carModelsRepository;
        private readonly IMapper _mapper;

        public CarModelsService(ICarModelsRepository carModelsRepository, IMapper mapper)
        {
            _carModelsRepository = carModelsRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetModelsItemDto>> GetModels(GetModelsFilterDto filterDto)
        {
            var query = from
                    carModel in _carModelsRepository.GetAll()
                where
                    (filterDto.Brands == null || filterDto.Brands.Length == 0)
                        || filterDto.Brands.Contains(carModel.BrandName)
                select
                    carModel;

            var carModels = await query
                .Skip((filterDto.PageNumber - 1) * filterDto.PageSize)
                .Take(filterDto.PageSize).ToListAsync();

            var totalPages = (await query.CountAsync()) / filterDto.PageSize;
            var models = _mapper.Map<List<CarModel>, GetModelsItemDto[]>(carModels);

            return new PagedResult<GetModelsItemDto>(models, totalPages);
        }
    }
}