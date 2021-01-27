using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonInteract : MonoBehaviour
{

    private FirstPersonLook     fpsView;
    private FirstPersonMovement fpsMovement;

    Transform camT;

    public float interactRange = 1f;

    private void Awake()
    {
        fpsMovement = GetComponent<FirstPersonMovement>();
        fpsView     = GetComponentInChildren<FirstPersonLook>();

        camT        = fpsView.transform;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.DrawRay(camT.position, camT.forward, Color.red);

            Ray camRay = new Ray(camT.position, camT.forward);
            if (Physics.Raycast(camRay, out hit, interactRange))
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Found something interactable!");
                    GetRootParent(hit.collider.transform).GetComponent<Interactable>().Interact();
                }
        }



    }

    private Transform GetRootParent (Transform t)
    {
        if (t.parent != null)
            return GetRootParent(t); // not at the root yet; go up!
        else
            return t; // we're at the root, return!
    }
}
