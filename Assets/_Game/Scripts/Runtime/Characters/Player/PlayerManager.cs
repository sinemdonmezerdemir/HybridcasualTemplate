using Managers;
using Runtime.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    [Range(1, 10)]
    public int RotateSpeed = 5;

    public Transform MoneyParent;

    public Vector3 Inputs;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputDragged += OnInputDragged;
        InputSignals.Instance.onInputStopped += OnInputStopped;
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputDragged -= OnInputDragged;
        InputSignals.Instance.onInputStopped -= OnInputStopped;
    }

    private void OnInputDragged(Vector3 inputs) 
    {
        Inputs = inputs;

        SetCharacterState(CharacterStateFactory.MoveState());
    }

    private void OnInputStopped() 
    {
        SetCharacterState(CharacterStateFactory.IdleState());
    }
}