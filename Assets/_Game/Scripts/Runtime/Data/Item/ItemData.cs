using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.Data.DataModel;

[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item/Item Data")]
public class ItemData : BaseDataModel
{
    public int Cost;

    public ItemType Type;

    public Sprite ItemSprite;

    public float Height;

}
