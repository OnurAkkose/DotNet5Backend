using CAFEMENU.Core.DataAccess.EntityFramework;
using CAFEMENU.DataAccess.Abstract;
using CAFEMENU.DataAccess.Concrate.Contexts;
using CAFEMENU.Entities.Concrate.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.DataAccess.Concrate
{
    public class EfUserDal : EfEntityRepositoryBase<User, CafeMenuContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CafeMenuContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
