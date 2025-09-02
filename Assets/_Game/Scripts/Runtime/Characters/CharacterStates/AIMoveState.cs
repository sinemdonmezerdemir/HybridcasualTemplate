using Managers;
using Runtime.Base;
public class AIMoveState : CharacterMainBaseState
{
    AICharacterManager _aiCharacter;
    public override CharacterMainStateType Type => CharacterMainStateType.Move;

    AIMoveCommand _moveCommand;
    public override void EnterState(CharacterManager characterManager)
    {
        if (characterManager is AICharacterManager)
            _aiCharacter = (AICharacterManager)characterManager;

        if (!_aiCharacter)
            return;

        _aiCharacter.SetAnimState(AnimatorBoolean.Move, true);

        _moveCommand = MoveCommandFactory.CreateAIMoveCommand(_aiCharacter.Rigidbody, _aiCharacter.Target, _aiCharacter.Data.MoveSpeed, _aiCharacter.LookTarget);

        _moveCommand.Initialize();

    }
    public override void ExitState()
    {
        _moveCommand.Exit();

        _aiCharacter.SetAnimState(AnimatorBoolean.Move, false);
    }
    public override void UpdateState()
    {
    }

    public override void FixedUpdateState()
    {
        _moveCommand.Execute();
    }
}
