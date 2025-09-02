using DG.Tweening;
using UnityEngine;
using Runtime.Data.DataModel;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game/Character/Character Data")]
public class CharacterData : ScriptableObject
{
    public int MoveSpeed;

    public int ItemCapacity;

    public float TakeItemFromMachineDuration = 1f;

    public float TakeItemJumpPower = 1f, TakeItemDuration = 1f;

    public Ease TakeItemEase = Ease.OutFlash;

    public Sprite CharacterSprite;

}
