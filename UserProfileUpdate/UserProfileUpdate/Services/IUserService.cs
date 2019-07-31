using UserProfileUpdate.Models.InputModel;
using UserProfileUpdate.Models.ViewModel;

namespace UserProfileUpdate.Services
{
    public interface IUserService
    {
        object GetUserById(int userId);

        object GetUserByUserName(string userName);

        object GetUserByEmailId(string email_Id);

        object GetAllUsers();

        object AddUser(UserViewModel userViewModel);

        object UpdateUser(UserInputModel userInputModel);

        object DeleteUser(int userId);
    }
}
