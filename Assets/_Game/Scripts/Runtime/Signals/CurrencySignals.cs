using UnityEngine.Events;
using Runtime.Extensions;
using System;

namespace Runtime.Signals
{
    public class CurrencySignals : SingletonMonoBehaviour<CurrencySignals>
    {
        public UnityAction<float> onSendMoney = delegate { };
        public Func<float> onGetMoney = delegate { return 0; };
    }
}