using CAFEMENU.Core.CrossCuttingConcerns.Caching;
using CAFEMENU.Core.Utilities.Interceptors;
using CAFEMENU.Core.Utilities.IoC;
using Castle.DynamicProxy;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
namespace CAFEMENU.Core.Aspects.Autofac.Casching
{
    public class RedisAspect : MethodInterception
    {
        private IRedisManager _redisManager;

        public RedisAspect()
        {
            _redisManager = ServiceTool.ServiceProvider.GetService<IRedisManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            var keyy = "redisKeyExample";
            invocation.Proceed();
            _redisManager.SetCacheValueAsync(keyy, invocation.ReturnValue);
        }
    }
}
