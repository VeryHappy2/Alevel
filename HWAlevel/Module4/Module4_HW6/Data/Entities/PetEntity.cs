using Module4_HW6.Data.Entities;
using System.Collections.Generic;


namespace Module4_HW4.Data.Entities
{
    public sealed class PetEntity : EntityBase
    {
        public string Name { get; set; }
        public int BreedId { get; set; }
        public int CategoryId { get; set; }
        public float age { get; set; }
        public int LocationId { get; set; }
        public string ImageUrl { get; set; }
        public string? Description { get; set; }

        public BreedEntity Breeds { get; set; }
        public LocationEntity Locations { get; set; }
        public CategoryEntity Category { get; set; }


    }
}
