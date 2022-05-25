using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Web.Api.Models;
using Web.Api.SQL;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IDataProvider _dataProvider;

        public ProductController(ILogger<ProductController> logger, IDataProvider dataProvider)
        {
            _logger = logger;
            _dataProvider = dataProvider;
        }

        [HttpGet("{id}")]
        public Product GetProductByID(int id) { return _dataProvider.GetByID(id); }

        [HttpPut("Add")]
        public void Add(Product product) { _dataProvider.Add(product); }

        [HttpPost("Update")]
        public void Update(Product product) { _dataProvider.Update(product); }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id) { _dataProvider.Delete(id); }

        [HttpGet("All")]
        public List<Product> GetAll(int? limit)
        {
            return limit != null ? _dataProvider.GetAllLimit(limit.GetValueOrDefault()).ToList() : _dataProvider.GetAll().ToList();
        }


    }
}