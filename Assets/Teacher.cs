using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private CurrentActionManager currentAction;
    
    void Start()
    {
        currentAction = GetComponent<CurrentActionManager>();    
    }

    void Update()
    {
        if (ActionPointsManager.ExecutionInProgress())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Walk(transform.forward);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Rotate(-Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Rotate(Vector3.up);
        }

    }

    private void Walk(Vector3 Direction)
    {
        Vector3 nextPosition = transform.position + Direction;
        Debug.Log(Direction);
        
        RaycastHit[] hits = Physics.BoxCastAll(transform.position + Direction, Vector3.one * 0.5f, Vector3.down);
        foreach (RaycastHit hit in hits)
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item != null && item.CanGoThrough())
            {
                continue;
            }
            return;
        }

        currentAction.ResetAvailableActions();
        transform.position = nextPosition;
        ActionPointsManager.Instance.ElapseActionPoint();
    }

    private void Rotate(Vector3 Direction)
    {
        currentAction.ResetAvailableActions();
        transform.eulerAngles += Direction * 90;
    }
}
