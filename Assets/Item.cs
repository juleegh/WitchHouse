using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string descriptiveName;
    private Material highlightMat;
    public string DescriptiveName { get { return descriptiveName; } }
    // Start is called before the first frame update
    void Start()
    {
        highlightMat = GetComponent<MeshRenderer>().material;
        ToggleHighlight(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleHighlight(bool visible)
    {
        if (visible)
        {
            highlightMat.SetFloat("_Alpha", 1);
        }
        else
        {
            highlightMat.SetFloat("_Alpha", 0);
        }
    }
}
