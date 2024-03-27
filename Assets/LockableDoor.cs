using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockableDoor : Door
{
    [SerializeField] private string keyId;

    public override bool CanBeOpened()
    {
        return Inventory.Instance.MeetsCondition(keyId);
    }
}
