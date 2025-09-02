using Runtime.Base;

public class HandsFreeState : CharacterUpperBaseState
{
    public override CharacterUpperStateType Type => CharacterUpperStateType.HandsFree;

    CharacterManager _character;
    public override void EnterState(CharacterManager characterManager)
    {
        _character = (CharacterManager) characterManager;
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void FixedUpdateState()
    {
        
    }
}
