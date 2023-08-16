using Managers;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : ManagerBase
{
    public override void OnGameStateChanged(GameState newState)
    {
    }

    private void Start()
    {
        GameManager.Instance.ObjectPoolingManager = this;
    }
}
