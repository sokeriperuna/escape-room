using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    protected bool canInteract;

    protected void Start()
    {
        if (!this.CompareTag("Interactable"))
            this.tag = "Interactable";

        if (!canInteract)
            canInteract = !canInteract; // always set this to true

        Debug.Log("Interactable Started!");
    }

    public virtual void Interact()
    {
        if (canInteract)
            PerformFunction();
        else
            Debug.Log("couldn't interact");
    }

    protected abstract void PerformFunction();
}
