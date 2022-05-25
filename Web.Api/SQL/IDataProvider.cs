using Web.Api.Models;

namespace Web.Api.SQL
{
    public interface IDataProvider
    {
        public Product GetProductByID(int id);
    }
}
