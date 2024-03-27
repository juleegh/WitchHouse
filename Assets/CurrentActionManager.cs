using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActionManager : MonoBehaviour
{
    private List<Item> currentItems;
    private int currentItem = -1;
    private Item CurrentItem {  get { return currentItems[currentItem]; } }

    private void Awake()
    {
        currentItems = new List<Item>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentItem == -1)
            {
                FetchItems();
            }
            GoToNextItem();
        }
    }

    public void ResetAvailableActions()
    {
        if (currentItems.Count > 0)
        {
            CurrentItem.ToggleHighlight(false);
        }
        currentItems.Clear();
        currentItem = -1;
    }

    private void FetchItems()
    {
        currentItems.Clear();
        RaycastHit[] hits = Physics.BoxCastAll(transform.position + transform.forward, Vector3.one * 0.5f, Vector3.down);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.GetComponent<Item>() != null)
            {
                currentItems.Add(hit.collider.GetComponent<Item>());
            }
        }
        currentItem = 0;
    }

    private void GoToNextItem()
    {
        if (currentItems.Count == 0)
        {
            return;
        }
        CurrentItem.ToggleHighlight(false);
        currentItem++;
        if (currentItems.Count == currentItem)
        {
            currentItem = 0;
        }
        CurrentItem.ToggleHighlight(true);
    }
}
