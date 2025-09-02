using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterStateFactory
{
    public static MoveState MoveState() 
    {
        return new MoveState();
    }

    public static IdleState IdleState() 
    {
        return new IdleState();
    }
    public static PassiveState PassiveState()
    {
        return new PassiveState();
    }

    public static HandsFreeState HandsFreeState() 
    {
        return new HandsFreeState();
    }

    public static CarryingState CarryingState()
    {
        return new CarryingState();
    }

    public static AIMoveState AIMoveState() 
    {
        return new AIMoveState();
    }
}
