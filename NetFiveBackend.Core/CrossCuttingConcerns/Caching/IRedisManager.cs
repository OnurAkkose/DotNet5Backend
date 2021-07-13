using System;
using System.Linq;
using System.Threading.Tasks;

namespace CAFEMENU.Core.CrossCuttingConcerns.Caching
{
    public interface IRedisManager
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, object data);
    }
}
