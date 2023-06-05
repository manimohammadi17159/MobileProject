using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.UI;


namespace MobileBank.Services
{
    internal class Login : Ilogin
    {
        private IUserRequest _userRequest;
        private ICardRequest _cardRequest;
        User _user;
        public Login(IUserRequest userRequest, ICardRequest cardRequest)
        {
            _userRequest = userRequest;
            _cardRequest = cardRequest;
        }
        public User FindeUser()
        {
            bool needAsling = true;
            User result = null;

            while (needAsling == true)
            {
                var user = LoginView.Asking();

                result = _userRequest.FindUser(user.user);

                if (result != null && result.Password == user.pass)
                {
                    needAsling = false;

                }
                else
                {
                    _user = result;
                    LoginView.DidntFound();
                }
            }

            return result;
        }
        public CardInfo FindCard(string id)
        {
            CardInfo result = new();
            result = _cardRequest.FindCardWithId(id);

            return result;
        }

    }
}
