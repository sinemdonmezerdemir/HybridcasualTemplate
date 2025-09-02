using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Runtime.Base;

public class IdleState : CharacterMainBaseState
{
    CharacterManager _character;

    RigidbodyConstraints rigidbodyConstraints;

    public override CharacterMainStateType Type => CharacterMainStateType.Idle;

    public override void EnterState(CharacterManager characterManager)
    {
        if (characterManager is PlayerManager)
        {
            _character = (PlayerManager) characterManager;
            PlayerManager player = (PlayerManager)_character;
            rigidbodyConstraints = player.Rigidbody.constraints;
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if (characterManager is CustomerManager)
            _character = (CustomerManager)characterManager;
        else if (characterManager is CasierManager)
            _character = (CasierManager)characterManager;
        else if (characterManager is CrewManager)
            _character = (CrewManager)characterManager;

    }

    public override void ExitState()
    {
        if (_character is PlayerManager)
        {
            PlayerManager player = (PlayerManager)_character;
            player.Rigidbody.constraints = rigidbodyConstraints;
        }
    }

    public override void FixedUpdateState()
    {
        
    }

    public override async void UpdateState()
    {
        if (_character is CrewManager)
        {
            CrewManager employee = (CrewManager) _character;
            await employee.ChooseAction();
        }
        //if (_character.CheckInput())
        //{
        //    if (_character is Player)
        //        _character.SetCharacterState(CharacterStateFactory.MoveState());
        //    else if (_character is AICharacter)
        //        _character.SetCharacterState(CharacterStateFactory.AIMoveState());
        //}
    }

}
