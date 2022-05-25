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
        public Product GetProductByID(int id)
        {

            return _dataProvider.GetProductByID(id);

        }
    }
}