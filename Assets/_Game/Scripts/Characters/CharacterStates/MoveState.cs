using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterMainBaseState
{
    Player _character;

    public override CharacterMainStateType Type => CharacterMainStateType.Move;

    public override void EnterState(ManagerBase managerBase)
    {
        if (managerBase is Player)
            _character = (Player)managerBase;
 

        if (!_character)
            return;

        _character.SetAnimState(AnimatorBoolean.Move, true);
    }

    public override void UpdateState()
    {
        PlayerMove();
        if (!_character.CheckInput())
            _character.SetCharacterState(CharacterStateFactory.IdleState());

    }
    public override void ExitState()
    {
        _character.SetAnimState(AnimatorBoolean.Move, false);
    }

    void PlayerMove()
    {
        float horizontalMovement = GameManager.Instance.UIManager.InGameGroup.Joystick.Horizontal;
        float verticalMovement = GameManager.Instance.UIManager.InGameGroup.Joystick.Vertical;
        ICommand moveCommand = MoveCommandFactory.CreatePlayerMoveCommand(_character.Rigidbody, new Vector3(horizontalMovement, 0f, verticalMovement), _character.CharacterData.MoveSpeed, _character.RotateSpeed);
        moveCommand.ExecuteOnUpdate();
    }

}
