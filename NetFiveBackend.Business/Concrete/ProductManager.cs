using AutoMapper;
using CAFEMENU.Business.Abstract;
using CAFEMENU.Business.BusinessAspects.Autofac;
using CAFEMENU.Business.CCS;
using CAFEMENU.Business.Concrete.Abstract;
using CAFEMENU.Business.Constants;
using CAFEMENU.Business.ValidationRules.FluentValidation;
using CAFEMENU.Core.Aspects.Autofac.Casching;
using CAFEMENU.Core.Aspects.Autofac.Performance;
using CAFEMENU.Core.Aspects.Autofac.Transaction;
using CAFEMENU.Core.Aspects.Autofac.Validation;
using CAFEMENU.Core.CrossCuttingConcerns.Caching;
using CAFEMENU.Core.CrossCuttingConcerns.Validation;
using CAFEMENU.Core.Utilities.Business;
using CAFEMENU.Core.Utilities.Results;
using CAFEMENU.DataAccess.Abstract;
using CAFEMENU.DataAccess.Concrate;
using CAFEMENU.Entities.Concrate.Products;
using CAFEMENU.Entities.Dtos;
using CAFEMENU.MessageBroker.RabbitMq.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CAFEMENU.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
        private IMessageBroker _messageBroker;
        private IMapper _mapper;
        private IRedisManager _redisCache;
        public ProductManager(IProductDal productDal, ICategoryService categoryService, IMessageBroker messageBroker, IMapper mapper, IRedisManager redisCache)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _messageBroker = messageBroker;
            _mapper = mapper;
            _redisCache = redisCache;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Add")]
        [RedisAspect]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name));// we can set one more parameters.
            if (result != null)
            {
                return result;
            }
          
            _productDal.Add(product);
            var exchangeName = String.Format("{0}Exchange", "productOperation");

            _messageBroker.Publish(exchangeName, "product was added");        
            return new SuccessResult(Messages.ProductAdded);
        }
        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetList(p => p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if (result.Data.Count < 10)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public void UpdateProductPrice()
        {
            var product = _productDal.Get(p => p.Id == 1);
            _productDal.Update(product);
                        
        }
        public ProductDto GetByIdForMapper(int productId)
        {
            var product = _productDal.Get(p => p.Id == productId);
            return _mapper.Map<Product, ProductDto>(product);
        }
        public async Task<string> GetRedisCacheValue(string key)
        {
            return await _redisCache.GetCacheValueAsync(key);
        }

 
    }
}
