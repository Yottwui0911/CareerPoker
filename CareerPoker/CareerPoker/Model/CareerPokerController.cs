using System.Collections.Generic;
using System.Linq;
using CardController.Model;
using CareerPoker.Model.CareerPokerPlayer;

namespace CareerPoker.Model
{
    public class CareerPokerController
    {
        public CareerPokerController()
        {
            this.m_user = new User();
            this.m_opponent1 = new Opponent();
            this.m_opponent2 = new Opponent();
            this.m_opponent3 = new Opponent();
            this.m_opponent4 = new Opponent();

            // Joker入りのデッキセットを作成
            this.m_deck = new Deck(true);
            this.m_field = new CareerPokerField();

            this.m_playerMap = new Dictionary<int, PlayerBase>
            {
                { 0, this.m_user},
                { 1, this.m_opponent1},
                { 2, this.m_opponent2},
                { 3, this.m_opponent3},
                { 4, this.m_opponent4},
            };

            this.Initialize();
        }

        #region properites

        private static readonly int m_playerNum = 5;

        /// <summary>
        /// ユーザー
        /// </summary>
        private readonly User m_user;

        /// <summary>
        /// プレイヤー1
        /// </summary>
        private readonly Opponent m_opponent1;

        /// <summary>
        /// プレイヤー2
        /// </summary>
        private readonly Opponent m_opponent2;

        /// <summary>
        /// プレイヤー3
        /// </summary>
        private readonly Opponent m_opponent3;

        /// <summary>
        /// プレイヤー4
        /// </summary>
        private readonly Opponent m_opponent4;

        /// <summary>
        /// 山札
        /// </summary>
        private readonly Deck m_deck;

        /// <summary>
        /// 場
        /// </summary>
        private readonly CareerPokerField m_field;

        private readonly IDictionary<int, PlayerBase> m_playerMap;

        /// <summary>
        /// 現在のターンプレイヤー
        /// </summary>
        private int m_turnPlayerNum;

        private static readonly IDictionary<char, Suit> m_suitMap=new Dictionary<char,Suit>
        {
            {'s', Suit.Spade },
            {'h', Suit.Heart },
            {'c', Suit.Club },
            {'d', Suit.Diamond },
        }

        #endregion

        #region methods

        private void Initialize(int newGameWinner = 0)
        {
            // 以下の処理若干気持ち悪いので直したい。
            var cardNum = this.m_deck.Cards.Count;
            for (var count = newGameWinner; count < cardNum + newGameWinner; count++)
            {
                if (!this.m_deck.Cards.Any())
                {
                    break;
                }

                if (count % m_playerNum == 0)
                {
                    this.m_user.Draw(this.m_deck, 1);
                }
                else if (count % m_playerNum == 1)
                {
                    this.m_opponent1.Draw(this.m_deck, 1);
                }
                else if (count % m_playerNum == 2)
                {
                    this.m_opponent2.Draw(this.m_deck, 1);
                }
                else if (count % m_playerNum == 3)
                {
                    this.m_opponent3.Draw(this.m_deck, 1);
                }
                else if (count % m_playerNum == 4)
                {
                    this.m_opponent4.Draw(this.m_deck, 1);
                }
            }

            // ダイヤの3を持っている人がターンプレイヤーとなる
            foreach(var player in this.m_playerMap)
            {
                if(player.Value.Hands.Any(x=>x.Suit == Suit.Diamond && x.Number == 3))
                {
                    this.m_turnPlayerNum = player.Key;
                    break;
                }
            }
        }

        /// <summary>
        /// 次にターンを送る
        /// </summary>
        private void NextTune()
        {
            var num = this.m_turnPlayerNum++;
            this.m_turnPlayerNum = num % m_turnPlayerNum;
        }

        private void DoPut(IEnumerable<string> args)
        {

        }

        private void DoPass()
        {
            
        }

        private void UserPut()
        {

        }


        private void OnPut()
        {
            this.NextTune();
        }

        private void OnPass()
        {
            this.NextTune();
        }

        #endregion
    }
}
