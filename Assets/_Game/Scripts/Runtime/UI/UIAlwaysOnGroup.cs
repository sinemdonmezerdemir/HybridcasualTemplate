using Controllers;
using DG.Tweening;
using Runtime.Base;
using Runtime.Extensions;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Runtime.Signals;

public class UIAlwaysOnGroup : UIBase
{
    public UISettingMenu SettingMenu;

    [SerializeField] private TextMeshProUGUI txtMoney;
    [SerializeField] private Button btnSettings, btnUpgrade;
    [SerializeField] private RectTransform moneyIconTransform;

    private Vector3 _moneyIconBaseScale;
    private bool _moneyAnimationOn;


    private void Awake()
    {
        _moneyIconBaseScale = moneyIconTransform.localScale;
        btnSettings.onClick.AddListener(FunSettins);
        btnUpgrade.onClick.AddListener(FunUpgrade);
    }

    private void OnEnable()
    {
        CurrencySignals.Instance.onSendMoney+= OnMoneyValueChanged;
    }

    private void Start()
    {
        txtMoney.SetText(CurrencySignals.Instance.onGetMoney().ToCurrencySortString());
    }

    private void OnDisable()
    {
        CurrencySignals.Instance.onSendMoney-= OnMoneyValueChanged;
    }

    void FunSettins()
    {
        SettingMenu.Activate(true);
    }

    void FunUpgrade()
    {

    }

    private void OnMoneyValueChanged(float amount)
    {
        txtMoney.SetText(CurrencySignals.Instance.onGetMoney().ToCurrencySortString());
        ApplyMoneyChangeAnimation();
    }

    private void ApplyMoneyChangeAnimation()
    {
        if (_moneyAnimationOn) return;

        _moneyAnimationOn = true;

        var targetScale = _moneyIconBaseScale * 1.2f;
        moneyIconTransform.DOScale(targetScale, .15f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            _moneyAnimationOn = false;
        });
    }

}
