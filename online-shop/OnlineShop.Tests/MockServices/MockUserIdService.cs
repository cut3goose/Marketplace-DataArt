using OnlineShop.Infrastructure.UserIdAccess.Interfaces;

namespace OnlineShop.Tests.MockServices
{
    public class MockUserIdService : IUserIdService
    {
        public string GetUserId()
        {
            return "abc123";
        }
    }
}