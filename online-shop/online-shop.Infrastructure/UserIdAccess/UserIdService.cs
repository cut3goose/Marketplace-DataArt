using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;

namespace OnlineShop.Infrastructure.UserIdAccess
{
    public class UserIdService : IUserIdService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserIdService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public string GetUserId()
        {
            return _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}