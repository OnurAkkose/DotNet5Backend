using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CAFEMENU.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : IRedisManager
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheManager(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }
        public async Task SetCacheValueAsync(string key, object data)
        {
            var db = _connectionMultiplexer.GetDatabase();          
            await db.StringSetAsync(key,JsonConvert.SerializeObject(data));
        }
        
    }
}
