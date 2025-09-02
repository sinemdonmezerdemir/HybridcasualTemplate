using Managers;
using Runtime.Base;
using UnityEngine;


public class CharacterManager : MonoBehaviour
{
    /*--------------------------------------------------------------*/

    public CharacterData Data;

    public Rigidbody Rigidbody;

    public CharacterMainBaseState CurrentState;

    public CharacterUpperBaseState CurrentUpperState;

    public Animator Animator;

    /*--------------------------------------------------------------*/

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interaction(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.EndInteraction(this);
        }
    }

    protected virtual void Start()
    {
        SetCharacterState(CharacterStateFactory.IdleState());
        SetCharacterUpperState(CharacterStateFactory.HandsFreeState());
        SetAnimSpeed();
    }

    protected virtual void FixedUpdate()
    {
        CurrentState?.FixedUpdateState();

        CurrentUpperState?.FixedUpdateState();

    }

    private void Update()
    {
        CurrentState?.UpdateState();

        CurrentUpperState?.UpdateState();
    }

    public virtual void SetMoveSpeed(int i)
    {
        Data.MoveSpeed = i;

        SetAnimSpeed();
    }

    public virtual void SetCapacity(int i)
    {
        Data.ItemCapacity = i;
    }

    public void SetAnimSpeed()
    {
        Animator.speed = ((Data.MoveSpeed + 8) / 10.0f);
    }

    public void SetAnimState(string s, bool b)
    {
        Animator.SetBool(s, b);
    }

    public void SetCharacterState(CharacterMainBaseState newState)
    {
        if (CurrentState != newState) 
        {
            CurrentState?.ExitState();
            CurrentState = newState;
            CurrentState.EnterState(this);
        }
    }

    public void SetCharacterUpperState(CharacterUpperBaseState newState)
    {
        CurrentUpperState?.ExitState();
        CurrentUpperState = newState;
        CurrentUpperState.EnterState(this);
    }
}
