using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.UI;


namespace MobileBank.Services
{
    internal class Login : Ilogin
    {
        private IUserRequest _userRequest;
        private ICardRequest _cardRequest;

        //! _user is assigned but never used.
        //x User _user;
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
                //!? Architectural issue: SERVICE SHOULD NEVER CALL IU METHODS. UI must be in a higher lever.
                var user = LoginView.Asking();

                result = _userRequest.FindUser(user.user);

                //! 💀 Very Important: Password must be hashed 💀
                if (result != null && result.Password == user.pass)
                {
                    needAsling = false;

                }
                else
                {
                    //! _user is assigned but never used.
                    //x _user = result;
                    //!? Architectural issue: SERVICE SHOULD NEVER CALL IU METHODS. UI must be in a higher lever.
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
