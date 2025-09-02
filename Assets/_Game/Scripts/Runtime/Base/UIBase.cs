using UnityEngine;

namespace Runtime.Base
{
    public abstract class UIBase : MonoBehaviour
    {
        public virtual void Activate(bool activate)
        {
            this.gameObject.SetActive(activate);
        }
    }
}
