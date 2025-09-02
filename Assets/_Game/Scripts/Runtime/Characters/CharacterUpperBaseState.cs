using Runtime.Base;
using UnityEngine;

public  abstract class CharacterUpperBaseState : StateBase
{
    public abstract CharacterUpperStateType Type { get; }

}

public enum CharacterUpperStateType
{
    None, HandsFree , Carrying, Cut
}
