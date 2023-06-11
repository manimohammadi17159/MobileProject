using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.UI;

namespace MobileBank.Services
{
    internal class SignUp : ISignUp
    {
        IUserRequest _userRequest;
        ICardRequest _cardRequest;
        User _user = new();
        CardInfo _cardInfo = new();


        public SignUp(IUserRequest userRequest, ICardRequest cardRequest)
        {
            _cardRequest = cardRequest;
            _userRequest = userRequest;
        }

        public void StartSignUp()
        {
            _user = SignUpView.GetUserInfo();
            var check = SignUpView.CreadteUserName();

            bool uniqe = CheckBeUniqe(check.user);

            while (uniqe == false)
            {
                SignUpView.SingUpError();
                check = SignUpView.CreadteUserName();
                uniqe = CheckBeUniqe(check.user);
            }
            _user.UserName = check.user;
            _user.Password = check.pass;

            _cardInfo.CardNumber = CreatCardNumber();
         
            _user.Id = CreateId();
            _cardInfo.Id = _user.Id;

            _cardRequest.InsertNewCard(_cardInfo);
            _userRequest.InsertNewUser(_user);
           
            SignUpView.SignUpSuccessful();
            SignUpView.ShowCardInfo(_cardInfo);
        }
        private string CreatCardNumber()//Create an uniqe cardnumber
        {
            bool needCreating = true;
            CardNumberPattern result = new();
            Random rand = new Random();
            string num1, num2;

            while (needCreating == true)
            {
                num1 = rand.Next(0, 9999).ToString();
                num2 = rand.Next(0, 9999).ToString();

                result.Third = num1.PadLeft(4, '0');
                result.Fourth = num2.PadLeft(4, '0');

                //!? This is incorrect. Why is `.ToString()` being called in this context? It always returns the same value.
                var check = _cardRequest.FindCard(result.ToString());// If we find new cardnumber means that isnt uniqe

                if (check == null)
                {
                    needCreating = false;
                }
                else { needCreating = true; }
            }

            //!? Invalid, again.
            return result.ToString(); //Convert all the properties to a string cardnumber 
        }

        private bool CheckBeUniqe(string user)//Check user be uniqe
        {
            //! Not a good idea. Gathering all the information from DB to Service layer, requites alot of memory
            var check = _userRequest.FindUser(user);

            //! Simplification
            //if (check != null) return false;

            //else return true;

            return check == null;
        }
        private string CreateId()
        {
            IdPattern newId = new();
            string result;

            newId.Year = DateTime.Now.Year.ToString();
            newId.Mounth = DateTime.Now.Month.ToString();
            newId.Day = DateTime.Now.Day.ToString();
            newId.Second = DateTime.Now.Second.ToString();
            result = newId.ConvertTwoDigit();
            return result;

        }


    }
}
