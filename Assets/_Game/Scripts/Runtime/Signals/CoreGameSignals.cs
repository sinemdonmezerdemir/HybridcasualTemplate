using Runtime.Extensions;
using System;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : SingletonMonoBehaviour<CoreGameSignals>
    {
        public UnityAction<GameState> onChangeGameStates = delegate { };
        public UnityAction<byte> onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate { };
        public Func<byte> onGetLevelID = delegate { return 0; };
    }
}