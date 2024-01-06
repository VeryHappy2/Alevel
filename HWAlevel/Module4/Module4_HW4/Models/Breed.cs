using System.Collections.Generic;

namespace Module4_HW4.Models
{
    public sealed class Breed
    {
        public int? Id { get; set; }
        public int CategoryId { get; set; }
        public string BreedName { get; set; }

        public List<Pet> Pets { get; set; }    
        public Category Category { get; set; }
    }
}
