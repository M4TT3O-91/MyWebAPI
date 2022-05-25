using Web.Api.Models;

namespace Web.Api.SQL
{
    public interface IDataProvider
    {
        public Product GetByID(int id);
        public int Add(Product product);
        public int Update(Product product);
    }
}
