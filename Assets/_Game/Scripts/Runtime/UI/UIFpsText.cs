using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFpsText : MonoBehaviour
{
    public TextMeshProUGUI TxtFps;

    private void Awake()
    {
        InvokeFps();
    }

    void InvokeFps() 
    {
        TxtFps.text = ((int)(1 / Time.deltaTime)).ToString();

        Invoke(nameof(InvokeFps), 0.3f);
    }
}
