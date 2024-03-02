using System.Collections.Generic;
using Module4_HW4.Data.Entities;

namespace Module4_HW6.Data.Entities
{
    public class CategoryEntity : EntityBase
    {
        public string CategoryName { get; set; }

        public List<PetEntity> Pets { get; set; }
        public List<BreedEntity> Breeds { get; set; }
    }
}
