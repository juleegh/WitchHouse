using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Instance { get { return instance; } }

    private List<Item> items;

    private void Awake()
    {
        instance = this;
        items = new List<Item>();
    }

    public void Add(Item newItem)
    {
        items.Add(newItem);
    }

    public bool MeetsCondition(string gameId)
    {
        return FindItem(gameId) != null;
    }

    public void ConsumeItem(string gameId)
    {
        Item firstItem = FindItem(gameId);
        if (firstItem != null)
        {
            items.Remove(firstItem);
        }
    }

    private Item FindItem(string gameId)
    {
        foreach (Item item in items)
        {
            if (item.GameId.Equals(gameId))
            {
                return item;
            }
        }
        return null;
    }
}
