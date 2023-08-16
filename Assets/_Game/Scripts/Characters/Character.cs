using Managers;
using UnityEngine;


public class Character : ManagerBase
{
    /*--------------------------------------------------------------*/

    public CharacterData CharacterData;

    public Rigidbody Rigidbody;

    public Vector3 Target;

    public CharacterMainBaseState CurrentState;

    public CharacterUpperBaseState CurrentUpperState;

    public Animator Animator;

    public int ItemCapacity;

    public UICharacterCanvas CharacterCanvas;

    public IInteractable Interactable;

    /*--------------------------------------------------------------*/


    protected virtual void FixedUpdate()
    {
        CurrentState?.UpdateState();

        CurrentUpperState?.UpdateState();

    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable = other.gameObject.GetComponent<IInteractable>();
        if (Interactable != null)
        {
            Interactable.OnInteractionEnter(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        IInteractable interactable = Interactable = other.gameObject.GetComponent<IInteractable>();

        if (Interactable != null && interactable == Interactable) 
        {
            Interactable.OnInteractionStay(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = Interactable = other.gameObject.GetComponent<IInteractable>();

        if (Interactable != null && interactable == Interactable)
        {
            Interactable.OnInteractionExit(this);

            Interactable = null;
        }
    }

    /*--------------------------------------------------------------*/
    public override void OnGameStateChanged(GameState newState)
    {
        switch(newState)
        {
            case GameState.MainMenu:
                SetCharacterState(CharacterStateFactory.IdleState());
                break;
        }    
    }

    /*--------------------------------------------------------------*/

    public void SetMoveSpeed(int i)
    {
        CharacterData.MoveSpeed= i;

        SetAnimSpeed();
    }

    public void SetCapacity(int i) 
    {
        ItemCapacity= i;
    }

    public void SetAnimSpeed()
    {
        Animator.speed = ((CharacterData.MoveSpeed + 8) / 10.0f);
    }

    public void SetAnimState(string s, bool b)
    {
        Animator.SetBool(s, b);
    }

    public void SetCharacterState(CharacterMainBaseState newState)
    {
        CurrentState?.ExitState();
        CurrentState = newState;
        CurrentState.EnterState(this);
    }

    public void SetCharacterUpperState(CharacterUpperBaseState newState)
    {
        CurrentUpperState?.ExitState();
        CurrentUpperState = newState;
        CurrentUpperState.EnterState(this);

    }
    /*--------------------------------------------------------------*/

    public virtual bool CheckInput()
    {
        float horizontal = GameManager.Instance.UIManager.InGameGroup.Joystick.Horizontal;
        float vertical = GameManager.Instance.UIManager.InGameGroup.Joystick.Vertical;

        if ((horizontal != 0 || vertical != 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /*--------------------------------------------------------------*/

}
