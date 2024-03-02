using Microsoft.EntityFrameworkCore;
using Module4_HW4.Data;
using Module4_HW4.Data.Entities;
using Module4_HW6.Data.Entities;
using Module4_HW6.Repositories.Abstractions;
using Module4_HW6.Services.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Module4_HW6.App
{
    internal class App
    {
        private readonly ApplicationContext _dbContext;
        private readonly IRepository<BreedEntity> _breedService;
        private readonly IRepository<CategoryEntity> _categoryService;
        private readonly IRepository<LocationEntity> _locationService;
        private readonly IRepository<PetEntity> _petService;
        public App
            (
            IRepository<BreedEntity> breedService,
            IRepository<CategoryEntity> categoryService,
            IRepository<LocationEntity> locationService,
            IRepository<PetEntity> petService,
            IDbContextWrapper<ApplicationContext> context
            ) 
        {
            _petService = petService;
            _locationService = locationService;
            _categoryService = categoryService;
            _breedService = breedService;
            _dbContext = context.DbContext;
        }

        public async Task Start() 
        {
            var idCategory = await _categoryService.AddAsync(

                new CategoryEntity
                {
                    CategoryName = "Cat"
                }
            );
            var idCategory2 = await _categoryService.AddAsync(
                         
                new CategoryEntity
                {
                    CategoryName = "Dog"
                }
            );
            var idBreed = await _breedService.AddAsync(
                new BreedEntity
                {
                    BreedName = "Scottish",
                    CategoryId = idCategory
                }
                );
            var idBreed2 = await _breedService.AddAsync(
                new BreedEntity
                {
                    BreedName = "German Shepherd",
                    CategoryId = idCategory2
                }
                );
            var idLocation = await _locationService.AddAsync(
                new LocationEntity
                {
                    LocationName = "Ukraine",
                }
                );
            var idLocation2 = await _locationService.AddAsync(
                new LocationEntity
                {
                    LocationName = "Euroupe",
                }
                );

            var idPet = await _petService.AddAsync(
            
                new PetEntity
                {
                    Name = "Ricky",
                    age = 4,
                    CategoryId = idCategory,
                    BreedId = idBreed,
                    LocationId = idLocation,
                    ImageUrl = "Url",
                    Description = "dsdsa"
                }
                
            );
            var idPet2 = await _petService.AddAsync(

                new PetEntity
                {
                    Name = "Bruh",
                    age = 2,
                    CategoryId = idCategory2,
                    BreedId = idBreed2,
                    LocationId = idLocation2,
                    ImageUrl = "https://www.akc.org/wp-content/uploads/2017/11/German-Shepherd-on-White-00.jpg",
                    Description = null
                }

            );

            var selectCategory = _dbContext.Categories
                .GroupBy(x => x.CategoryName);

            var selectPet = _dbContext.Pets
                .Include(x => x.Locations)
                .Include(x => x.Breeds)
                .Where(x => x.Locations.LocationName == "Ukraine")
                .Where(x => x.age >= 3);
            foreach( var pet in selectPet)
            {
                Console.WriteLine($"Select Pet {selectPet}");
            }
            foreach (var category in selectCategory)
            {
                Console.WriteLine($"Select category {selectCategory}");
            }

            var resultOfDeleteIdPet = await _petService.DeleteAsync(idPet2);
            var resultOfDeleteIdBreed = await _breedService.DeleteAsync(idBreed2);
            var resultOfDeleteIdCategory = await _categoryService.DeleteAsync(idCategory2);
            var resultOfDeleteIdLocation = await _locationService.DeleteAsync(idLocation2);
            

            Console.WriteLine($"Result remove of breed {resultOfDeleteIdBreed}.\nResult remove of category {resultOfDeleteIdCategory}." +
                $"\nResult remove of location {resultOfDeleteIdLocation}.\nResult remove of location {resultOfDeleteIdPet}");

            var resultUpdateOfPet = await _petService.UpdateAsync(idPet,
                new PetEntity
                {
                    Id = idPet,
                    Name = "Ricky",
                    age = 5,
                    CategoryId = idCategory,
                    BreedId = idBreed,
                    LocationId = idLocation,
                    ImageUrl = "Url",
                    Description = "Super cat"
                }
                );

            Console.WriteLine("Id: " + resultUpdateOfPet);
        }
    }
}
