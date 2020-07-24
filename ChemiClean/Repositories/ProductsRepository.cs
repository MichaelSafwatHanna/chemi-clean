using System.Collections.Generic;
using System.Data.SqlClient;
using ChemiClean.Interfaces;
using ChemiClean.Models;

namespace ChemiClean.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private ProductsRepository() { }
        private static volatile ProductsRepository _instance;
        private static readonly object Lock = new object();

        public static ProductsRepository GetInstance()
        {
            if (_instance != null) return _instance;
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = new ProductsRepository();
                }
            }
            return _instance;
        }

        public void Create(Product obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            var query = "SELECT * FROM tblProduct";
            var command = new SqlCommand(query, SQLServer.ServerConfig.Connection);
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                products.Add(
                    new Product(dataReader["ProductName"].ToString(), dataReader["SupplierName"].ToString(),
                        dataReader["Url"].ToString()));
            }
            dataReader.Close();
            return products;
        }

        public void Update(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
