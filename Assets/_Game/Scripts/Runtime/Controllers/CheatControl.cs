using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Runtime.Signals;

namespace Controllers
{
    public class CheatControl : MonoBehaviour
    {
        [Space] 
        public Button addMoneyButton, addGemButton, spendGemButton;

        [Space] 
        public Button deleteDataButton;

        public int moneyValue = 500;

        private void Awake()
        {
            addMoneyButton.onClick.AddListener(AddMoney);
        }
        public void AddMoney() 
        {
            CurrencySignals.Instance.onSendMoney?.Invoke((float)moneyValue);
        }
    }
}
