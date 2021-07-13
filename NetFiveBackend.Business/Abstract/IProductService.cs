using CAFEMENU.Core.Utilities.Results;
using CAFEMENU.Entities.Concrate.Products;
using CAFEMENU.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAFEMENU.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        ProductDto GetByIdForMapper(int productId);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IResult TransactionalOperation(Product product);
        void UpdateProductPrice();
        Task<string> GetRedisCacheValue(string key);
    }
}
