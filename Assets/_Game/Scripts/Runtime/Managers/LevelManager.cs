using Runtime.Base;
using Runtime.Signals;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Runtime.Extensions;

namespace Managers
{
    public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        /*---------------------------------------------------------------*/

        protected override void Awake()
        {
            base.Awake();

            CoreGameSignals.Instance.onChangeGameStates?.Invoke(GameState.MainMenu);
        }
        
        /*---------------------------------------------------------------*/

    }
}