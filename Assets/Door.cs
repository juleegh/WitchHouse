using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Item
{
    protected bool isOpen = false;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void DoContextualAction()
    {
        if (CanBeOpened())
        {
            base.DoContextualAction();
            Toggle();
        }
    }

    public virtual bool CanBeOpened()
    {
        return true;
    }

    public override bool CanGoThrough()
    {
        return isOpen;
    }

    private void Toggle()
    {
        isOpen = !isOpen;
        ToggleVisuals();
    }

    private void ToggleVisuals()
    {
        if (isOpen)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            animator.SetTrigger("Close");
        }
    }
}
