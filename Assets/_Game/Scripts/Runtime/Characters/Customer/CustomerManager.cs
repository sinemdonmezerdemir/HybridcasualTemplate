using DG.Tweening;
using Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerManager : AICharacterManager
{
    public int BaseCapacity;

    public List<GameObject> Hots= new();

    private bool _isPayment=false;

    public Sprite ItemSprite;

}
