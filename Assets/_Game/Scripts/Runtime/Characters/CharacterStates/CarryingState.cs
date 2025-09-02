using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.Base;

public class CarryingState : CharacterUpperBaseState
{
    public override CharacterUpperStateType Type => CharacterUpperStateType.Carrying;

    CharacterManager _character;
    public override void EnterState(CharacterManager characterManager)
    {
        _character = (CharacterManager)characterManager;

        _character.SetAnimState(AnimatorBoolean.Carrying, true);
    }

    public override void ExitState()
    {
        _character.SetAnimState(AnimatorBoolean.Carrying, false);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        throw new System.NotImplementedException();
    }
}
