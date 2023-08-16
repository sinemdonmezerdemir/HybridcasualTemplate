using UnityEngine;

namespace Managers
{
    public class UIManager : ManagerBase
    {
        /*--------------------------------------------------------------*/

        public UIMainMenuGroup MainMenuGroup;
        public UIStartupAnim StartupAnimGroup;
        public UIInGameGroup InGameGroup;
        public UIPauseMenuGroup PauseMenuGroup;
        public UILevelComplateGroup LevelComplateGroup;
        public UIGameOverMenuGroup GameOverMenuGroup;
        public UIAlwaysOnGroup AlwaysOnGroup;
        public bool IsVideoUI => isVideoUI;

        /*--------------------------------------------------------------*/

        [Tooltip("Seçili olduğunda uida videoda olmayacak şeyler kapatılır")]
        [SerializeField]
        private bool isVideoUI;

        /*--------------------------------------------------------------*/

        public override void OnGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    MainMenuGroup.Activate(true);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(false);
                    AlwaysOnGroup.Activate(true);
                    break;
                case GameState.StartupAnim:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(true);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(false);
                    break;
                case GameState.InGame:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(true);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(false);
                    break;

                case GameState.Pause:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(true);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(false);
                    break;

                case GameState.LevelComplate:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(true);
                    GameOverMenuGroup.Activate(false);
                    break;

                case GameState.GameOver:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(true);
                    break;

                case GameState.None:
                    MainMenuGroup.Activate(false);
                    StartupAnimGroup.Activate(false);
                    InGameGroup.Activate(false);
                    PauseMenuGroup.Activate(false);
                    LevelComplateGroup.Activate(false);
                    GameOverMenuGroup.Activate(false);
                    break;
            }
        }

        /*--------------------------------------------------------------*/

    }

    /*--------------------------------------------------------------*/

}
