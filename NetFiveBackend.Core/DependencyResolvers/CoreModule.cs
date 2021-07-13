using CAFEMENU.Core.CrossCuttingConcerns.Caching;
using CAFEMENU.Core.CrossCuttingConcerns.Caching.Microsoft;
using CAFEMENU.Core.CrossCuttingConcerns.Caching.Redis;
using CAFEMENU.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();            
            serviceCollection.AddSingleton<IRedisManager, RedisCacheManager>();            
        }
    }
}
