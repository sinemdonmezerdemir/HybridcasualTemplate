
using Runtime.Base;
public class PassiveState : CharacterMainBaseState
{
    public override CharacterMainStateType Type => CharacterMainStateType.Passive;

    CharacterManager _character;

    public override void EnterState(CharacterManager characterManager)
    {
       _character = (CharacterManager)characterManager;

        _character.SetCharacterUpperState(CharacterStateFactory.HandsFreeState());

        //_character.CharacterCanvas.gameObject.SetActive(false);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void FixedUpdateState()
    {
        throw new System.NotImplementedException();
    }
}
