using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void OnInteractionEnter(Character character);
    public void OnInteractionStay(Character character);
    public void OnInteractionExit(Character character);
} 