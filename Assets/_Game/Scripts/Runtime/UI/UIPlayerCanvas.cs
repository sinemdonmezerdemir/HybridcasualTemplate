using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerCanvas : UICharacterCanvas
{
    public TextMeshProUGUI Txt;

    bool control = false;

    private void Update()
    {
        FollowCharacter();
    }

    public override void UpdateTxt(string s)
    {
        if (Txt)
            Txt.text = s;
    }

    public override async void UpdateTxt(string s, bool b)
    {
        if (Txt) 
        {
            Txt.gameObject.SetActive(true);
            Txt.text = s;
        }

        if (b && control==false)
        {
            control = true;
            await System.Threading.Tasks.Task.Delay(1000);
            Txt.text = "";
            control =false;
        }
    }
}
