using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : Character, Human
{
    private CurrentActionManager currentAction;
    private int health = 5;
    
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
            if (Walk(transform.forward))
            { 
                currentAction.ResetAvailableActions();
                ActionPointsManager.Instance.ElapseActionPoint();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Rotate(transform.eulerAngles - Vector3.up * 90);
            currentAction.ResetAvailableActions();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Rotate(transform.eulerAngles + Vector3.up * 90);
            currentAction.ResetAvailableActions();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ActionPointsManager.Instance.ElapseActionPoint();
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void TakeDamage(int quantity)
    {
        health--;
        Debug.LogError("ouch");
    }
}
