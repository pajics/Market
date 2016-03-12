using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Market.Core.Database;
using Market.Core.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Market.Core.Products
{
    public interface IProductService
    {
        Result Create(CreateProductModel model);
    }

    public class ProductService : DbContextService, IProductService
    {
        public ProductService(DataContext db) : base(db)  { }

        public Result Create(CreateProductModel model)
        {
            var newProduct = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImagePath = model.ImagePath
            };
            Db.Products.Add(newProduct);
            Db.SaveChanges();
            return Result.Success();
        }
    }
}
