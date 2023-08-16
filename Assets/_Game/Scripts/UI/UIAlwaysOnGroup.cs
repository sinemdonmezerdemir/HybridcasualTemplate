using TMPro;
using UnityEngine.UI;

public class UIAlwaysOnGroup : UIBase
{
    public TextMeshProUGUI TxtCurrency;

    public Button BtnSettings;

    private void Start()
    {
        User.Data.UpdateCurrency(0);
    }

    void UpdateCurrencyText() 
    {
        int currency = User.Data.GetCurrency();

        string formattedCurrency;

        if (currency >= 1000) // 4 basamaklý veya daha fazla
        {
            if(currency < 1000000)
                formattedCurrency = (currency / 1000f).ToString("0.00") + "K";
            else
                formattedCurrency = (currency / 1000000f).ToString("0.000") + "M";

        }
        else // 4 basamaktan az
        {
            formattedCurrency = currency.ToString();
        }

        TxtCurrency.text = formattedCurrency;
    }
}
