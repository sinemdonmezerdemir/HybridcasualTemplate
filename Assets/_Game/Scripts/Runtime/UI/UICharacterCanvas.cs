using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Runtime.Base;

public class UICharacterCanvas : UIBase
{
    public CharacterManager Character;
    public void FollowCharacter()
    {
        //if (Character != null)
        //    transform.DOMove(Camera.main.WorldToScreenPoint(Character.CanvasPlacer.transform.position), 0.1f);
    }

    public virtual void ItemsShow()
    {
    }

    public virtual void EmojisShow()
    {
    }

    public virtual void UpdateTxt(string s)
    {
    }

    public virtual void UpdateTxt(string s, bool b)
    {
    }

    public virtual void UpdateImg(Sprite s)
    {
    }

    public virtual void UpdateSingleImage(Sprite image)
    {
    }
}
