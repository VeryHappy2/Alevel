using Microsoft.AspNetCore.Mvc;

namespace Module6_HW1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateProducts : ControllerBase
    {
        private static readonly string[] Products = new[]
        {
            "Chocolate", "Ice cream", "Apple", "Fish"
        };

        private readonly ILogger<GenerateProducts> _logger;

        public GenerateProducts(ILogger<GenerateProducts> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]

        public IEnumerable<Products> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Products
            {
                ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Price = Random.Shared.Next(0, 100),
                Product = Products[Random.Shared.Next(Products.Length)]
            })
            .ToList();
        }
    }
}
