using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICustomerManagerCanvas : UICharacterCanvas
{
    public TextMeshProUGUI TxtItemAmount;

    public Image ImgItem,ImgEmoji;

    public override void ItemsShow() 
    {
        ImgEmoji.gameObject.SetActive(false);
        TxtItemAmount.gameObject.SetActive(true);
        ImgItem.gameObject.SetActive(true);
    }

    public override void EmojisShow() 
    {
        ImgEmoji.gameObject.SetActive(true);
        TxtItemAmount.gameObject.SetActive(false);
        ImgItem.gameObject.SetActive(false);
    }

    public override void UpdateTxt(string s)
    {
        if (TxtItemAmount)
            TxtItemAmount.text = s;
    }

    public override void UpdateImg(Sprite s)
    {
        ImgItem.sprite = s;
    }

    public override void UpdateSingleImage(Sprite image) 
    {
        EmojisShow();

        ImgEmoji.sprite=image;
    }
}
