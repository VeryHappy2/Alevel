using System.Collections.Generic;
using Module4_HW4.Data.Entities;

namespace Module4_HW6.Data.Entities
{
    public sealed class LocationEntity : EntityBase
    {
        public string LocationName { get; set; }
        public List<PetEntity> Pets { get; set; }
    }
}
