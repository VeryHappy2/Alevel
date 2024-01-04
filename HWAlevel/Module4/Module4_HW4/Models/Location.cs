using System.Collections.Generic;

namespace Module4_HW4.Models
{
    public sealed class Location
    {
        public int? Id { get; set; }
        public string LocationName { get; set; }

        public List<Pet> PetList { get; set; }
    }
}
