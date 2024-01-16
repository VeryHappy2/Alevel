using System.Collections.Generic;
using Module4_HW4.Data.Entities;

namespace Module4_HW6.Data.Entities
{
    public sealed class BreedEntity : EntityBase
    {
        public int CategoryId { get; set; }
        public string BreedName { get; set; }

        public List<PetEntity> Pets { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
