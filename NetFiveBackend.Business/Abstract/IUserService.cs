using CAFEMENU.Entities.Concrate.Users;
using System.Collections.Generic;

namespace CAFEMENU.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
