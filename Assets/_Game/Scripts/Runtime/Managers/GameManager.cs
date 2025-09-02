using SceneLoaders;
using UnityEngine;
using Runtime.Extensions;
using Runtime.Signals;


namespace Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        #region Public Variables

        public GameState State { get; private set;}

        #endregion

        protected override void Awake()
        {
            base.Awake();
            
            Application.targetFrameRate = 60;

            SceneLoader.Instance.LoadScene();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnChangeGameState(GameState newState)
        {
            State = newState;
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameStates += OnChangeGameState;
        }

        private void UnSubscribeEvents()
        {
            try
            {
                CoreGameSignals.Instance.onChangeGameStates -= OnChangeGameState;
            }
            catch { }
        }
    }
}