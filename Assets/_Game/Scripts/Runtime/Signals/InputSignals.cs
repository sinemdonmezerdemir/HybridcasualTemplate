using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Runtime.Extensions;

namespace Runtime.Signals
{
    public class InputSignals : SingletonMonoBehaviour<InputSignals>
    {
        public UnityAction<Vector3> onInputDragged = delegate { };
        public UnityAction onInputStopped = delegate { };
    }
}
