using UnityEngine;
using UnityEngine.Events;
public class AICharacterManager : CharacterManager
{
    public UnityAction onTargetChanged;

    public Transform Target => _target;

    public Transform LookTarget => _lookTarget;

    Transform _target, _lookTarget;

    private void OnEnable()
    {
        onTargetChanged += HandleTargetChanged;
    }
    private void OnDisable()
    {
        onTargetChanged -= HandleTargetChanged; 
    }

    public bool ShouldMoveToTargetPosition()
    {
        try
        {
            if (_target == null)
                return false;
            if (Mathf.Abs(transform.position.x - _target.position.x) < 0.1f && Mathf.Abs(transform.position.z - _target.position.z) < 0.1f)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch { return false; }
    }
    public void SetTarget(Transform target, Transform lookTarget = null)
    {
        _target = target;

        _lookTarget = lookTarget;

        onTargetChanged?.Invoke();
    }
    void HandleTargetChanged()
    {
        if (ShouldMoveToTargetPosition())
            SetCharacterState(CharacterStateFactory.AIMoveState());
    }
}
