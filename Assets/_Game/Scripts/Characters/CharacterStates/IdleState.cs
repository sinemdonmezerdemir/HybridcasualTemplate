using Managers;
using UnityEngine;


public class IdleState : CharacterMainBaseState
{
    Character _character;

    RigidbodyConstraints rigidbodyConstraints;

    public override CharacterMainStateType Type => CharacterMainStateType.Idle;

    public override void EnterState(ManagerBase managerBase)
    {
        if (managerBase is Player) 
        {
            _character = (Player)managerBase;
            Player player = _character.GetComponent<Player>();
            rigidbodyConstraints = player.Rigidbody.constraints;
            player.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public override void ExitState()
    {
        if (_character is Player)
        {
            Player player = _character.GetComponent<Player>();
            player.Rigidbody.constraints = rigidbodyConstraints;
        }
    }

    public override void UpdateState()
    {
        if (_character.CheckInput())
        {
            if (_character is Player)
                _character.SetCharacterState(CharacterStateFactory.MoveState());
            else if (_character is AICharacter)
                _character.SetCharacterState(CharacterStateFactory.AIMoveState());
        }
    }

}
