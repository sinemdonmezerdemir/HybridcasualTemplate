
using Runtime.Base;
using UnityEngine;

public abstract class CharacterMainBaseState : StateBase
{
    public abstract CharacterMainStateType Type { get; }
}

public enum CharacterMainStateType
{
    None,Move,Idle,Passive,Sit
}