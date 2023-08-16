using UnityEngine.UI;
using Managers;

public class UIGameOverMenuGroup : UIBase
{
    public Button BtnGameOver;

    private void Awake()
    {
        BtnGameOver.onClick.AddListener(() => FunGameOver()) ;
    }

    void FunGameOver()
    {
        GameManager.Instance.LoadLevel(false);
    }
}
