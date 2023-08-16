using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveState : CharacterMainBaseState
{
    public override CharacterMainStateType Type => CharacterMainStateType.Passive;

    Character _character;

    public override void EnterState(ManagerBase managerBase)
    {
        _character = (Character)managerBase;
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
}
