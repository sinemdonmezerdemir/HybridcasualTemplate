
using Managers;

namespace States
{
    public abstract class StateBase
    {
        public abstract void EnterState(ManagerBase managerBase);

        public abstract void UpdateState();
        public abstract void ExitState();
    }
}


