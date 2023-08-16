using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    Rigidbody _rigidbody;
    Vector3 _movement;
    float _moveSpeed;
    float _rotationSpeed;

    public MoveCommand(Rigidbody rigidbody, Vector3 movement, float moveSpeed, float rotationSpeed)
    {
        _rigidbody = rigidbody;
        _movement = movement;
        _moveSpeed = moveSpeed;
        _rotationSpeed = rotationSpeed;
    }

    public void ExecuteOnUpdate()
    {
        Vector3 movePos = _rigidbody.position + (_movement * _moveSpeed * Time.deltaTime);
        _rigidbody.MovePosition(movePos);

        if (_movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_movement);
            _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    public void ExecuteOnExit()
    {

    }

    public void ExecuteOnStart()
    {
    }
}
