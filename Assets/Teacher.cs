using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionPointsManager.ExecutionInProgress())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Walk(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Walk(-Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Walk(-Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Walk(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(-Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(Vector3.up);
        }

    }

    private void Walk(Vector3 Direction)
    {
        Vector3 nextPosition = transform.position + Direction;
        Debug.Log(Direction);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Direction, out hit, 1f))
        {
            return;
        }
        transform.position = nextPosition;
        ActionPointsManager.Instance.ElapseActionPoint();
    }

    private void Rotate(Vector3 Direction)
    {
        transform.eulerAngles += Direction * 90;
    }
}
