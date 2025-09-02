using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.Base;
public class MoveState : CharacterMainBaseState
{
    PlayerManager _character;

    public override CharacterMainStateType Type => CharacterMainStateType.Move;

    public override void EnterState(CharacterManager characterManager)
    {
        if (characterManager is PlayerManager)
            _character = (PlayerManager)characterManager;


        if (_character==null)
            return;

        _character.SetAnimState(AnimatorBoolean.Move, true);
    }

    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
        _character.SetAnimState(AnimatorBoolean.Move, false);
    }

    void PlayerMove()
    {
        ICommand moveCommand = MoveCommandFactory.CreatePlayerMoveCommand(_character.Rigidbody, _character.Inputs, _character.Data.MoveSpeed, _character.RotateSpeed);
        moveCommand.Execute();
    }

    public override void FixedUpdateState()
    {
        PlayerMove();
    }
}
