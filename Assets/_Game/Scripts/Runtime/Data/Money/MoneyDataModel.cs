using Runtime.Data.DataModel;
using UnityEngine;

namespace GameData.Money
{
    [CreateAssetMenu(fileName = "MoneyData", menuName = "Game/Currency/Money/Money Data", order = 0)]
    public class MoneyDataModel : BaseDataModel
    {
        public float startMoneyValue;
    }
}