using IOT_Application.Model;

namespace IOT_Application.Repository.RegisterRepo
{
    public interface IRegisterUserRepository
    {
        public RegisterUser GetUser(string userName);

        public string CheckUser(LoginUser user);

        public string GetToken(LoginUser user);

        public RegisterUser AddUser (RegisterUser user);
    }
}
