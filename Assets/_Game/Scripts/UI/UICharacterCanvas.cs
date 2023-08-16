using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICharacterCanvas : UIBase
{
    public Character Character;

    public TextMeshProUGUI TxtItemAmount;

    public Image ImgItem;

    Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - Character.transform.position;
    }

    private void Update()
    {
        FollowCharacter();
    }
    public void FollowCharacter() 
    {
        transform.position = Character.transform.position + _offset;
    }

    public void UpdateTxt(string s) 
    {
        if(TxtItemAmount)
            TxtItemAmount.text = s;
    }

    public void UpdateImg(Sprite s) 
    {
        ImgItem.sprite = s; 
    }
}
