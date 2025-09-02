
using Managers;
using Runtime.Base;
using Runtime.Signals;
using UnityEngine.UI;

public class UIMainMenuGroup : UIBase
{
    public Button BtnTapToStart;

    private void Awake()
    {
        BtnTapToStart.onClick.AddListener(() => FunTapToStart());
    }

    void FunTapToStart() 
    {
        CoreGameSignals.Instance.onChangeGameStates?.Invoke(GameState.InGame);
    }
}
