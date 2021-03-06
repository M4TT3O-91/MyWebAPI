using System.Data.SqlClient;
using Web.Api.Models;

namespace Web.Api.SQL
{

    public class DataProvider : IDataProvider
    {
        private readonly string _connectionString;

        public DataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Product GetByID(int id)
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

        public int Add(Product product)
        {
            string sql = @" INSERT INTO Products
                           ([Name]
                           ,[Price]
                           ,[Quantity]
                           ,[Description])
                             VALUES (@Name, @Price, @Quantity, @Description); SELECT @@IDENTITY AS 'Identity';";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Description", product.Description);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public int Update(Product product)
        {
            
                string sql = @" UPDATE Products
                                SET [Name] = @Name
                                      ,[Price] = @Price
                                      ,[Quantity] = @Quantity
                                      ,[Description] = @Description
                                 WHERE ID = @ID";
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@ID", product.ID);
                return command.ExecuteNonQuery();
            
        }

        public int Delete(int id)
        {
            string sql = @" DELETE FROM Products
                            WHERE ID=@ID";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery();
        }

        public IEnumerable<Product> GetAllLimit(int limit)
        {
            string sql = @"SELECT TOP (@limit) * FROM Products";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@limit", limit);
            var reader = command.ExecuteReader();
            //if (!reader.HasRows)
            //    throw new Exception("Nessun prodotto nella lista");
            while (reader.Read())
            {
                yield return new Product()
                {
                    ID = Convert.ToInt32(reader["ID"].ToString()),
                    Name = reader["Name"].ToString(),
                    Price = Decimal.Parse(reader["Price"].ToString()),
                    Quantity = int.Parse(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString(),
                };
            }
        }

        public IEnumerable<Product> GetAll()
        {
            string sql = @"SELECT * FROM Products";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            //if (!reader.HasRows)
            //    throw new Exception("Nessun prodotto nella lista");

            while (reader.Read())
            {
                yield return new Product()
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
}