using UnityEngine;

namespace Managers
{
    public abstract class ManagerBase : MonoBehaviour
    {
        /*--------------------------------------------------------------*/

        public abstract void OnGameStateChanged(GameState newState);

        /*--------------------------------------------------------------*/

        protected virtual void Awake()
        {
            GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }
        protected virtual void OnDestroy()
        {
            try
            {
                GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;

            }
            catch { }
        }

        /*--------------------------------------------------------------*/
    }
}