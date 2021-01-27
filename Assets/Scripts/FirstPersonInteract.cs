using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonInteract : MonoBehaviour
{

    private FirstPersonLook     fpsView;
    private FirstPersonMovement fpsMovement;

    Transform camT;

    public float interactRange = 1f;

    public bool isInGUI= false;

    private void Awake()
    {
        fpsMovement = GetComponent<FirstPersonMovement>();
        fpsView     = GetComponentInChildren<FirstPersonLook>();

        camT        = fpsView.transform;
    }

    private void Start()
    {
        if (isInGUI)
            isInGUI = !isInGUI; // This is always false;
    }

    private void Update()
    {
        if(isInGUI)
        {
            if (fpsMovement.enabled || fpsView.enabled) // constrain movement if in GUI
                fpsMovement.enabled = fpsView.enabled = false;
        }
        else
            fpsMovement.enabled = fpsView.enabled = true;

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isInGUI)
        {
            Debug.DrawRay(camT.position, camT.forward, Color.red);

            Ray camRay = new Ray(camT.position, camT.forward);
           if (Physics.Raycast(camRay, out hit, interactRange))
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Found something interactable!");
                    GetRootParent(hit.collider.transform);//.GetComponent<Interactable>().Interact();
                }
        }



    }

    private Transform GetRootParent (Transform t)
    {
        //Debug.Log(t.parent.parent.ToString());

        if (t.parent.parent == null)
            Debug.Log("There's a problem!");

        return t;
        //return t;
        /*if (t.parent != null)
            return GetRootParent(t); // not at the root yet; go up!
        else
            return t; // we're at the root, return!*/
    }
}
