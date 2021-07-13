using CAFEMENU.Core.Utilities.Results;
using CAFEMENU.Entities.Concrate.Users;
using CAFEMENU.Entities.Dtos;
using Core.Utilities.Security.Jwt;

namespace CAFEMENU.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
