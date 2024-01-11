using BusinessObject.Model;

namespace DataAccess.DAO
{
    internal class ProductDAO
    {
        private static ProductDAO instance;
        private static StoreContext _storeContext;

        internal ProductDAO(StoreContext context)
        {
            _storeContext = context;
        }

        internal static ProductDAO getInstance()
        {
            instance ??= new ProductDAO(new StoreContext());
            return instance;
        }

        internal List<Product> GetAllProducts()
        {
            return _storeContext.Products.ToList();
        }

        internal Product? GetProduct(int id)
        {
            return _storeContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        internal Product AddProduct(Product product)
        {
            Product p = _storeContext.Products.Add(product).Entity;
            _storeContext.SaveChanges();
            return p;
        }

        internal Product UpdateProduct(Product product)
        {
            Product p = _storeContext.Products.Update(product).Entity;
            _storeContext.SaveChanges();
            return p;
        }

        internal bool DeleteProduct(int id)
        {
            Product foundProduct = _storeContext.Products.FirstOrDefault(x => x.ProductId == id);

            if (foundProduct == null) { return false; }

            OrderDetailDAO.getInstance().DeleteDetailByProductId(id);
            _storeContext.Products.Remove(foundProduct);


            var indexChanged = _storeContext.SaveChanges();
            return (indexChanged > 0);
        }
    }
}
