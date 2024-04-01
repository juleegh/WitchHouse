using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Human
{
    public Vector3 GetPosition();
    public void TakeDamage(int quantity);
}
