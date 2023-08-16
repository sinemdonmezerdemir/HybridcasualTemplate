using UnityEngine;
public abstract class UIBase : MonoBehaviour
{
    public void Activate(bool activate) 
    {
        this.gameObject.SetActive(activate);
    }
}
