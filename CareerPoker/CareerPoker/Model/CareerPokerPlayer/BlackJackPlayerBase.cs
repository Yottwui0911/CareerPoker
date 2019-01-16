using System.Linq;
using CardController.Model;

namespace CareerPoker.Model.CareerPokerPlayer
{
    public class CareerPokerPlayerBase : PlayerBase
    {
        /// <summary>
        /// 山札からカードをドローする
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="count"></param>
        public void Draw(Deck deck, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var card = deck.Cards.FirstOrDefault();
                this.Hands.Add(card);
                deck.Cards.Remove(card);
            }
        }
    }
}
