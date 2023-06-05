using MobileBank.Common.Model;

namespace MobileBank.Common.Interface
{
    internal interface IUserRequest
    {
        public User FindUser(string userName);
        public User FindUserWithId(string Id);
        public void InsertNewUser(User newUser);

    }
}
