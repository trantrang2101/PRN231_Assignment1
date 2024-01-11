using BusinessObject.Model;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Add(Product entity)
        {
            return ProductDAO.getInstance().AddProduct(entity);
        }

        public bool Delete(int id)
        {
            return ProductDAO.getInstance().DeleteProduct(id);
        }

        public Product Get(int id)
        {
            return ProductDAO.getInstance().GetProduct(id);
        }

        public List<Product> GetAll()
        {
            return ProductDAO.getInstance().GetAllProducts();
        }

        public Product Update(Product entity)
        {
            return ProductDAO.getInstance().UpdateProduct(entity);
        }
    }
}
