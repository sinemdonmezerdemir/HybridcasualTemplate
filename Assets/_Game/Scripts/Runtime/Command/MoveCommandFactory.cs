using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class MoveCommandFactory
{
    public static MoveCommand CreatePlayerMoveCommand(Rigidbody rb, Vector3 movement, float moveSpeed, float rotationSpeed)
    {
        return new MoveCommand(rb, movement, moveSpeed, rotationSpeed);
    }

    public static AIMoveCommand CreateAIMoveCommand( Rigidbody rigidbody, Transform target, float speed ,Transform looaAtTarget)
    {
        return new AIMoveCommand(rigidbody,target,speed,looaAtTarget);
    }
}
