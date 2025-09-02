
using Managers;
using Runtime.Base;
using UnityEngine.UI;

public class UILevelComplateGroup : UIBase
{
    public Button BtnNextLevel;

    private void Awake()
    {
        BtnNextLevel.onClick.AddListener(() => FunNextLevel());
    }

    void FunNextLevel() 
    {
    }
}
