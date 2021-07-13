using CAFEMENU.Core.CrossCuttingConcerns.Caching;
using CAFEMENU.Core.Utilities.Interceptors;
using CAFEMENU.Core.Utilities.IoC;
using Castle.DynamicProxy;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
namespace CAFEMENU.Core.Aspects.Autofac.Casching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
