
namespace SportsStore.WebUI.Infrastructure.Abstract
{
    interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
