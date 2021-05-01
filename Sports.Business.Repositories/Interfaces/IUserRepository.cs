using Sports.Business.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Business.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetUser(long id);
        Task<List<UserModel>> GetUserDetails(long[] ids);
        Task<List<UserModel>> GetPlayers(long teamId);
        Task<bool> SelectPlayers(long teamId, long[] userIds);
        Task<bool> Insert(UserModel model);
        Task<bool> Update(UserModel model);
        Task<bool> ChangePassword(string email, string password);
        Task<bool> Delete(long id);
        Task<bool> SetPlayerAsCaption(long teamId, long userId);
        Task<UserModel> CheckUserExists(string username, string password);
        bool CheckEmailIdExists(string email);
        Task<bool> IsUserWithEmailIdExists(string email, long userId);
    }
}
