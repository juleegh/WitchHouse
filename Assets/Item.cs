using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string descriptiveName;
    [SerializeField] private string gameId;

    private List<Material> highlightMats;
    public string DescriptiveName { get { return descriptiveName; } }
    public string GameId { get { return gameId; } }
    
    void Start()
    {
        highlightMats = new List<Material>();
        MeshRenderer[] rends = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer rend in rends)
        {
            highlightMats.Add(rend.material);
        }
        if (GetComponent<MeshRenderer>() != null)
        {
            highlightMats.Add(GetComponent<MeshRenderer>().material);
        }
        ToggleHighlight(false);
    }

    public void ToggleHighlight(bool visible)
    {
        if (visible)
        {
            foreach (Material highlightMat in highlightMats)
            {
                highlightMat.SetFloat("_Alpha", 1);
            }
        }
        else
        {
            foreach (Material highlightMat in highlightMats)
            {
                highlightMat.SetFloat("_Alpha", 0);
            }
        }
    }

    public virtual void DoContextualAction()
    {
        Inventory.Instance.Add(this);
        gameObject.SetActive(false);
    }


    public virtual bool CanGoThrough()
    {
        return true;
    }
}
