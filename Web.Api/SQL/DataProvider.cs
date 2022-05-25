using System.Data.SqlClient;
using Web.Api.Models;

namespace Web.Api.SQL
{

    public class DataProvider : IDataProvider
    {
        private string _connectionString;

        public DataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Product GetProductByID(int id)
        {
            string sql = @"select * from Products WHERE ID=@id";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();

            if (!reader.Read())
                throw new Exception("Product not found");

            return new Product()
            {
                ID = Convert.ToInt32(reader["ID"].ToString()),
                Name = reader["Name"].ToString(),
                Price = Decimal.Parse(reader["Price"].ToString()),
                Quantity = int.Parse(reader["Quantity"].ToString()),
                Description = reader["Description"].ToString(),
            };
        }

    }
}

