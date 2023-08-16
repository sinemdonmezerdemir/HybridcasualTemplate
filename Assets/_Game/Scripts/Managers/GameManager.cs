using SceneLoaders;
using UnityEngine;
namespace Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        /*--------------------------------------------------------------*/

        public GameState CurrentGameState { get; private set; }
        public delegate void GameStateChangeHandler(GameState newgameState);
        public event GameStateChangeHandler OnGameStateChanged;

        /*--------------------------------------------------------------*/

        public SceneLoader SceneLoader;

        public UIManager UIManager;

        public CameraManager CameraManager;

        public LevelManager LevelManager;

        public ObjectPoolingManager ObjectPoolingManager;

        /*--------------------------------------------------------------*/

        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);

            SetLogger();

            SceneLoader.LoadScene();
        }

        /*--------------------------------------------------------------*/

        private void SetLogger()
        {
#if UNITY_EDITOR
            Debug.unityLogger.logEnabled = true;
#else
            Debug.unityLogger.logEnabled = false;
#endif
        }

        public void SetState(GameState newGameState)
        {
            if (newGameState == CurrentGameState)
                return;
            CurrentGameState = newGameState;
            OnGameStateChanged?.Invoke(newGameState);
        }

        public void LoadLevel(bool isLevelComplate)
        {
            if (isLevelComplate)
            {
                User.Data.SetNextLevel();
            }

            Debug.Log(User.Data.GetLevel());

            SceneLoader.LoadScene();

            SetState(GameState.None);
        }

        /*--------------------------------------------------------------*/

    }
}