using CAFEMENU.Core.Entities;
using System;
using System.Linq;

namespace CAFEMENU.Entities.Concrate.Users
{
    public class UserOperationClaim : IBaseEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
