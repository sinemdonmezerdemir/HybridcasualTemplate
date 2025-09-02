using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void Interaction(CharacterManager character);

    public void KeepInteracting(CharacterManager character);
    public void EndInteraction(CharacterManager  character);
} 