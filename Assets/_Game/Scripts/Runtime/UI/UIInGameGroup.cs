using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Runtime.Base;
public class UIInGameGroup : UIBase
{
    public Joystick Joystick;

    public UIPlayerCanvas PlayerCanvas;

    public List<UICustomerManagerCanvas> CustomerManagerCanvasPool = new List<UICustomerManagerCanvas>();

    public UICustomerManagerCanvas GetCustomerManagerCanvas() 
    {
        foreach (UICustomerManagerCanvas canvas in CustomerManagerCanvasPool)
        {
            if (!canvas.gameObject.activeInHierarchy)
            {
                canvas.ItemsShow();
                return canvas;
            }
        }

        return null;
    }

}
