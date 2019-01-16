using System.Collections.Generic;

namespace CareerPoker.Model
{
    public class CareerPokerField
    {
        /// <summary>
        /// 強さの順位
        /// </summary>
        public static IEnumerable<int> Rank { get; } = new List<int>
        {
            3,4,5,6,7,8,9,10,11,12,13,1,2,
        };

        public bool ValidatePut()
        {
            return true;
        }
    }
}
