using MobileBank.Common.Model;

namespace MobileBank.Common.Interface
{
    internal interface Ilogin
    {
        public CardInfo FindCard(string id);
        public User FindeUser();
    }
}
