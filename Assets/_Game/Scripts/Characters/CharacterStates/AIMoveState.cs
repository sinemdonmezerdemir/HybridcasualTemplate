using Managers;
public class AIMoveState : CharacterMainBaseState
{
    AICharacter _aiCharacter;
    public override CharacterMainStateType Type => CharacterMainStateType.Move;
    ICommand _moveCommand;
    public override void EnterState(ManagerBase managerBase)
    {
        if (managerBase is AICharacter)
            _aiCharacter = (AICharacter)managerBase;

        if (!_aiCharacter)
            return;

        _aiCharacter.SetAnimState(AnimatorBoolean.Move, true);

        _moveCommand = MoveCommandFactory.CreateAIMoveCommand(_aiCharacter.Rigidbody, _aiCharacter.Target, _aiCharacter.CharacterData.MoveSpeed);

        _moveCommand.ExecuteOnStart();

    }
    public override void ExitState()
    {
        _moveCommand.ExecuteOnExit();

        _aiCharacter.SetAnimState(AnimatorBoolean.Move, false);
    }
    public override void UpdateState()
    {
        _moveCommand.ExecuteOnUpdate();

        if (!_aiCharacter.CheckInput())
        {
            _aiCharacter.SetCharacterState(CharacterStateFactory.IdleState());
        }
    }
}
