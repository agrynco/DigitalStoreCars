using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.AutoMapper;
using Services.DTOs.Models;
using Xunit;

namespace Services.Tests
{
    public class ModelsServiceTests
    {
        private readonly ServiceProvider _serviceProvider;

        public ModelsServiceTests()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile));
            _serviceProvider = services.BuildServiceProvider();
        }

        protected IMapper GetMapper()
        {
            return _serviceProvider.GetService<IMapper>();
        }

        [Fact]
        public void Map_CarModel_To_GetModelsItemDto()
        {
            var carModel = new CarModel
            {
                Id = 1,
                Name = "Name",
                BrandName = "BrandName",
                IsAvailable = true
            };

            var getModelsItemDto = GetMapper().Map<GetModelsItemDto>(carModel);

            getModelsItemDto.Id.Should().Be(carModel.Id);
            getModelsItemDto.Name.Should().Be(carModel.Name);
            getModelsItemDto.BrandName.Should().Be(carModel.BrandName);
            getModelsItemDto.IsAvailable.Should().Be(carModel.IsAvailable);
        }

        [Fact]
        public void Map_CarModels_To_GetModelsItemDtoArray()
        {
            var carModels = new List<CarModel>(new[]
            {
                new CarModel
                {
                    Id = 1,
                    Name = "Name",
                    BrandName = "BrandName",
                    IsAvailable = true
                },
                new CarModel
                {
                    Id = 2,
                    Name = "Name2",
                    BrandName = "BrandName2",
                    IsAvailable = true
                }
            });

            var getModelsItemDtos = GetMapper().Map<GetModelsItemDto[]>(carModels);
            getModelsItemDtos.Length.Should().Be(2);
            getModelsItemDtos[0].Id.Should().Be(1);
            getModelsItemDtos[1].Id.Should().Be(2);
        }

        [Fact]
        public async Task GetModels()
        {
            var db = BuildDbContext();
            PopulateCarModels(db);
            var modelsRepositoryMock = new CarModelsRepository(db);
            ICarModelsService targetService = new CarModelsService(modelsRepositoryMock, GetMapper());
            
            // Act
            var actual = await targetService.GetModels(new GetModelsFilterDto
            {
                IsAvailable = true,
                PageNumber = 1,
                PageSize = 2
            });
            
            //Assert
            actual.Items.Length.Should().Be(2);
            actual.TotalPages.Should().Be(3);
        }

        private static CarsDbContext BuildDbContext()
        {
            return new CarsDbContext(BuildDbContextOptions());
        }

        private static void PopulateCarModels(CarsDbContext db)
        {
            db.CarModels.AddRange(
                new CarModel
                {
                    Id = 1,
                    Name = "Name",
                    BrandName = "BrandName",
                    IsAvailable = true
                }, new CarModel
                {
                    Id = 2,
                    Name = "Name2",
                    BrandName = "BrandName2",
                    IsAvailable = true
                }, new CarModel
                {
                    Id = 3,
                    Name = "Name3",
                    BrandName = "BrandName3",
                    IsAvailable = true
                }, new CarModel
                {
                    Id = 4,
                    Name = "Name4",
                    BrandName = "BrandName4",
                    IsAvailable = true
                }, new CarModel
                {
                    Id = 5,
                    Name = "Name5",
                    BrandName = "BrandName5",
                    IsAvailable = false
                });
            db.SaveChanges();
        }

        private static DbContextOptions<CarsDbContext> BuildDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<CarsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return options;
        }
    }
}