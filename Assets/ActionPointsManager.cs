using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointsManager : MonoBehaviour
{
    private static ActionPointsManager instance;
    public static ActionPointsManager Instance { get { return instance; } }
    
    private Enemy[] enemies;

    void Awake()
    {
        instance = this;
        enemies = FindObjectsOfType<Enemy>();
    }

    public void ElapseActionPoint()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.ElapseActionPoint();
        }
    }

    public static bool ExecutionInProgress()
    {
        return false;
    }
}
