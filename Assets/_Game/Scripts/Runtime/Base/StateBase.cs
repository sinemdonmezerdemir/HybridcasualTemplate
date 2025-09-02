
using Managers;

namespace Runtime.Base
{
    public abstract class StateBase
    {
        public abstract void EnterState(CharacterManager characterManager);
        public abstract void FixedUpdateState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }
}


