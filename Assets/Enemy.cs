using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int lineOfSightDepth = 2;
    [SerializeField] private int attackRange = 1;

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
            DoAction();
        }
    }

    private List<Human> RaycastForHumans(float depth)
    {
        List<Human> humans = new List<Human>();
        for (float i = -depth; i <= depth; i++)
        {
            if (i == 0)
            {
                continue;
            }
            RaycastHit[] hits = Physics.BoxCastAll(transform.position + transform.forward * depth, Vector3.one * 0.5f, Vector3.down);
            foreach (RaycastHit hit in hits)
            {
                Human human = hit.collider.GetComponent<Human>();
                if (human != null)
                {
                    humans.Add(human);
                }
            }

            RaycastHit[] hits2 = Physics.BoxCastAll(transform.position + transform.right * depth, Vector3.one * 0.5f, Vector3.down);
            foreach (RaycastHit hit in hits2)
            {
                Human human = hit.collider.GetComponent<Human>();
                if (human != null)
                {
                    humans.Add(human);
                }
            }
        }
        return humans;
    }

    private Human GetClosestHuman(List<Human> humans)
    {
        Vector3 position = transform.position + transform.forward * 50;
        Human closest = null;

        foreach (Human human in humans)
        {
            if (Vector3.Distance(transform.position, human.GetPosition()) < Vector3.Distance(transform.position, position))
            {
                position = human.GetPosition();
                closest = human;
            }
        }
        return closest;
    }

    protected virtual void DoAction()
    {
        Debug.LogError("My turn");
        List<Human> humansInRange = RaycastForHumans(attackRange);
        if (humansInRange.Count > 0)
        {
            Debug.LogError("I attack");
            GetClosestHuman(humansInRange).TakeDamage(1);
            return;
        }

        List<Human> humansInSight = RaycastForHumans(lineOfSightDepth);
        if (humansInSight.Count > 0)
        {
            Debug.LogError("I see you");
            Walk(GetClosestHuman(humansInSight).GetPosition() - transform.position);
        }
    }
}
