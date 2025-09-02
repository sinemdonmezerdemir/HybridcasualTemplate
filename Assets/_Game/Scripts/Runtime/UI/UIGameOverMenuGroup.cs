using UnityEngine.UI;
using Managers;
using Runtime.Base;

public class UIGameOverMenuGroup : UIBase
{
    public Button BtnGameOver;

    private void Awake()
    {
        BtnGameOver.onClick.AddListener(() => FunGameOver()) ;
    }

    void FunGameOver()
    {
        
    }
}
