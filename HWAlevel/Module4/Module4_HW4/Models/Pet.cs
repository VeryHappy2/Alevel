namespace Module4_HW4.Models
{
    public sealed class Pet
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? BreedId { get; set; }
        public int? CategoryId { get; set; }
        public float age { get; set; }
        public int? LocationId {  get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public Breed Breed { get; set; }
        public Location Location { get; set; }
        public Category Category { get; set; }

    }
}
