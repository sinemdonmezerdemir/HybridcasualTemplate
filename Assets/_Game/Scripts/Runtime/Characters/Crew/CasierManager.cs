using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasierManager : AICharacterManager
{
    private void OnEnable()
    {
        Invoke(nameof(Invoketarget), 0.5f);
    }

    void Invoketarget() 
    {
        //SetTarget(GameManager.Instance.LevelManager.CashRegister.CasierManagerPlacer.position, GameManager.Instance.LevelManager.CashRegister.transform);
    }
}
