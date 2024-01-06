using System.Collections.Generic;

namespace Module4_HW4.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }

        public List<Pet> ReferencePetId { get; set; }
        public List<Breed> Breeds { get; set; }
    }
}
