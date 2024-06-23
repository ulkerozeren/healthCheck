using HeathCheck.MVC.Models;

namespace HeathCheck.MVC.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<SignInResultModel> SignIn(UserLoginModel model);
    }
}
