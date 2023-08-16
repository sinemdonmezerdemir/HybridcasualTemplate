
namespace Managers
{
    public class LevelManager : ManagerBase
    {
        private void Start()
        {
            GameManager.Instance.LevelManager = this;

            GameManager.Instance.SetState(GameState.MainMenu);
        }

        public override void OnGameStateChanged(GameState newState)
        {
        }
    }
}