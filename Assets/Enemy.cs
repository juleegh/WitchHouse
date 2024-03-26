using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int actionPoints = 0;
    protected virtual int ActionPoints
    {
        get
        {
            return 1;
        }
    }

    private void Awake()
    {
        actionPoints = ActionPoints;
    }

    public void ElapseActionPoint()
    {
        actionPoints--;
        if (actionPoints == 0)
        {
            actionPoints = ActionPoints;
        }
    }

    protected virtual bool PlayerInRange()
    {
        return true;
    }

    protected virtual void DoAction()
    {
    
    }
}
