using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class MoveCommandFactory
{
    public static ICommand CreatePlayerMoveCommand(Rigidbody rb, Vector3 movement, float moveSpeed, float rotationSpeed)
    {
        return new MoveCommand(rb, movement, moveSpeed, rotationSpeed);
    }

    public static ICommand CreateAIMoveCommand( Rigidbody rigidbody, Vector3 destination, float speed ,Transform looaAtTarget)
    {
        return new AIMoveCommand(rigidbody, destination,speed,looaAtTarget);
    }

    internal static ICommand CreateAIMoveCommand(Rigidbody rigidbody, Vector3 destination, float speed)
    {
        return new AIMoveCommand(rigidbody, destination, speed);

    }
}
