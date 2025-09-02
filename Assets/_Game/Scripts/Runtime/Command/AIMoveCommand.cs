using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveCommand : ICommand
{
    Transform _target;
    float _speed;
    Transform _lookAtTarget;
    Rigidbody _rigidbody;

    NavMeshPath _path = new NavMeshPath();
    int _currentCornerIndex = 0;

    Vector3 pos= Vector3.zero;
    public AIMoveCommand(Rigidbody rigidbody, Transform target, float speed, Transform lookAtTarget = null)
    {
        _rigidbody = rigidbody;
        _target = target;
        _speed = speed;
        _lookAtTarget = lookAtTarget;
    }
    public void Initialize()
    {
        _currentCornerIndex = 0;

        pos = _rigidbody.position;
        NavMesh.CalculatePath(_rigidbody.transform.position ,_target.position, 1, _path);
    }

    public void Execute()
    {
        if (_path.status != NavMeshPathStatus.PathComplete)
        {
            _rigidbody.position = pos;

            NavMesh.CalculatePath(_rigidbody.transform.position, _target.position, 1, _path);
            _currentCornerIndex = 0;
        }

        if (_path.status == NavMeshPathStatus.PathComplete && _currentCornerIndex < _path.corners.Length)
        {
            Vector3 targetCorner = new Vector3(_path.corners[_currentCornerIndex].x, 0, _path.corners[_currentCornerIndex].z);
            Vector3 direction = (targetCorner - new Vector3(_rigidbody.position.x, 0, _rigidbody.position.z)).normalized;
            Vector3 movePos = _rigidbody.position + (direction * _speed * Time.deltaTime);
            Vector3 lookPos = direction;

            _rigidbody.MovePosition(movePos);

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookPos);

                _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, Time.deltaTime * 10);
            }

            if (Mathf.Abs(_rigidbody.position.x - targetCorner.x) < 0.1f && Mathf.Abs(_rigidbody.position.z - targetCorner.z) < 0.1f)
            {
                _currentCornerIndex++;
            }
        }
    }

    public void Exit()
    {
        Vector3 lookDirection;

        if (_lookAtTarget != null)
        {
            lookDirection = _lookAtTarget.position - _rigidbody.transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            float rotationDuration = 0.3f;

            _rigidbody.transform.DORotateQuaternion(targetRotation, rotationDuration).SetEase(Ease.OutSine);
        }
    }
}
