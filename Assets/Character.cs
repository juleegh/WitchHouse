using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected bool Walk(Vector3 Direction)
    {
        Vector3 normalized = Direction.normalized;
        if (normalized.x != 0 && normalized.z != 0)
        {
            if (Mathf.Abs(normalized.x) > Mathf.Abs(normalized.z))
                normalized.z = 0;
            else
                normalized.x = 0;

            normalized = normalized.normalized;
        }
        Vector3 nextPosition = transform.position + normalized;

        RaycastHit[] hits = Physics.BoxCastAll(transform.position + Direction, Vector3.one * 0.5f, Vector3.down);
        foreach (RaycastHit hit in hits)
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item != null && item.CanGoThrough())
            {
                continue;
            }
            if (hit.collider.GetComponent<Human>() != null)
            {
                continue;
            }
            return false;
        }

        transform.position = nextPosition;
        return true;
    }

    protected void Rotate(Vector3 Direction)
    {
        transform.eulerAngles = Direction;
    }
}
