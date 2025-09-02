using Runtime.Base;
using UnityEngine;
using Runtime.Extensions;
using Runtime.Signals;
using System.Threading.Tasks;

namespace Managers
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        /*--------------------------------------------------------------*/

        public UIMainMenuGroup MainMenuGroup;
        public UIInGameGroup InGameGroup;
        public UIPauseMenuGroup PauseMenuGroup;
        public UILevelComplateGroup LevelComplateGroup;
        public UIGameOverMenuGroup GameOverMenuGroup;
        public UIAlwaysOnGroup AlwaysOnGroup;

        /*--------------------------------------------------------------*/
        public async void OnGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    await OpenMainMenu(0);
                    break;
                case GameState.InGame:
                    await OpenInGameMenu(0);
                    break;
                case GameState.Pause:
                    await OpenPauseMenu(0);
                    break;
                case GameState.LevelComplate:
                    await OpenLevelComplateMenu(1);
                    break;
                case GameState.GameOver:
                   await OpenGameOverMenu(1);
                    break;
                case GameState.None:
                    CloseAllMenu();
                    break;
            }
        }

        /*--------------------------------------------------------------*/

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameStates += OnGameStateChanged;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameStates -= OnGameStateChanged;
        }

        private async Task OpenMainMenu(float second) 
        {
            await Task.Delay((int)(second * 1000));

            MainMenuGroup.Activate(true);
            InGameGroup.Activate(false);
            PauseMenuGroup.Activate(false);
            LevelComplateGroup.Activate(false);
            GameOverMenuGroup.Activate(false);
            AlwaysOnGroup.Activate(true);
            AlwaysOnGroup.SettingMenu.Activate(false);
        }

        private async Task OpenInGameMenu(float second)
        {
            await Task.Delay((int)(second * 1000));

            MainMenuGroup.Activate(false);
            InGameGroup.Activate(true);
            PauseMenuGroup.Activate(false);
            LevelComplateGroup.Activate(false);
            GameOverMenuGroup.Activate(false);
        }

        private async Task OpenPauseMenu(float second)
        {
            await Task.Delay((int)(second * 1000));

            MainMenuGroup.Activate(false);
            InGameGroup.Activate(false);
            PauseMenuGroup.Activate(true);
            LevelComplateGroup.Activate(false);
            GameOverMenuGroup.Activate(false);
        }

        private async Task OpenLevelComplateMenu(float second)
        {
            await Task.Delay((int)(second * 1000));

            MainMenuGroup.Activate(false);
            InGameGroup.Activate(false);
            PauseMenuGroup.Activate(false);
            LevelComplateGroup.Activate(true);
            GameOverMenuGroup.Activate(false);

        }

        private async Task OpenGameOverMenu(float second)
        {
            await Task.Delay((int)(second * 1000));

            MainMenuGroup.Activate(false);
            InGameGroup.Activate(false);
            PauseMenuGroup.Activate(false);
            LevelComplateGroup.Activate(false);
            GameOverMenuGroup.Activate(true);
        }

        private void CloseAllMenu()
        {
            MainMenuGroup.Activate(false);
            InGameGroup.Activate(false);
            PauseMenuGroup.Activate(false);
            LevelComplateGroup.Activate(false);
            GameOverMenuGroup.Activate(false);
        }
    }

    /*--------------------------------------------------------------*/

}
