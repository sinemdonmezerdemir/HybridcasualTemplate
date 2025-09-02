using Managers;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    private void Update()
    {
        if (CheckInput())
            InputSignals.Instance.onInputDragged?.Invoke(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
        else
            InputSignals.Instance.onInputStopped?.Invoke();
    }
    private bool CheckInput()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if ((horizontal != 0 || vertical != 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
