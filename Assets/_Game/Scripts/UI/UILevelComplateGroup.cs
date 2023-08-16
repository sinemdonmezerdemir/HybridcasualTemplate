
using Managers;
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
        GameManager.Instance.LoadLevel(true);
    }
}
