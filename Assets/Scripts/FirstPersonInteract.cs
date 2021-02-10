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

        TerminalGUI.OnGUIOpen  += OnGUIEnter;
        TerminalGUI.OnGUIClose += OnGUIExit;
        Debug.Log("Subscribed events.");
    }

    private void OnDestroy()
    {
        TerminalGUI.OnGUIOpen  -= OnGUIEnter;
        TerminalGUI.OnGUIClose -= OnGUIExit;
        Debug.Log("Unsubscribed events.");
    }

    private void Start()
    {
        if (isInGUI)
            isInGUI = !isInGUI; // This is always false when starting the object;
    }

    private void Update()
    {
        Debug.DrawRay(camT.position, camT.forward, Color.red);

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isInGUI)
        {


            Ray camRay = new Ray(camT.position, camT.forward);
           if (Physics.Raycast(camRay, out hit, interactRange))
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Found something interactable!");
                    Transform t = GetRootParent(hit.collider.transform);

                    if(t != null)
                        t.GetComponent<Interactable>().Interact();
                }
        }
    }

    private Transform GetRootParent (Transform t)
    {
        //Debug.Log(t.parent.parent.ToString());

        if (t == null)
        {
            Debug.LogError("Null transform passed.");
            return null;
        }
        else
        {
            if (t.parent != null)
                return GetRootParent(t.parent);
            else
                return t;
        }
    }

    private void OnGUIEnter()
    {
        isInGUI = true;
        fpsMovement.enabled = fpsView.enabled = false;
    }

    private void OnGUIExit()
    {
        isInGUI = false;
        fpsMovement.enabled = fpsView.enabled = true;
    }
}
