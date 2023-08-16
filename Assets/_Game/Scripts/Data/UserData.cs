using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class User
{
    /* ------------------------------------------ */

    public static UserData Data
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserData();
                _instance.Init();
            }

            return _instance;
        }
        set => _instance = value;
    }

    public static UserData _instance;

    /* ------------------------------------------ */

    public class UserData 
    {
        /* ------------------------------------------ */

        private static string _currentLevelKey = "CurrentLevelInt", _currencyKey = "CurrencyInt";

        private static int _currentLevel = 1, _currency = 0;

        /*--------------------------------------------------------------*/

        public int GetLevel()
        {
            if (PlayerPrefs.HasKey(_currentLevelKey))
            {
                _currentLevel = PlayerPrefs.GetInt(_currentLevelKey);
            }

            return _currentLevel;
        }

        public void SetNextLevel()
        {
            GetLevel();
            _currentLevel++;
            PlayerPrefs.SetInt(_currentLevelKey, _currentLevel);
            PlayerPrefs.Save();

        }

        public int GetCurrency()
        {
            if (PlayerPrefs.HasKey(_currencyKey))
            {
                _currency = PlayerPrefs.GetInt(_currencyKey);
            }

            return _currency;
        }

        public void UpdateCurrency(int amount, bool b = false)
        {
            GetCurrency();
            _currency += amount;

            if (b)
                _currency = 0;

            PlayerPrefs.SetInt(_currencyKey, _currency);
            PlayerPrefs.Save();

        }

        /*--------------------------------------------------------------*/

        public void Init()
        {
            Load().Forget();
        }

        /* ------------------------------------------ */

        private void Save()
        {
        }

        private async UniTask Load()
        {
        }

        /* ------------------------------------------ */

        public void Clear()
        {
            User.Data = null;
        }
    }

    /* ------------------------------------------ */
}