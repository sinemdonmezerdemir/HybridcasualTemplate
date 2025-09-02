using System;
using DG.Tweening;
using Runtime.Data.Management;
using Runtime.Extensions;
using GameData.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Runtime.Signals;

namespace Controllers
{
    public class MoneyCurrencyController : MonoBehaviour
    {
        [SerializeField] private MoneyDataModel moneyDataModel;
        [SerializeField] private Camera mainCamera;

        private MoneySaveData _saveData;
        private float _currentMoneyValue;

        protected void Awake()
        {
            LoadDataHandle();
        }

        private void OnEnable()
        {
            CurrencySignals.Instance.onSendMoney += AddMoneyValue;
            CurrencySignals.Instance.onGetMoney += () => GetMoney();
        }

        private void Start()
        {
            InitSetUp();

            CurrencySignals.Instance.onGetMoney?.Invoke();

        }

        private void OnDisable()
        {
            CurrencySignals.Instance.onSendMoney -= AddMoneyValue;
            CurrencySignals.Instance.onGetMoney -= () => GetMoney();
        }

        private void AddMoneyValue(float value)
        {
            _currentMoneyValue += value;
            _saveData.currentMoneyValue = _currentMoneyValue;
            SaveData();
        }

        private float GetMoney() => _currentMoneyValue;

        private void InitSetUp()
        {
            _currentMoneyValue = _saveData.currentMoneyValue;
        }

        #region DATA MANAGEMENT

        private void LoadDataHandle()
        {
            MoneySaveData loadedData = DataManager.GetWithJson<MoneySaveData>(moneyDataModel.id);

            if (loadedData == null)
            {
                _saveData = new MoneySaveData()
                {
                    id = moneyDataModel.id,
                    currentMoneyValue = moneyDataModel.startMoneyValue
                };

                SaveData();
            }
            else
            {
                _saveData = loadedData;
            }
        }

        private void SaveData()
        {
            DataManager.SaveWithJson(_saveData.id, _saveData);
        }

        #endregion
    }
}